using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // needed for Button

[System.Serializable]
public class FusionRecipe
{
    public CardStats cardA;
    public CardStats cardB;
    public GameObject resultCardPrefab;
}

public class FusionManager : MonoBehaviour
{
    [Header("Fusion Slots")]
    public FusionArea fusionArea1;
    public FusionArea fusionArea2;

    [Header("Fusion Recipes")]
    public List<FusionRecipe> fusionRecipes = new List<FusionRecipe>();

    [Header("References")]
    public HandManager handManager;
    public Button fusionButton; // assign in Inspector

    private void Start()
    {
        if (fusionButton != null)
        {
            fusionButton.onClick.AddListener(TryFusion);
        }
    }

    public void TryFusion()
    {
        if (fusionArea1.CurrentCard == null || fusionArea2.CurrentCard == null)
        {
            Debug.Log("Both fusion slots must have a card!");
            return;
        }

        CardBehaviour card1 = fusionArea1.CurrentCard.GetComponent<CardBehaviour>();
        CardBehaviour card2 = fusionArea2.CurrentCard.GetComponent<CardBehaviour>();

        if (card1 == null || card2 == null)
        {
            Debug.Log("One of the cards does not have a CardBehaviour!");
            return;
        }

        // Check recipes (allowing both orders)
        foreach (FusionRecipe recipe in fusionRecipes)
        {
            if ((card1.cardStats == recipe.cardA && card2.cardStats == recipe.cardB) ||
                (card1.cardStats == recipe.cardB && card2.cardStats == recipe.cardA))
            {
                Debug.Log($"Fusion successful: {recipe.resultCardPrefab.name}");

                // Destroy old cards
                Destroy(fusionArea1.CurrentCard.gameObject);
                Destroy(fusionArea2.CurrentCard.gameObject);
                fusionArea1.ClearSlot();
                fusionArea2.ClearSlot();

                // Create fused card
                GameObject newCard = Instantiate(recipe.resultCardPrefab);
                Card cardComp = newCard.GetComponent<Card>();
                if (cardComp != null)
                {
                    handManager.AddCardToHand(cardComp);
                }

                return; // Stop after first valid fusion
            }
        }

        Debug.Log("No valid fusion found!");
    }
}
