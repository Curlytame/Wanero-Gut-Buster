using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SpawnCard : MonoBehaviour
{
    public List<GameObject> cardPrefabs;      // Assign your card prefabs in inspector
    public RectTransform cardSpawnRect;       // Where to spawn the card

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button or screen tap
        {
            SpawnRandomCard();
        }
    }

    void SpawnRandomCard()
    {
        if (cardPrefabs.Count == 0 || cardSpawnRect == null)
        {
            Debug.LogWarning("No card prefabs or spawn rect assigned.");
            return;
        }

        GameObject prefab = cardPrefabs[Random.Range(0, cardPrefabs.Count)];
        GameObject newCard = Instantiate(prefab);
        RectTransform newCardRect = newCard.GetComponent<RectTransform>();

        // Set parent to spawn rect without changing world position or scale
        newCardRect.SetParent(cardSpawnRect, worldPositionStays: true);
        newCardRect.localScale = Vector3.one;

        // Optionally reset anchored position to zero inside spawn rect
        newCardRect.anchoredPosition = Vector2.zero;

        Debug.Log("Spawned card: " + prefab.name);
    }
}
