using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [Header("Hand Settings")]
    public int maxHandSize = 10;          // Limit on cards in hand
    public float cardSpacing = 1.5f;      // Spacing between cards
    public Transform handAnchor;          // Where cards are positioned (empty GameObject in scene)

    private List<Card> cardsInHand = new List<Card>();

    public void AddCardToHand(Card card)
    {
        if (cardsInHand.Count >= maxHandSize)
        {
            Debug.Log("Hand is full!");
            Destroy(card.gameObject); // Or send it to discard pile
            return;
        }

        card.transform.SetParent(handAnchor);
        cardsInHand.Add(card);
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
