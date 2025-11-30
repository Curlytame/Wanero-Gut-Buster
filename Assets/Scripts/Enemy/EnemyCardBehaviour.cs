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
            EnemyStats enemyStats = FindObjectOfType<EnemyStats>();

            int enemyAttackBonus = enemyStats != null ? enemyStats.attackBonus : 0;
            int playerDefense = stats != null ? stats.defence : 0;

            int totalDamage = Mathf.Max(0, (cardStats.damageValue + enemyAttackBonus) - playerDefense);
            if (player != null)
                player.TakeDamage(totalDamage);

            Debug.Log($"💥 Enemy dealt {totalDamage} (Base {cardStats.damageValue} + EnemyAtkBonus {enemyAttackBonus} - PlayerDef {playerDefense})");
        }

        // --- Heal ---
        if (cardStats.canHeal)
        {
            // Find the actual enemy in the scene to heal
            EnemyHealth enemyHealth = FindObjectOfType<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.Heal(cardStats.healValue);
                Debug.Log($"💚 Enemy healed by {cardStats.healValue}");
            }
            else
            {
                Debug.LogWarning("⚠️ No EnemyHealth found in scene to heal!");
            }
        }

        // --- Buff ---
        if (cardStats.canBuff)
        {
            EnemyStats stats = FindObjectOfType<EnemyStats>();
            if (stats != null)
            {
                bool isAttackBuff = true; // or cardStats.buffIsAttack if you have it
                stats.ApplyBuff(isAttackBuff, cardStats.buffValue, cardStats.buffDuration);
            }
        }

        // --- Draw ---
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
