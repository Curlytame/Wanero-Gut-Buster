using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CardBehavior : MonoBehaviour, IPointerDownHandler
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isEnlarged = false;
    private bool isUsed = false;

    [Header("Card Settings")]
    public int damageAmount = 20;
    public int energyCost = 1;
    public float enlargeFactor = 1.2f;
    public float resetDelay = 5f;
    public float flySpeed = 800f;
    public float shrinkTargetScale = 0.3f;
    public float backwardDistance = 100f;
    public float backwardDuration = 0.15f;
    public float rotateSpeed = 5f;

    [Header("UI Targets")]
    public RectTransform targetPoint; // Auto-assigned in Start if not set
    public EnemyHealth enemyLogic;    // Auto-assigned in Start if not set

    private Coroutine resetCoroutine;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        enlargedScale = originalScale * enlargeFactor;

        // Auto-assign targetPoint if not manually set
        if (targetPoint == null)
        {
            GameObject targetObj = GameObject.Find("EnemyTargetPoint");
            if (targetObj != null)
            {
                targetPoint = targetObj.GetComponent<RectTransform>();
            }
            else
            {
                Debug.LogWarning("EnemyTargetPoint not found in the scene!");
            }
        }

        // Auto-assign enemyLogic if not manually set
        if (enemyLogic == null)
        {
            EnemyHealth foundEnemy = FindObjectOfType<EnemyHealth>();
            if (foundEnemy != null)
            {
                enemyLogic = foundEnemy;
            }
            else
            {
                Debug.LogWarning("EnemyHealth script not found in the scene!");
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isUsed) return;

        if (!isEnlarged)
        {
            EnlargeCard();
        }
        else
        {
            UseCard();
        }
    }

    void EnlargeCard()
    {
        rectTransform.localScale = enlargedScale;
        isEnlarged = true;

        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        resetCoroutine = StartCoroutine(AutoReset());
    }

    void UseCard()
    {
        if (!GameManager.Instance.UseEnergy(energyCost))
            return;

        isUsed = true;
        isEnlarged = false;

        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        Debug.Log("Card Used!");

        if (targetPoint != null)
        {
            StartCoroutine(AnimateCardUse());
        }
        else
        {
            Debug.LogWarning("No target point assigned!");
            Destroy(gameObject);
        }
    }

    IEnumerator AnimateCardUse()
    {
        // Shrink card
        rectTransform.localScale = originalScale * shrinkTargetScale;

        // Move backward briefly
        Vector3 backwardDir = -rectTransform.up * backwardDistance;
        Vector3 backwardTarget = rectTransform.position + backwardDir;
        float elapsed = 0f;

        Vector3 startPos = rectTransform.position;
        while (elapsed < backwardDuration)
        {
            rectTransform.position = Vector3.Lerp(startPos, backwardTarget, elapsed / backwardDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Rotate toward target
        Vector3 direction = (targetPoint.position - rectTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        // Move toward target
        while (Vector3.Distance(rectTransform.position, targetPoint.position) > 10f)
        {
            rectTransform.position = Vector3.MoveTowards(rectTransform.position, targetPoint.position, flySpeed * Time.deltaTime);
            rectTransform.rotation = Quaternion.Lerp(rectTransform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
            yield return null;
        }

        // Apply damage to enemy logic
        if (enemyLogic != null)
        {
            enemyLogic.TakeDamage(damageAmount);
        }
        else
        {
            Debug.LogWarning("Enemy logic not assigned!");
        }

        Destroy(gameObject);
    }

    IEnumerator AutoReset()
    {
        yield return new WaitForSeconds(resetDelay);
        rectTransform.localScale = originalScale;
        isEnlarged = false;
        resetCoroutine = null;
    }
}
