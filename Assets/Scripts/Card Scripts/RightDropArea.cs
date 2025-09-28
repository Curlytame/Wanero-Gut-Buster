using UnityEngine;

public class RightDropArea : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Card card)
    {
        CardBehaviour cardBehaviour = card.GetComponent<CardBehaviour>();
        if (cardBehaviour == null)
        {
            Destroy(card.gameObject);
            return;
        }

        // Check all colliders at the card's position
        Collider2D[] hits = Physics2D.OverlapPointAll(card.transform.position);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                // Found an enemy, apply card effect
                cardBehaviour.PlayCard(hit.gameObject);
                break; // stop after first enemy
            }
        }

        // Remove the card after being played
        Destroy(card.gameObject);
    }
}
