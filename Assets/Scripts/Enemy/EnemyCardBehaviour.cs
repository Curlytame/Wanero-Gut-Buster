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

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (cardStats == null)
        {
            Debug.LogWarning($"⚠️ No CardStats on {gameObject.name}");
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
        Debug.Log($"{cardStats.cardName} played by enemy!");

        // --- DAMAGE PLAYER ---
        if (cardStats.canDamage && target != null && target.CompareTag("Player"))
        {
            PlayerHealth player = target.GetComponent<PlayerHealth>();
            PlayerStats playerStats = target.GetComponent<PlayerStats>();
            EnemyStats enemyStats = FindObjectOfType<EnemyStats>();

            int enemyAtk = enemyStats != null ? enemyStats.attackBonus : 0;
            int playerDef = playerStats != null ? playerStats.defence : 0;

            int totalDamage = Mathf.Max(0, (cardStats.damageValue + enemyAtk) - playerDef);
            player?.TakeDamage(totalDamage);

            // 🔊 ENEMY ATTACK SOUND (FIX)
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlayEnemyAttack();

            Debug.Log($"💥 Enemy dealt {totalDamage} damage");
        }

        // --- HEAL ENEMY ---
        if (cardStats.canHeal)
        {
            EnemyHealth enemyHealth = FindObjectOfType<EnemyHealth>();
            enemyHealth?.Heal(cardStats.healValue);
        }

        // --- BUFF ---
        if (cardStats.canBuff)
        {
            EnemyStats stats = FindObjectOfType<EnemyStats>();
            if (stats != null)
                stats.ApplyBuff(true, cardStats.buffValue, cardStats.buffDuration);
        }
    }

    private IEnumerator FadeOut()
    {
        if (spriteRenderer == null) yield break;

        Color startColor = spriteRenderer.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            float a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, a);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
