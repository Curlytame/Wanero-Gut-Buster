using UnityEngine;

public class DiscardDropArea : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Card card)
    {
        if (card == null)
            return;

        // Optional: safety check (in case something weird is dropped)
        CardBehaviour cardBehaviour = card.GetComponent<CardBehaviour>();
        if (cardBehaviour == null)
        {
            Destroy(card.gameObject);
            return;
        }

        // 🔥 Discard = destroy without playing
        Destroy(card.gameObject);
    }
}
