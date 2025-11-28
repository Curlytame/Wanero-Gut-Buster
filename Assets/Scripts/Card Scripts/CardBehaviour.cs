using UnityEngine;
using System.Collections;

public class CardBehaviour : MonoBehaviour
{
    public CardStats cardStats;

    [Header("Visual Effects")]
    public GameObject attackEffectPrefab;
    public float effectRiseSpeed = 1f;
    public float effectFadeDuration = 1f;

    public void PlayCard(GameObject target = null)
    {
        if (cardStats == null)
        {
            Debug.LogWarning("⚠️ CardStats not assigned!");
            return;
        }

        Debug.Log($"{cardStats.cardName} played! Cost: {cardStats.energyCost}");

        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        GameManager gm = FindObjectOfType<GameManager>();

        // --- Damage ---
        if (cardStats.canDamage && target != null && target.CompareTag("Enemy"))
        {
            int totalDamage = cardStats.damageValue;
            if (playerStats != null)
                totalDamage += playerStats.attackBonus;

            EnemyHealth enemy = target.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(totalDamage);
                Debug.Log($"💥 {cardStats.cardName} dealt {totalDamage} damage.");

                // Spawn attack effect
                if (attackEffectPrefab != null)
                    StartCoroutine(SpawnAttackEffect(transform.position));

                // Play player attack sound
                if (SoundManager.Instance != null)
                    SoundManager.Instance.PlaySound(SoundManager.Instance.playerAttackSound);
            }
        }

        // --- Heal ---
        if (cardStats.canHeal)
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(cardStats.healValue);
                Debug.Log($"💚 Player healed {cardStats.healValue} HP.");
            }
        }

        // --- Draw Cards ---
        if (cardStats.canDrawCard && gm != null)
        {
            Debug.Log($"🃏 Drawing {cardStats.drawCount} card(s).");
            for (int i = 0; i < cardStats.drawCount; i++)
                gm.DrawCard();
        }

        // --- Buffs ---
        if (playerStats != null)
        {
            if (cardStats.canBuffAttack)
                playerStats.ApplyAttackBuff(cardStats.attackBuffValue, cardStats.attackBuffDuration);

            if (cardStats.canBuffDefense)
                playerStats.ApplyDefenseBuff(cardStats.defenseBuffValue, cardStats.defenseBuffDuration);
        }

        // --- Discard ---
        if (gm != null)
        {
            gm.DiscardCard(gameObject);
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private IEnumerator SpawnAttackEffect(Vector3 spawnPos)
    {
        if (attackEffectPrefab == null)
            yield break;

        // Instantiate effect
        GameObject effect = Instantiate(attackEffectPrefab, spawnPos, Quaternion.identity);
        SpriteRenderer sr = effect.GetComponent<SpriteRenderer>();
        Color startColor = sr != null ? sr.color : Color.white;

        float timer = 0f;

        while (timer < effectFadeDuration)
        {
            // Move effect upward
            effect.transform.position += Vector3.up * effectRiseSpeed * Time.deltaTime;

            // Fade out if sprite renderer exists
            if (sr != null)
            {
                float alpha = Mathf.Lerp(1f, 0f, timer / effectFadeDuration);
                sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure destroyed at the end
        if (effect != null)
            Destroy(effect);
    }
}
