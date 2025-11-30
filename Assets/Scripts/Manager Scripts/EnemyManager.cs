using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public float startTurnDelay = 1f;   // ⭐ New delay before enemy starts acting
    public float cardPlayInterval = 1f;

    public IEnumerator StartEnemyTurn(System.Action onTurnEnd)
    {
        Debug.Log("🔴 Enemy Turn Start");

        // ⭐ WAIT before playing cards
        yield return new WaitForSeconds(startTurnDelay);

        // Restore energy
        enemyStats.currentEnergy = enemyStats.maxEnergy;
        Debug.Log($"Enemy Energy Restored: {enemyStats.currentEnergy}/{enemyStats.maxEnergy}");

        foreach (var cardPrefab in enemyCardPrefabs)
        {
            if (enemyStats.currentEnergy <= 0)
            {
                Debug.Log("Enemy out of energy!");
                break;
            }

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
            Debug.Log($"Enemy plays {cardBehaviour.cardStats.cardName}  (Cost: {cost}) | Remaining Energy: {enemyStats.currentEnergy}");

            // Spawn card
            GameObject cardInstance = Instantiate(cardPrefab, cardPlayArea.position, Quaternion.identity);

            // Spawn visual effect
            if (cardPlayEffectPrefab != null && effectSpawnPoint != null)
            {
                StartCoroutine(SpawnCardEffect(effectSpawnPoint.position));

                // Play fire/attack sound
                if (SoundManager.Instance != null)
                    SoundManager.Instance.PlaySound(SoundManager.Instance.enemyAttackSound);
            }

            yield return new WaitForSeconds(cardPlayInterval);
        }

        Debug.Log("🔴 Enemy Turn End");
        yield return new WaitForSeconds(1f);
        onTurnEnd?.Invoke();
    }

    private IEnumerator SpawnCardEffect(Vector3 spawnPos)
    {
        GameObject effect = Instantiate(cardPlayEffectPrefab, spawnPos, Quaternion.identity);
        SpriteRenderer sr = effect.GetComponent<SpriteRenderer>();
        Color startColor = sr != null ? sr.color : Color.white;

        // Play fire sound effect
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
}
