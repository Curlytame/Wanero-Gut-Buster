using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Card Settings")]
    public List<GameObject> deckList;
    public int startingHandSize = 5;

    [Header("References")]
    public HandManager handManager;
    public PlayerStats playerStats;
    public CardDrawEffectManager drawEffectManager;

    [Header("Draw Settings")]
    public float drawDelay = 0.3f;  // Delay before card is added, matches animation

    private List<GameObject> deck = new List<GameObject>();
    private List<GameObject> discardPile = new List<GameObject>();

    private void Start()
    {
        CreateDeck();
        ShuffleDeck();
        StartCoroutine(DrawStartingHand());
    }

    private void CreateDeck()
    {
        deck.Clear();
        foreach (GameObject cardPrefab in deckList)
        {
            if (cardPrefab != null)
                deck.Add(cardPrefab);
        }
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int rand = Random.Range(i, deck.Count);
            (deck[i], deck[rand]) = (deck[rand], deck[i]);
        }
    }

    private IEnumerator DrawStartingHand()
    {
        int drawCount = Mathf.Min(startingHandSize, playerStats.cardLimit);

        for (int i = 0; i < drawCount; i++)
        {
            yield return StartCoroutine(DrawCardWithEffect());
        }
    }

    public void DrawCard()
    {
        StartCoroutine(DrawCardWithEffect());
    }

    private IEnumerator DrawCardWithEffect()
    {
        // Play animation first
        drawEffectManager?.PlayDrawAnimation();

        // Wait for the animation/delay
        yield return new WaitForSeconds(drawDelay);

        if (deck.Count == 0)
        {
            if (discardPile.Count > 0)
                ReshuffleDiscardPile();
            else
            {
                Debug.LogWarning("No cards left to draw!");
                yield break;
            }
        }

        if (handManager.CurrentHandSize >= playerStats.cardLimit)
        {
            Debug.Log("Hand full! Can't draw more cards.");
            yield break;
        }

        GameObject cardPrefab = deck[0];
        deck.RemoveAt(0);

        if (cardPrefab == null)
            yield break;

        GameObject cardObj = Instantiate(cardPrefab);
        Card c = cardObj.GetComponent<Card>();
        handManager.AddCardToHand(c);
    }

    public void DiscardCard(GameObject card)
    {
        if (card == null) return;

        GameObject prefabRef = GetCardPrefabReference(card);
        if (prefabRef != null)
            discardPile.Add(prefabRef);

        Destroy(card);
    }

    private void ReshuffleDiscardPile()
    {
        deck.AddRange(discardPile);
        discardPile.Clear();
        ShuffleDeck();
    }

    private GameObject GetCardPrefabReference(GameObject cardInstance)
    {
        string nameToFind = cardInstance.name.Replace("(Clone)", "").Trim();
        return deckList.Find(c => c.name == nameToFind);
    }
}
