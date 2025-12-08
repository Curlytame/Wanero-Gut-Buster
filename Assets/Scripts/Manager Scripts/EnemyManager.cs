using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public EnemyStats enemyStats;
    public Transform cardPlayArea; 
    public List<GameObject> enemyCardPrefabs;

    [Header("Behavior Tree Reference")]
    public EnemyAI_BehaviorTree behaviorTree;   // Drag Behavior Tree object here

    [Header("Visual Effects")]
    public GameObject cardPlayEffectPrefab;
    public Transform effectSpawnPoint;
    public float effectRiseSpeed = 1.5f;
    public float effectFadeDuration = 1f;

    [Header("Timing")]
    public float startTurnDelay = 1f;
    public float actionInterval = 1f;

    [Header("UI")]
    public TextMeshProUGUI energyText;

    // ---------------------- TURN LOGIC ----------------------
    public IEnumerator StartEnemyTurn(System.Action onTurnEnd)
    {
        Debug.Log("🔴 Enemy Turn Start");

        if (enemyStats != null)
        {
            enemyStats.TickBuffDurations();
            enemyStats.currentEnergy = enemyStats.maxEnergy;
            UpdateEnergyUI();
        }

        yield return new WaitForSeconds(startTurnDelay);

        if (behaviorTree == null)
        {
            Debug.LogError("❌ Behavior Tree is NOT assigned in EnemyManager");
            onTurnEnd?.Invoke();
            yield break;
        }

        // Run Behavior Tree while enemy has energy
        while (enemyStats.currentEnergy > 0)
        {
            behaviorTree.RunTree(); // This should trigger AI nodes
            yield return new WaitForSeconds(actionInterval);

            // Safety check: stop if no cards can be played
            if (!HasAttackCard() && !HasBuffCard())
                break;
        }

        if (enemyStats != null)
            enemyStats.TickBuffDurations();

        yield return new WaitForSeconds(1f);

        Debug.Log("⚪ Enemy Turn End");
        onTurnEnd?.Invoke();
    }

    // ---------------------- BEHAVIOR TREE HELPERS ----------------------
    public bool HasBuffCard()
    {
        foreach (Transform child in cardPlayArea)
        {
            EnemyCardBehaviour card = child.GetComponent<EnemyCardBehaviour>();
            if (card != null && card.cardStats != null &&
                card.cardStats.cardType == EnemyCardType.Buff &&
                enemyStats.currentEnergy >= card.cardStats.energyCost)
                return true;
        }
        return false;
    }

    public bool HasAttackCard()
    {
        foreach (Transform child in cardPlayArea)
        {
            EnemyCardBehaviour card = child.GetComponent<EnemyCardBehaviour>();
            if (card != null && card.cardStats != null &&
                card.cardStats.cardType == EnemyCardType.Attack &&
                enemyStats.currentEnergy >= card.cardStats.energyCost)
                return true;
        }
        return false;
    }

    public void UseBuffCard()
    {
        for (int i = 0; i < cardPlayArea.childCount; i++)
        {
            Transform child = cardPlayArea.GetChild(i);
            EnemyCardBehaviour card = child.GetComponent<EnemyCardBehaviour>();

            if (card != null && card.cardStats != null &&
                card.cardStats.cardType == EnemyCardType.Buff &&
                enemyStats.currentEnergy >= card.cardStats.energyCost)
            {
                enemyStats.currentEnergy -= card.cardStats.energyCost;
                UpdateEnergyUI();
                Debug.Log($"💠 Played Buff Card: {card.cardStats.cardName}");
                Destroy(child.gameObject); // Remove card from hand
                break;
            }
        }
    }

    public void PlayAttackCard()
    {
        for (int i = 0; i < cardPlayArea.childCount; i++)
        {
            Transform child = cardPlayArea.GetChild(i);
            EnemyCardBehaviour card = child.GetComponent<EnemyCardBehaviour>();

            if (card != null && card.cardStats != null &&
                card.cardStats.cardType == EnemyCardType.Attack &&
                enemyStats.currentEnergy >= card.cardStats.energyCost)
            {
                enemyStats.currentEnergy -= card.cardStats.energyCost;
                UpdateEnergyUI();
                Debug.Log($"⚔️ Played Attack Card: {card.cardStats.cardName}");
                Destroy(child.gameObject); // Remove card from hand
                break;
            }
        }
    }

    // ---------------------- VFX + SPAWN ----------------------
    private void UpdateEnergyUI()
    {
        if (energyText != null && enemyStats != null)
            energyText.text = $"Enemy Energy: {enemyStats.currentEnergy} / {enemyStats.maxEnergy}";
    }
}
