using UnityEngine;

public class FusionArea : MonoBehaviour, ICardDropArea
{
    public Card CurrentCard { get; private set; }  // The card placed in this slot

    public void OnCardDrop(Card card)
    {
        if (CurrentCard != null)
        {
            Debug.Log("This fusion slot is already occupied!");
            return;
        }

        // Snap card to this area
        card.transform.position = transform.position;
        card.transform.SetParent(transform);

        CurrentCard = card;
        Debug.Log($"Card {card.name} placed in {gameObject.name}");
    }

    public void ClearSlot()
    {
        CurrentCard = null;
    }
}
