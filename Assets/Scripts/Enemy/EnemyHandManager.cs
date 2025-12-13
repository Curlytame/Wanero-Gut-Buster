using System.Collections.Generic;
using UnityEngine;

public class EnemyHandManager : MonoBehaviour
{
    [Header("Card Pool")]
    public List<GameObject> enemyCardPrefabs = new List<GameObject>();
    public int startingHandSize = 5;

    [HideInInspector]
    public List<GameObject> enemyHand = new List<GameObject>();

    public void DrawHandForNextTurn()
    {
        enemyHand.Clear();

        if (enemyCardPrefabs == null || enemyCardPrefabs.Count == 0)
        {
            Debug.LogError("EnemyHandManager: No card prefabs assigned");
            return;
        }

        for (int i = 0; i < startingHandSize; i++)
        {
            int r = Random.Range(0, enemyCardPrefabs.Count);
            enemyHand.Add(enemyCardPrefabs[r]);
        }
    }

    public GameObject GetPlayableAttackCard(int energy)
    {
        foreach (GameObject prefab in enemyHand)
        {
            if (prefab == null) continue;

            EnemyCardBehaviour card = prefab.GetComponent<EnemyCardBehaviour>();
            if (card == null || card.cardStats == null) continue;

            if (card.cardStats.cardType == EnemyCardType.Attack &&
                card.cardStats.energyCost <= energy)
                return prefab;
        }

        return null;
    }

    public GameObject GetPlayableBuffCard(int energy)
    {
        foreach (GameObject prefab in enemyHand)
        {
            if (prefab == null) continue;

            EnemyCardBehaviour card = prefab.GetComponent<EnemyCardBehaviour>();
            if (card == null || card.cardStats == null) continue;

            if (card.cardStats.cardType == EnemyCardType.Buff &&
                card.cardStats.energyCost <= energy)
                return prefab;
        }

        return null;
    }

    public void RemoveCardFromHand(GameObject card)
    {
        if (card != null && enemyHand.Contains(card))
            enemyHand.Remove(card);
    }

    public bool HasPlayableAttack(int energy)
    {
        return GetPlayableAttackCard(energy) != null;
    }

    public bool HasPlayableBuff(int energy)
    {
        return GetPlayableBuffCard(energy) != null;
    }
}
