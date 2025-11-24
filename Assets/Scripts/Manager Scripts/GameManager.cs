using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Card Settings")]
    public List<GameObject> deckList; // Prefabs set in Inspector
    public int startingHandSize = 5;

    [Header("References")]
    public HandManager handManager;
    public PlayerStats playerStats;

    private List<GameObject> deck = new List<GameObject>(); // runtime deck
    private List<GameObject> discardPile = new List<GameObject>(); // runtime discard (prefab refs only)

    private void Start()
    {
        CreateDeck();
        ShuffleDeck();
        DrawStartingHand();
    }

    private void CreateDeck()
    {
        deck.Clear();
        foreach (GameObject cardPrefab in deckList)
        {
            if (cardPrefab != null)
                deck.Add(cardPrefab);
        }
        Debug.Log($"Deck created with {deck.Count} cards.");
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int rand = Random.Range(i, deck.Count);
            (deck[i], deck[rand]) = (deck[rand], deck[i]);
        }
        Debug.Log("Deck shuffled!");
    }

    private void DrawStartingHand()
    {
        int drawCount = Mathf.Min(startingHandSize, playerStats.cardLimit);
        for (int i = 0; i < drawCount; i++)
            DrawCard();
    }

    public void DrawCard()
    {
        if (deck.Count == 0)
        {
            if (discardPile.Count > 0)
            {
                Debug.Log("Deck empty — reshuffling discard pile!");
                ReshuffleDiscardPile();
            }
            else
            {
                Debug.LogWarning("No cards left to draw — both deck and discard empty!");
                return;
            }
        }

        if (handManager.CurrentHandSize >= playerStats.cardLimit)
        {
            Debug.Log("Hand is full! Can't draw more cards.");
            return;
        }

        // Take top card prefab
        GameObject cardPrefab = deck[0];
        deck.RemoveAt(0);

        if (cardPrefab == null)
        {
            Debug.LogWarning("Card prefab reference missing — skipping draw.");
            return;
        }

        GameObject cardObj = Instantiate(cardPrefab);
        Card card = cardObj.GetComponent<Card>();
        handManager.AddCardToHand(card);
    }

    // 🟢 Called when a card is played
    public void DiscardCard(GameObject card)
    {
        if (card == null) return;

        // Keep prefab reference instead of destroyed instance
        GameObject prefabRef = GetCardPrefabReference(card);
        if (prefabRef != null)
        {
            discardPile.Add(prefabRef);
        }
        else
        {
            Debug.LogWarning($"Card {card.name} does not have a valid prefab reference!");
        }

        Destroy(card);
    }

    private void ReshuffleDiscardPile()
    {
        deck.AddRange(discardPile);
        discardPile.Clear();
        ShuffleDeck();
        Debug.Log("Deck reshuffled from discard pile!");
    }

    // Helper to get prefab reference (based on name match or ScriptableObject link)
    private GameObject GetCardPrefabReference(GameObject cardInstance)
    {
        string nameToFind = cardInstance.name.Replace("(Clone)", "").Trim();
        return deckList.Find(c => c.name == nameToFind);
    }
}
