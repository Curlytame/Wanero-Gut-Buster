using UnityEngine;
using System.Collections;

public class EnemyCardBehaviour : MonoBehaviour
{
    [Header("Card Data")]
    public EnemyCardStats cardStats;

    [Header("Timing Settings")]
    public float playDelay = 0.5f;
    public float stayDuration = 0.5f;
    public float fadeDuration = 0.5f;

    private SpriteRenderer spriteRenderer;
    private static bool isPlayingCard = false;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (cardStats == null)
        {
            Debug.LogWarning($"⚠️ EnemyCardStats not assigned to {gameObject.name}");
            Destroy(gameObject);
            return;
        }

        StartCoroutine(PlayCardRoutine());
    }

    private IEnumerator PlayCardRoutine()
    {
        yield return new WaitUntil(() => !isPlayingCard);
        isPlayingCard = true;

        Debug.Log($"Enemy preparing to play {cardStats.cardName}...");

        yield return new WaitForSeconds(playDelay);

        PlayCard(FindObjectOfType<PlayerHealth>()?.gameObject);

        yield return new WaitForSeconds(stayDuration);

        if (spriteRenderer != null)
            yield return StartCoroutine(FadeOut());

        Destroy(gameObject);
        isPlayingCard = false;
    }

    public void PlayCard(GameObject target = null)
    {
        Debug.Log($"{cardStats.cardName} played! Cost: {cardStats.energyCost}");

        // --- Damage ---
        if (cardStats.canDamage && target != null && target.CompareTag("Player"))
        {
            PlayerHealth player = target.GetComponent<PlayerHealth>();
            PlayerStats stats = target.GetComponent<PlayerStats>();

            if (player != null)
            {
                int defense = stats != null ? stats.defence : 0;
                int finalDamage = Mathf.Max(0, cardStats.damageValue - defense);

                player.TakeDamage(finalDamage);
                Debug.Log($"💢 Enemy dealt {finalDamage} (Base {cardStats.damageValue} - Defense {defense}).");
            }
        }

        // --- Heal ---
        if (cardStats.canHeal)
        {
            EnemyHealth self = GetComponent<EnemyHealth>();
            if (self != null)
            {
                self.Heal(cardStats.healValue);
            }
        }

        // --- Buff (placeholder for future enemy buffs) ---
        if (cardStats.canBuff)
        {
            Debug.Log($"Enemy applied buff of {cardStats.buffValue}");
        }

        // --- Draw card (if AI deck) ---
        if (cardStats.canDrawCard)
        {
            Debug.Log($"Enemy draws {cardStats.drawCount} card(s).");
        }
    }

    private IEnumerator FadeOut()
    {
        if (spriteRenderer == null) yield break;

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
