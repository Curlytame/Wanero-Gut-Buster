using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Card Settings")]
    public List<GameObject> deckList; // Drag prefabs of cards here in Inspector
    public int startingHandSize = 5;

    [Header("References")]
    public HandManager handManager;
    public PlayerStats playerStats; // To use cardLimit

    private List<GameObject> deck = new List<GameObject>(); // runtime deck

    private void Start()
    {
        CreateDeck();
        ShuffleDeck();
        DrawStartingHand();
    }

    private void CreateDeck()
    {
        deck.Clear();

        // Copy deckList into deck (so we don't modify the Inspector list at runtime)
        foreach (GameObject cardPrefab in deckList)
        {
            if (cardPrefab != null)
            {
                deck.Add(cardPrefab);
            }
        }

        Debug.Log($"Deck created with {deck.Count} cards.");
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int rand = Random.Range(i, deck.Count);
            GameObject temp = deck[i];
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }

    private void DrawStartingHand()
    {
        int drawCount = Mathf.Min(startingHandSize, playerStats.cardLimit);
        for (int i = 0; i < drawCount; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (deck.Count > 0)
        {
            if (handManager.CurrentHandSize >= playerStats.cardLimit)
            {
                Debug.Log("Hand is full! Can't draw more cards.");
                return;
            }

            // Take top card from deck
            GameObject cardPrefab = deck[0];
            deck.RemoveAt(0);

            GameObject cardObj = Instantiate(cardPrefab);
            Card card = cardObj.GetComponent<Card>();

            handManager.AddCardToHand(card);
        }
        else
        {
            Debug.Log("Deck is empty!");
        }
    }
}
