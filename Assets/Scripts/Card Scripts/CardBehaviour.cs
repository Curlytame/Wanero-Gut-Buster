using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardStats cardStats;

    [Header("Visual Effects")]
    public GameObject attackEffectPrefab;

    private void OnMouseDown()
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.PlayClick();
    }

    public void PlayCard(GameObject target = null)
    {
        if (cardStats == null) return;

        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        GameManager gm = FindObjectOfType<GameManager>();

        // --- ENERGY ---
        if (cardStats.canGainEnergy && playerStats != null)
            playerStats.ModifyEnergy(cardStats.energyGainAmount);

        // --- DAMAGE ENEMY ---
        if (cardStats.canDamage && target != null && target.CompareTag("Enemy"))
        {
            int dmg = cardStats.damageValue + (playerStats != null ? playerStats.attackBonus : 0);

            EnemyHealth enemy = target.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(dmg);

                if (attackEffectPrefab != null)
                    Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);

                // 🔊 PLAYER ATTACK SOUND ONLY
                if (SoundManager.Instance != null)
                    SoundManager.Instance.PlayPlayerAttack();
            }
        }

        // --- HEAL ---
        if (cardStats.canHeal)
            FindObjectOfType<PlayerHealth>()?.Heal(cardStats.healValue);

        // --- DRAW ---
        if (cardStats.canDrawCard && gm != null)
            for (int i = 0; i < cardStats.drawCount; i++)
                gm.DrawCard();

        // --- BUFFS ---
        if (playerStats != null)
        {
            if (cardStats.canBuffAttack)
                playerStats.ApplyAttackBuff(cardStats.attackBuffValue, cardStats.attackBuffDuration);

            if (cardStats.canBuffDefense)
                playerStats.ApplyDefenseBuff(cardStats.defenseBuffValue, cardStats.defenseBuffDuration);
        }

        // --- DISCARD ---
        if (gm != null)
            gm.DiscardCard(gameObject);
        else
            Destroy(gameObject);
    }
}
