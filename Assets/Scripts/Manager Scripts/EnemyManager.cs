using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public EnemyStats enemyStats;

    [Header("References")]
    public Transform cardPlayArea;
    public EnemyHandManager handManager;
    public EnemyAI_BehaviorTree behaviorTree;

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

    [Header("Enemy Hand Preview (ADDED ONLY)")]
    public Transform previewAreaParent;
    public float previewSpacing = 2f;

    private readonly List<GameObject> previewInstances = new();

    // ================= PREVIEW =================

    public void GenerateNextHandPreview()
    {
        if (handManager == null) return;

        handManager.DrawHand();
        SpawnPreviewUI();
    }

    private void SpawnPreviewUI()
    {
        ClearPreviewUI();
        if (previewAreaParent == null) return;

        for (int i = 0; i < handManager.enemyHandIndexes.Count; i++)
        {
            int cardIndex = handManager.enemyHandIndexes[i];
            GameObject previewPrefab = handManager.GetPreviewPrefab(cardIndex);
            if (previewPrefab == null) continue;

            Vector3 pos = previewAreaParent.position + new Vector3(i * previewSpacing, 0, 0);
            GameObject instance = Instantiate(previewPrefab, pos, Quaternion.identity, previewAreaParent);
            previewInstances.Add(instance);
        }
    }

    private void ClearPreviewUI()
    {
        foreach (GameObject g in previewInstances)
            if (g != null) Destroy(g);

        previewInstances.Clear();
    }

    // ================= TURN LOGIC (UNCHANGED) =================

    public IEnumerator StartEnemyTurn(System.Action onTurnEnd)
    {
        Debug.Log("🔴 Enemy Turn Start");

        if (enemyStats != null)
        {
            enemyStats.TickBuffDurations();
            enemyStats.currentEnergy = enemyStats.maxEnergy;
            UpdateEnergyUI();
        }

        ClearPreviewUI();
        yield return new WaitForSeconds(startTurnDelay);

        if (behaviorTree == null)
        {
            Debug.LogError("❌ Behavior Tree is NOT assigned");
            onTurnEnd?.Invoke();
            yield break;
        }

        while (enemyStats.currentEnergy > 0)
        {
            behaviorTree.RunTree();
            yield return new WaitForSeconds(actionInterval);

            if (!handManager.HasPlayableAttack(enemyStats.currentEnergy) &&
                !handManager.HasPlayableBuff(enemyStats.currentEnergy))
                break;
        }

        if (enemyStats != null)
            enemyStats.TickBuffDurations();

        Debug.Log("⚪ Enemy Turn End");
        onTurnEnd?.Invoke();
    }

    // ================= BEHAVIOR TREE HELPERS (UNCHANGED) =================

    public bool HasBuffCardInHand()
    {
        return handManager != null && handManager.HasPlayableBuff(enemyStats.currentEnergy);
    }

    public bool HasAttackCardInHand()
    {
        return handManager != null && handManager.HasPlayableAttack(enemyStats.currentEnergy);
    }

    public void UseBuffCardFromHand()
    {
        PlayCard(handManager.GetPlayableBuffCard(enemyStats.currentEnergy));
    }

    public void PlayAttackCardFromHand()
    {
        PlayCard(handManager.GetPlayableAttackCard(enemyStats.currentEnergy));
    }

    private void PlayCard(GameObject prefab)
    {
        if (prefab == null || enemyStats == null) return;

        EnemyCardBehaviour card = prefab.GetComponent<EnemyCardBehaviour>();
        if (card == null || card.cardStats == null) return;

        enemyStats.currentEnergy -= card.cardStats.energyCost;
        UpdateEnergyUI();

        Instantiate(prefab, cardPlayArea.position, Quaternion.identity);
        handManager.RemoveCardFromHand(prefab);

        if (cardPlayEffectPrefab != null && effectSpawnPoint != null)
            StartCoroutine(SpawnCardEffect(effectSpawnPoint.position));
    }

    private IEnumerator SpawnCardEffect(Vector3 spawnPos)
    {
        GameObject effect = Instantiate(cardPlayEffectPrefab, spawnPos, Quaternion.identity);
        SpriteRenderer sr = effect.GetComponent<SpriteRenderer>();
        Color startColor = sr != null ? sr.color : Color.white;

        float timer = 0f;
        while (timer < effectFadeDuration)
        {
            effect.transform.position += Vector3.up * effectRiseSpeed * Time.deltaTime;
            if (sr != null)
                sr.color = new Color(startColor.r, startColor.g, startColor.b,
                    Mathf.Lerp(1f, 0f, timer / effectFadeDuration));

            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(effect);
    }

    private void UpdateEnergyUI()
    {
        if (energyText != null && enemyStats != null)
            energyText.text = $"Enemy Energy: {enemyStats.currentEnergy} / {enemyStats.maxEnergy}";
    }
}
