using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardStats cardStats;  // Reference to the ScriptableObject

    public void PlayCard(GameObject target = null)
    {
        if (cardStats == null)
        {
            Debug.LogWarning("⚠️ CardStats not assigned!");
            return;
        }

        Debug.Log($"{cardStats.cardName} played! Energy cost: {cardStats.energyCost}");

        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        GameManager gm = FindObjectOfType<GameManager>();

        // 🟥 Damage
        if (cardStats.canDamage && target != null && target.CompareTag("Enemy"))
        {
            int totalDamage = cardStats.damageValue;
            if (playerStats != null)
                totalDamage += playerStats.attackBonus;

            EnemyHealth enemy = target.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(totalDamage);
                Debug.Log($"💥 {cardStats.cardName} dealt {totalDamage} damage (base {cardStats.damageValue} + bonus {playerStats.attackBonus}).");
            }
        }

        // 💚 Heal
        if (cardStats.canHeal)
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(cardStats.healValue);
                Debug.Log($"💚 Player healed for {cardStats.healValue} HP.");
            }
        }

        // 🟦 Draw cards
        if (cardStats.canDrawCard && gm != null)
        {
            Debug.Log($"🃏 Drawing {cardStats.drawCount} card(s).");
            for (int i = 0; i < cardStats.drawCount; i++)
                gm.DrawCard();
        }

        // 🟩 Buff
        if (cardStats.canBuff && playerStats != null)
        {
            playerStats.ApplyBuff(cardStats.buffValue, cardStats.buffDuration);
        }

        // 🔻 Discard Card after play
        if (gm != null)
        {
            gm.DiscardCard(gameObject);
        }
        else
        {
            Debug.LogWarning("⚠️ GameManager not found! Could not discard card.");
            Destroy(gameObject, 0.5f);
        }
    }
}
