using UnityEngine;
using System.Collections;

public class EnemyCardBehaviour : MonoBehaviour
{
    [Header("Card Data")]
    public EnemyCardStats cardStats;  // Reference to the enemy’s card data

    [Header("Timing Settings")]
    public float playDelay = 0.5f;   // Delay before effect triggers
    public float stayDuration = 0.5f; // Time to stay on screen after effect
    public float fadeDuration = 0.5f; // Fade-out time

    private SpriteRenderer spriteRenderer;

    // Static lock to prevent multiple cards from playing simultaneously
    private static bool isPlayingCard = false;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (cardStats == null)
        {
            Debug.LogWarning($"EnemyCardStats not assigned to {gameObject.name}");
            Destroy(gameObject);
            return;
        }

        // Try to start playing the card when instantiated
        StartCoroutine(PlayCardRoutine());
    }

    private IEnumerator PlayCardRoutine()
    {
        // Wait until no other card is playing
        yield return new WaitUntil(() => !isPlayingCard);
        isPlayingCard = true;

        Debug.Log($"Enemy is preparing to play: {cardStats.cardName}");

        // Optional delay before the effect actually triggers
        yield return new WaitForSeconds(playDelay);

        // Execute the card’s effect
        PlayCard(FindObjectOfType<PlayerHealth>()?.gameObject);

        // Wait a bit before fading away
        yield return new WaitForSeconds(stayDuration);

        // Fade out visually
        if (spriteRenderer != null)
        {
            yield return StartCoroutine(FadeOut());
        }

        // Destroy after fade
        Destroy(gameObject);

        // Unlock so the next card can play
        isPlayingCard = false;
    }

    public void PlayCard(GameObject target = null)
    {
        Debug.Log($"{cardStats.cardName} played! Cost: {cardStats.energyCost}");

        // --- Damage the player ---
        if (cardStats.canDamage && target != null && target.CompareTag("Player"))
        {
            PlayerHealth player = target.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(cardStats.damageValue);
            }
        }

        // --- Heal self ---
        if (cardStats.canHeal)
        {
            EnemyHealth self = GetComponent<EnemyHealth>();
            if (self != null)
            {
                self.Heal(cardStats.healValue); // Ensure EnemyHealth has Heal()
            }
        }

        // --- Buff ---
        if (cardStats.canBuff)
        {
            Debug.Log($"Enemy applied buff of {cardStats.buffValue}");
            // TODO: Apply buff logic in EnemyStats
        }

        // --- Draw card ---
        if (cardStats.canDrawCard)
        {
            Debug.Log($"Enemy draws {cardStats.drawCount} card(s).");
        }
    }

    private IEnumerator FadeOut()
    {
        if (spriteRenderer == null)
            yield break;

        Color startColor = spriteRenderer.color;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
}
