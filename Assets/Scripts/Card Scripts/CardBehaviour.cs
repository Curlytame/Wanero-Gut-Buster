using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardStats cardStats;  // Reference to the ScriptableObject

    public void PlayCard(GameObject target = null)
    {
        if (cardStats == null) return;

        Debug.Log($"{cardStats.cardName} played! Energy cost: {cardStats.energyCost}");

        // Damage
        if (cardStats.canDamage && target != null && target.CompareTag("Enemy"))
        {
            EnemyHealth enemy = target.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(cardStats.damageValue);
            }
        }

        /* Heal
        if (cardStats.canHeal && target != null && target.CompareTag("Player"))
        {
            PlayerHealth player = target.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.Heal(cardStats.healValue);
            }
        }*/

        // Draw card(s)
        if (cardStats.canDrawCard)
        {
            Debug.Log($"Draw {cardStats.drawCount} card(s).");
            // TODO: Hook into GameManager.DrawCard() later
        }

        // Buff
        if (cardStats.canBuff && target != null)
        {
            Debug.Log($"Apply buff of {cardStats.buffValue} to {target.name}");
            // TODO: Hook into PlayerStats/EnemyStats
        }
    }
}
