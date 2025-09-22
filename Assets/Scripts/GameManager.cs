using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Card Settings")]
    public GameObject cardPrefab;         // Prefab of a card
    public int startingHandSize = 5;
    public int deckSize = 20;

    [Header("References")]
    public HandManager handManager;

    private Stack<GameObject> deck = new Stack<GameObject>();

    private void Start()
    {
        CreateDeck();
        DrawStartingHand();
    }

    private void CreateDeck()
    {
        for (int i = 0; i < deckSize; i++)
        {
            GameObject cardObj = Instantiate(cardPrefab);
            cardObj.SetActive(false); // keep hidden until drawn
            deck.Push(cardObj);
        }
    }

    private void DrawStartingHand()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (deck.Count > 0)
        {
            GameObject cardObj = deck.Pop();
            cardObj.SetActive(true);

            Card card = cardObj.GetComponent<Card>();
            handManager.AddCardToHand(card);
        }
        else
        {
            Debug.Log("Deck is empty!");
        }
    }
}
