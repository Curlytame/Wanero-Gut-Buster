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

    [Header("Visual Effects")]
    public GameObject cardPlayEffectPrefab;
    public Transform effectSpawnPoint;
    public float effectRiseSpeed = 1.5f;
    public float effectFadeDuration = 1f;

    [Header("Timing")]
    public float startTurnDelay = 1f;
    public float cardPlayInterval = 1f;

    [Header("UI")]
    public TextMeshProUGUI energyText;

    public IEnumerator StartEnemyTurn(System.Action onTurnEnd)
    {
        Debug.Log("🔴 Enemy Turn Start");

        // Tick buffs at the start of enemy turn
        if (enemyStats != null)
            enemyStats.TickBuffDurations();

        yield return new WaitForSeconds(startTurnDelay);

        // Reset energy
        enemyStats.currentEnergy = enemyStats.maxEnergy;
        UpdateEnergyUI();
        Debug.Log($"Enemy Energy Reset: {enemyStats.currentEnergy}/{enemyStats.maxEnergy}");

        // Play cards
        foreach (var cardPrefab in enemyCardPrefabs)
        {
            if (enemyStats.currentEnergy <= 0)
            {
                Debug.Log("Enemy ran out of energy!");
                break;
            }

            EnemyCardBehaviour cardBehaviour = cardPrefab.GetComponent<EnemyCardBehaviour>();
            if (cardBehaviour == null || cardBehaviour.cardStats == null)
                continue;

            int cost = cardBehaviour.cardStats.energyCost;

            if (enemyStats.currentEnergy < cost)
            {
                Debug.Log($"⚠️ Not enough energy for {cardBehaviour.cardStats.cardName} (Cost: {cost})");
                continue;
            }

            enemyStats.currentEnergy -= cost;
            UpdateEnergyUI();
            Debug.Log($"Enemy plays {cardBehaviour.cardStats.cardName}  (Cost: {cost}) | Remaining Energy: {enemyStats.currentEnergy}");

            // Spawn card
            GameObject cardInstance = Instantiate(cardPrefab, cardPlayArea.position, Quaternion.identity);

            // Spawn effect
            if (cardPlayEffectPrefab != null && effectSpawnPoint != null)
                StartCoroutine(SpawnCardEffect(effectSpawnPoint.position));

            yield return new WaitForSeconds(cardPlayInterval);
        }

        Debug.Log("🔴 Enemy Turn End");

        // Optional: Tick buffs again at the end of turn
        if (enemyStats != null)
            enemyStats.TickBuffDurations();

        yield return new WaitForSeconds(1f);

        onTurnEnd?.Invoke();
    }

    private IEnumerator SpawnCardEffect(Vector3 spawnPos)
    {
        GameObject effect = Instantiate(cardPlayEffectPrefab, spawnPos, Quaternion.identity);
        SpriteRenderer sr = effect.GetComponent<SpriteRenderer>();
        Color startColor = sr != null ? sr.color : Color.white;

        if (SoundManager.Instance != null)
            SoundManager.Instance.PlaySound(SoundManager.Instance.fireEffectSound);

        float timer = 0f;
        while (timer < effectFadeDuration)
        {
            effect.transform.position += Vector3.up * effectRiseSpeed * Time.deltaTime;

            if (sr != null)
                sr.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(1f, 0f, timer / effectFadeDuration));

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(effect);
    }

    private void UpdateEnergyUI()
    {
        if (energyText != null)
            energyText.text = $"Enemy Energy: {enemyStats.currentEnergy} / {enemyStats.maxEnergy}";
    }
}
