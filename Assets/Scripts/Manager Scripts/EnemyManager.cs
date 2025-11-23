using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public EnemyStats enemyStats;                  // Reference to enemy stats (energy, HP, etc.)
    public Transform cardPlayArea;                 // Where to spawn cards when played
    public List<GameObject> enemyCardPrefabs;      // The possible cards enemy can play

    [Header("Timing")]
    public float cardPlayInterval = 1f;            // Time between plays

    public IEnumerator StartEnemyTurn(System.Action onTurnEnd)
    {
        Debug.Log("🔴 Enemy Turn Start");

        // Restore energy
        enemyStats.currentEnergy = enemyStats.maxEnergy;
        Debug.Log($"Enemy Energy Restored: {enemyStats.currentEnergy}/{enemyStats.maxEnergy}");

        // Enemy plays cards until energy runs out
        foreach (var cardPrefab in enemyCardPrefabs)
        {
            if (enemyStats.currentEnergy <= 0)
            {
                Debug.Log("Enemy out of energy!");
                break;
            }

            // Check card cost
            EnemyCardBehaviour cardBehaviour = cardPrefab.GetComponent<EnemyCardBehaviour>();
            if (cardBehaviour == null || cardBehaviour.cardStats == null)
                continue;

            int cost = cardBehaviour.cardStats.energyCost;
            if (enemyStats.currentEnergy < cost)
            {
                Debug.Log($"Not enough energy for {cardBehaviour.cardStats.cardName}");
                continue;
            }

            // Spend energy
            enemyStats.currentEnergy -= cost;
            Debug.Log($"Enemy plays {cardBehaviour.cardStats.cardName} (Cost: {cost}) | Remaining Energy: {enemyStats.currentEnergy}");

            // Instantiate and play card
            GameObject cardInstance = Instantiate(cardPrefab, cardPlayArea.position, Quaternion.identity);
            yield return new WaitForSeconds(cardPlayInterval); // Wait before next card
        }

        Debug.Log("🔴 Enemy Turn End");
        yield return new WaitForSeconds(1f); // Small buffer before switching turns
        onTurnEnd?.Invoke();
    }
}
