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

    [Header("Card Preview (NEW)")]
    public Transform previewAreaParent;           // empty GameObject where previews spawn
    public List<GameObject> enemyPreviewPrefabs;  // ⭐ list of preview prefabs (visuals only)
    public float previewSpacing = 2f;

    private readonly List<GameObject> previewInstances = new List<GameObject>();

    // ---------------------- TURN LOGIC ----------------------
    public void GenerateNextHandPreview()
    {
        if (handManager == null) return;

        handManager.DrawHandForNextTurn();
        SpawnPreviewHandUI();
    }

    private void SpawnPreviewHandUI()
    {
        ClearPreviewUI();

        if (previewAreaParent == null) return;
        if (handManager.enemyHand.Count == 0) return;

        for (int i = 0; i < handManager.enemyHand.Count; i++)
        {
            GameObject playableCardPrefab = handManager.enemyHand[i];
            if (playableCardPrefab == null) continue;

            // 🔹 Use preview prefab by position (i)
            if (i >= enemyPreviewPrefabs.Count)
            {
                Debug.LogWarning($"No preview prefab assigned for card index {i}, skipping preview");
                continue;
            }

            GameObject previewPrefab = enemyPreviewPrefabs[i];

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

    public IEnumerator StartEnemyTurn(System.Action onTurnEnd)
    {
        Debug.Log("🔴 Enemy Turn Start");

        if (enemyStats != null)
        {
            enemyStats.TickBuffDurations();
            enemyStats.currentEnergy = enemyStats.maxEnergy;
            UpdateEnergyUI();
        }

        // ✅ Remove preview, playable cards will be used now
        ClearPreviewUI();

        yield return new WaitForSeconds(startTurnDelay);

        if (behaviorTree == null)
        {
            Debug.LogError("❌ Behavior Tree Missing");
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

        yield return new WaitForSeconds(1f);

        Debug.Log("⚪ Enemy Turn End");
        onTurnEnd?.Invoke();
    }

    // ---------------------- BEHAVIOR NODE HELPERS ----------------------
    public bool HasBuffCardInHand()
    {
        if (handManager == null || enemyStats == null) return false;
        return handManager.HasPlayableBuff(enemyStats.currentEnergy);
    }

    public bool HasAttackCardInHand()
    {
        if (handManager == null || enemyStats == null) return false;
        return handManager.HasPlayableAttack(enemyStats.currentEnergy);
    }

    public void UseBuffCardFromHand()
    {
        if (handManager == null || enemyStats == null) return;

        GameObject prefab = handManager.GetPlayableBuffCard(enemyStats.currentEnergy);
        if (prefab == null) return;

        EnemyCardBehaviour cardComp = prefab.GetComponent<EnemyCardBehaviour>();
        if (cardComp == null || cardComp.cardStats == null) return;

        enemyStats.currentEnergy -= cardComp.cardStats.energyCost;
        UpdateEnergyUI();

        Vector3 spawnPos = cardPlayArea != null ? cardPlayArea.position : transform.position;
        Instantiate(prefab, spawnPos, Quaternion.identity);

        handManager.RemoveCardFromHand(prefab);

        if (cardPlayEffectPrefab != null && effectSpawnPoint != null)
            StartCoroutine(SpawnCardEffect(effectSpawnPoint.position));

        Debug.Log($"💠 Enemy used buff card: {cardComp.cardStats.cardName}");
    }

    public void PlayAttackCardFromHand()
    {
        if (handManager == null || enemyStats == null) return;

        GameObject prefab = handManager.GetPlayableAttackCard(enemyStats.currentEnergy);
        if (prefab == null) return;

        EnemyCardBehaviour cardComp = prefab.GetComponent<EnemyCardBehaviour>();
        if (cardComp == null || cardComp.cardStats == null) return;

        enemyStats.currentEnergy -= cardComp.cardStats.energyCost;
        UpdateEnergyUI();

        Vector3 spawnPos = cardPlayArea != null ? cardPlayArea.position : transform.position;
        Instantiate(prefab, spawnPos, Quaternion.identity);

        handManager.RemoveCardFromHand(prefab);

        if (cardPlayEffectPrefab != null && effectSpawnPoint != null)
            StartCoroutine(SpawnCardEffect(effectSpawnPoint.position));

        Debug.Log($"⚔️ Enemy played attack card: {cardComp.cardStats.cardName}");
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
