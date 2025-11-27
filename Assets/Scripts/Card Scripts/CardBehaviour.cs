using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardStats cardStats;

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
}
