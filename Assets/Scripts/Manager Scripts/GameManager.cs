using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Deck 1 (Default)")]
    public List<GameObject> deck1List;

    [Header("Deck 2")]
    public List<GameObject> deck2List;

    [Header("Deck 3")]
    public List<GameObject> deck3List;

    [Header("Card Settings")]
    public int startingHandSize = 5;

    [Header("References")]
    public HandManager handManager;
    public PlayerStats playerStats;
    public CardDrawEffectManager drawEffectManager;

    [Header("Draw Settings")]
    public float drawDelay = 0.3f;

    private List<GameObject> activeDeckSource;
    private List<GameObject> deck = new List<GameObject>();
    private List<GameObject> discardPile = new List<GameObject>();

    private void Start()
    {
        // Default to Deck 1
        SetActiveDeck(1);

        ShuffleDeck();
        StartCoroutine(DrawStartingHand());
    }

    /* =======================
       DECK SETUP & SWITCHING
       ======================= */

    public void SetActiveDeck(int deckIndex)
    {
        switch (deckIndex)
        {
            case 1:
                activeDeckSource = deck1List;
                break;
            case 2:
                activeDeckSource = deck2List;
                break;
            case 3:
                activeDeckSource = deck3List;
                break;
            default:
                Debug.LogWarning("Invalid deck index, defaulting to Deck 1");
                activeDeckSource = deck1List;
                break;
        }

        BuildDeckFromSource();
    }

    private void BuildDeckFromSource()
    {
        deck.Clear();
        discardPile.Clear();

        foreach (GameObject cardPrefab in activeDeckSource)
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

    /* =======================
       DRAWING
       ======================= */

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
        drawEffectManager?.PlayDrawAnimation();
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
        Card card = cardObj.GetComponent<Card>();
        handManager.AddCardToHand(card);
    }

    /* =======================
       DISCARD SYSTEM
       ======================= */

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
        string cleanName = cardInstance.name.Replace("(Clone)", "").Trim();
        return activeDeckSource.Find(c => c.name == cleanName);
    }
}
