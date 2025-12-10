using System.Collections.Generic;
using UnityEngine;

public class EnemyHandManager : MonoBehaviour
{
    [Header("Card Settings")]
    public List<GameObject> enemyCardPrefabs = new List<GameObject>();
    public int startingHandSize = 5;

    [HideInInspector]
    public List<GameObject> enemyHand = new List<GameObject>();

    public void DrawHand(int count = -1)
    {
        enemyHand.Clear();

        if (enemyCardPrefabs == null || enemyCardPrefabs.Count == 0)
        {
            Debug.LogError("EnemyHandManager: No enemyCardPrefabs assigned!");
            return;
        }

        int drawCount = count > 0 ? count : startingHandSize;

        for (int i = 0; i < drawCount; i++)
        {
            int rand = Random.Range(0, enemyCardPrefabs.Count);
            enemyHand.Add(enemyCardPrefabs[rand]);
        }

        Debug.Log($"EnemyHandManager: drew {enemyHand.Count} cards.");
    }

    public void DrawHandForNextTurn()
    {
        DrawHand();
    }

    public GameObject GetPlayableAttackCard(int currentEnergy)
    {
        foreach (var prefab in enemyHand)
        {
            if (prefab == null) continue;

            var card = prefab.GetComponent<EnemyCardBehaviour>();
            if (card == null || card.cardStats == null) continue;

            if (card.cardStats.cardType == EnemyCardType.Attack &&
                card.cardStats.energyCost <= currentEnergy)
                return prefab;
        }
        return null;
    }

    public GameObject GetPlayableBuffCard(int currentEnergy)
    {
        foreach (var prefab in enemyHand)
        {
            if (prefab == null) continue;

            var card = prefab.GetComponent<EnemyCardBehaviour>();
            if (card == null || card.cardStats == null) continue;

            if (card.cardStats.cardType == EnemyCardType.Buff &&
                card.cardStats.energyCost <= currentEnergy)
                return prefab;
        }
        return null;
    }

    public void RemoveCardFromHand(GameObject prefab)
    {
        if (prefab == null) return;
        if (enemyHand.Contains(prefab))
            enemyHand.Remove(prefab);
    }

    public bool HasPlayableAttack(int currentEnergy) => GetPlayableAttackCard(currentEnergy) != null;
    public bool HasPlayableBuff(int currentEnergy) => GetPlayableBuffCard(currentEnergy) != null;
}
