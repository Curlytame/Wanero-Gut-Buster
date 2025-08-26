using UnityEngine;
using System.Collections;

public class EnemyCard : MonoBehaviour
{
    [Header("Settings")]
    public float delayBeforeAttack = 1.5f;
    public float flySpeed = 8f; // Adjust for world space
    public float shrinkTargetScale = 0.3f;
    public int damageAmount = 5;
    public int energyCost = 1; // Energy consumption of the card, adjustable via the Inspector

    [Header("Target")]
    public Transform playerTargetPoint; // Assign a world-space target like player's face or body

    private Vector3 originalScale;

    void Start()
    {
        // If playerTargetPoint is not assigned, find it dynamically
        if (playerTargetPoint == null)
        {
            GameObject playerTarget = GameObject.Find("PlayerTargetPoint");
            if (playerTarget != null)
            {
                playerTargetPoint = playerTarget.transform;
            }
            else
            {
                Debug.LogError("PlayerTargetPoint not found in the scene. Please ensure the GameObject exists.");
                return;
            }
        }

        originalScale = transform.localScale;

        // Start attack sequence
        StartCoroutine(AttackSequence());
    }

    IEnumerator AttackSequence()
    {
        // Idle delay
        yield return new WaitForSeconds(delayBeforeAttack);

        // Smoothly rotate to face the player
        Vector3 dir = (playerTargetPoint.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, dir); // Adjust for 2D
        Quaternion startRotation = transform.rotation;

        float rotTime = 0f;
        while (rotTime < 1f)
        {
            rotTime += Time.deltaTime * 2f;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, rotTime);
            yield return null;
        }

        // Shrink before flying
        Vector3 targetScale = originalScale * shrinkTargetScale;
        float shrinkTime = 0.3f;
        float elapsed = 0f;
        while (elapsed < shrinkTime)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / shrinkTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Fly toward the player
        while (Vector3.Distance(transform.position, playerTargetPoint.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTargetPoint.position, flySpeed * Time.deltaTime);
            yield return null;
        }

        // Deal damage
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damageAmount);
        }
        else
        {
            Debug.LogWarning("PlayerHealth not found!");
        }

        Destroy(gameObject);
    }

    public void UseCard()
    {
        // This method is used by GameManager to trigger card use
        // Do nothing if this is just called from the spawn logic
    }
}
