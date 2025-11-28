using UnityEngine;

public class RightDropArea : MonoBehaviour, ICardDropArea
{
    [Header("References (assign in Inspector)")]
    public PlayerStats playerStats;
    public HandManager handManager;

    public void OnCardDrop(Card card)
    {
        if (card == null)
            return;

        CardBehaviour cardBehaviour = card.GetComponent<CardBehaviour>();
        if (cardBehaviour == null)
        {
            Destroy(card.gameObject);
            return;
        }

        // Check energy cost before playing
        int cost = 0;
        if (cardBehaviour.cardStats != null)
            cost = cardBehaviour.cardStats.energyCost;

        if (playerStats == null || handManager == null)
        {
            Debug.LogWarning("RightDropArea: playerStats or handManager not assigned in Inspector.");
            // As a safe fallback, refuse to play and destroy the card to avoid stuck state
            Destroy(card.gameObject);
            return;
        }

        if (playerStats.currentEnergy < cost)
        {
            Debug.Log($"⚠️ Not enough energy to play {cardBehaviour.cardStats?.cardName ?? card.name}. Cost: {cost}, You have: {playerStats.currentEnergy}");

            // Return card to hand (simple approach)
            handManager.AddCardToHand(card);
            return;
        }

        // Find enemy under the card position and apply effect
        Collider2D[] hits = Physics2D.OverlapPointAll(card.transform.position);

        bool applied = false;
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                cardBehaviour.PlayCard(hit.gameObject);
                applied = true;
                break; // stop after first enemy
            }
        }

        // If we applied the card (played it), deduct energy and remove the card instance
        if (applied)
        {
            playerStats.ModifyEnergy(-cost);
            Destroy(card.gameObject);
        }
        else
        {
            // No enemy found; return card to hand instead of destroying it
            handManager.AddCardToHand(card);
        }
    }
}
