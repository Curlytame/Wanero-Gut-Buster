using System.Collections.Generic;
using UnityEngine;

public class EnemyHandManager : MonoBehaviour
{
    [Header("Playable Enemy Card Prefabs (Logic)")]
    public List<GameObject> enemyCardPrefabs = new List<GameObject>();

    [Header("Enemy Card Preview Prefabs (Visual Only)")]
    public List<GameObject> enemyCardPreviewPrefabs = new List<GameObject>();

    public int startingHandSize = 5;

    // Store INDEXES so preview + playable always match
    [HideInInspector]
    public List<int> enemyHandIndexes = new List<int>();

    public void DrawHand()
    {
        enemyHandIndexes.Clear();

        if (enemyCardPrefabs == null || enemyCardPrefabs.Count == 0)
        {
            Debug.LogError("EnemyHandManager: No enemyCardPrefabs assigned!");
            return;
        }

        for (int i = 0; i < startingHandSize; i++)
        {
            int randIndex = Random.Range(0, enemyCardPrefabs.Count);
            enemyHandIndexes.Add(randIndex);
        }

        Debug.Log($"EnemyHandManager: drew {enemyHandIndexes.Count} cards.");
    }

    public GameObject GetPlayableAttackCard(int currentEnergy)
    {
        foreach (int index in enemyHandIndexes)
        {
            GameObject prefab = enemyCardPrefabs[index];
            if (prefab == null) continue;

            EnemyCardBehaviour card = prefab.GetComponent<EnemyCardBehaviour>();
            if (card == null || card.cardStats == null) continue;

            if (card.cardStats.cardType == EnemyCardType.Attack &&
                card.cardStats.energyCost <= currentEnergy)
                return prefab;
        }
        return null;
    }

    public GameObject GetPlayableBuffCard(int currentEnergy)
    {
        foreach (int index in enemyHandIndexes)
        {
            GameObject prefab = enemyCardPrefabs[index];
            if (prefab == null) continue;

            EnemyCardBehaviour card = prefab.GetComponent<EnemyCardBehaviour>();
            if (card == null || card.cardStats == null) continue;

            if (card.cardStats.cardType == EnemyCardType.Buff &&
                card.cardStats.energyCost <= currentEnergy)
                return prefab;
        }
        return null;
    }

    public void RemoveCardFromHand(GameObject prefab)
    {
        int index = enemyCardPrefabs.IndexOf(prefab);
        if (index >= 0)
            enemyHandIndexes.Remove(index);
    }

    public bool HasPlayableAttack(int energy) => GetPlayableAttackCard(energy) != null;
    public bool HasPlayableBuff(int energy) => GetPlayableBuffCard(energy) != null;

    // 🔑 Preview access by SAME index
    public GameObject GetPreviewPrefab(int index)
    {
        if (index < 0 || index >= enemyCardPreviewPrefabs.Count)
            return null;

        return enemyCardPreviewPrefabs[index];
    }
}
