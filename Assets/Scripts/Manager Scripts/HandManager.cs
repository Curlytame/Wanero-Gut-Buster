using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [Header("Hand Settings")]
    public int maxHandSize = 10;          // Limit on cards in hand
    public float cardSpacing = 1.5f;      // Spacing between cards
    public Transform handAnchor;          // Where cards are positioned (empty GameObject in scene)

    private List<Card> cardsInHand = new List<Card>();

    // 🔹 lets GameManager check hand size
    public int CurrentHandSize => cardsInHand.Count;

    // 🔹 new method so Card.cs can ask where it was originally
    public int GetCardIndex(Card card)
    {
        return cardsInHand.IndexOf(card);
    }

    // 🔹 overload to allow inserting back at specific index
    public void AddCardToHand(Card card, int index = -1)
    {
        if (cardsInHand.Count >= maxHandSize)
        {
            Debug.Log("Hand is full!");
            Destroy(card.gameObject); // Or send it to discard pile
            return;
        }

        card.transform.SetParent(handAnchor);

        if (index >= 0 && index <= cardsInHand.Count)
        {
            cardsInHand.Insert(index, card);
        }
        else
        {
            cardsInHand.Add(card);
        }

        UpdateHandLayout();
    }

    public void RemoveCardFromHand(Card card)
    {
        if (cardsInHand.Contains(card))
        {
            cardsInHand.Remove(card);
            UpdateHandLayout();
        }
    }

    private void UpdateHandLayout()
    {
        float totalWidth = (cardsInHand.Count - 1) * cardSpacing;
        float startX = -totalWidth / 2;

        for (int i = 0; i < cardsInHand.Count; i++)
        {
            Vector3 targetPos = new Vector3(startX + i * cardSpacing, 0, 0);
            cardsInHand[i].transform.localPosition = targetPos;
        }
    }
}
