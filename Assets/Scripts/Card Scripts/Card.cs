using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Collider2D col;
    private Vector3 startDragPosition;
    private HandManager handManager;
    private int originalIndex = -1;

    [Header("Target Indicator Group (Scene Object Name: TargetGroup)")]
    private GameObject[] targetIndicators;
    private bool isDragging = false;
    public float blinkSpeed = 1.5f;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        handManager = FindObjectOfType<HandManager>();

        if (handManager != null)
            originalIndex = handManager.GetCardIndex(this);

        // 🔵 Automatically find "TargetGroup" in the *scene*
        GameObject group = GameObject.Find("TargetGroup");

        if (group != null)
        {
            int count = group.transform.childCount;
            targetIndicators = new GameObject[count];

            for (int i = 0; i < count; i++)
                targetIndicators[i] = group.transform.GetChild(i).gameObject;
        }

        ShowIndicators(false);
    }

    private void Update()
    {
        if (isDragging && targetIndicators != null)
        {
            float alpha = (Mathf.Sin(Time.time * blinkSpeed) + 1f) * 0.5f;

            foreach (GameObject ind in targetIndicators)
            {
                if (ind == null) continue;

                CanvasGroup cg = ind.GetComponent<CanvasGroup>();
                if (cg != null)
                {
                    cg.alpha = alpha;
                    continue;
                }

                Image img = ind.GetComponent<Image>();
                if (img != null)
                {
                    Color c = img.color; c.a = alpha; img.color = c;
                    continue;
                }

                SpriteRenderer sr = ind.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    Color c = sr.color; c.a = alpha; sr.color = c;
                    continue;
                }

                ind.SetActive(alpha > 0.5f);
            }
        }
    }

    private void ShowIndicators(bool show)
    {
        if (targetIndicators == null) return;

        foreach (GameObject ind in targetIndicators)
        {
            if (ind == null) continue;
            ind.SetActive(show);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        ShowIndicators(true);

        startDragPosition = transform.position;
        if (handManager != null)
        {
            originalIndex = handManager.GetCardIndex(this);
            handManager.RemoveCardFromHand(this);
        }
        transform.SetParent(null);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseUp()
    {
        isDragging = false;
        ShowIndicators(false);

        col.enabled = false;
        Collider2D hit = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;

        if (hit != null)
        {
            if (hit.TryGetComponent(out ICardDropArea dropArea))
            {
                dropArea.OnCardDrop(this);
                return;
            }

            if (hit.CompareTag("HandArea") && handManager != null)
            {
                handManager.AddCardToHand(this, originalIndex);
                return;
            }
        }

        if (handManager != null)
            handManager.AddCardToHand(this, originalIndex);
        else
            transform.position = startDragPosition;
    }

    private Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        return pos;
    }
}
