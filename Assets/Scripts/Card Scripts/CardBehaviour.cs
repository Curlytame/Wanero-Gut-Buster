using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardStats cardStats;  // Reference to the ScriptableObject
    public int value = 5;        // The number used for damage/heal/buff/etc.

    public void PlayCard(GameObject target = null)
    {
        // Damage logic
        if (cardStats.canDamage && target != null && target.CompareTag("Enemy"))
        {
            EnemyHealth enemy = target.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(value);
            }

            
        }

        // Healing logic
        //if (cardStats.canHeal && target != null && target.CompareTag("Player"))
        /*
        {
            PlayerHealth player = target.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.Heal(value);
            }
        }*/

        // Draw card logic
        if (cardStats.canDrawCard)
        {
            cardStats.DoDrawCard(); 
        }

        // Buff logic
        if (cardStats.canBuff && target != null)
        {
            cardStats.DoBuff();
        }
    }


}
