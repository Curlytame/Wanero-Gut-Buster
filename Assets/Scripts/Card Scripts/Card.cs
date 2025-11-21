using UnityEngine;

public class Card : MonoBehaviour
{
    private Collider2D col;
    private Vector3 startDragPosition;
    private HandManager handManager;
    private int originalIndex = -1;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        handManager = FindObjectOfType<HandManager>();
        if (handManager != null)
        {
            originalIndex = handManager.GetCardIndex(this);
        }
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        if (handManager != null)
        {
            originalIndex = handManager.GetCardIndex(this);
            handManager.RemoveCardFromHand(this);
        }
        transform.SetParent(null); // detach while dragging
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint((Vector2)transform.position);
        col.enabled = true;

        if (hitCollider != null)
        {
            // Drop on a valid area
            if (hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
            {
                cardDropArea.OnCardDrop(this);
                return;
            }

            // Dropped on hand area
            if (hitCollider.CompareTag("HandArea") && handManager != null)
            {
                handManager.AddCardToHand(this, originalIndex);
                return;
            }
        }

        // If not valid → return to original pos & reinsert at correct spot
        if (handManager != null)
        {
            handManager.AddCardToHand(this, originalIndex);
        }
        else
        {
            transform.position = startDragPosition;
        }
    }

    private Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
}
