using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FusionRecipeSlot
{
    public CardStats specificCard; // If null, allows any card with the requiredTag
    public string requiredTag; // Optional, e.g., "Vegetable"
}

[System.Serializable]
public class FusionRecipe
{
    [Header("Fusion Ingredients (2 or 3 Cards)")]
    public List<FusionRecipeSlot> requiredSlots = new List<FusionRecipeSlot>(); // Can be 2 or 3
    public GameObject resultCardPrefab;
}

public class FusionManager : MonoBehaviour
{
    [Header("Fusion Slots (2 or 3 supported)")]
    public FusionArea fusionArea1;
    public FusionArea fusionArea2;
    public FusionArea fusionArea3;

    [Header("Fusion Recipes")]
    public List<FusionRecipe> fusionRecipes = new List<FusionRecipe>();

    [Header("References")]
    public HandManager handManager;
    public Button fusionButton;

    [Header("Fusion FX")]
    public Transform cookingPot;
    public float shakeDuration = 0.4f;
    public float shakeMagnitude = 10f;

    private Vector3 originalRotation;

    private void Start()
    {
        if (fusionButton != null)
            fusionButton.onClick.AddListener(TryFusion);

        if (cookingPot != null)
            originalRotation = cookingPot.localEulerAngles;
    }

    public void TryFusion()
    {
        // Collect all filled fusion areas
        List<CardBehaviour> selectedCards = new List<CardBehaviour>();

        if (fusionArea1.CurrentCard != null)
            selectedCards.Add(fusionArea1.CurrentCard.GetComponent<CardBehaviour>());
        if (fusionArea2.CurrentCard != null)
            selectedCards.Add(fusionArea2.CurrentCard.GetComponent<CardBehaviour>());
        if (fusionArea3 != null && fusionArea3.CurrentCard != null)
            selectedCards.Add(fusionArea3.CurrentCard.GetComponent<CardBehaviour>());

        if (selectedCards.Count < 2)
        {
            Debug.Log("⚠️ You need at least 2 cards to fuse!");
            return;
        }

        List<CardStats> selectedStats = new List<CardStats>();
        foreach (var card in selectedCards)
        {
            if (card != null && card.cardStats != null)
                selectedStats.Add(card.cardStats);
        }

        foreach (FusionRecipe recipe in fusionRecipes)
        {
            if (recipe.resultCardPrefab == null || recipe.requiredSlots.Count < 2)
                continue;

            if (IsFusionMatch(recipe.requiredSlots, selectedStats))
            {
                Debug.Log($"🍲 Fusion successful: {recipe.resultCardPrefab.name}");
                if (cookingPot != null)
                    StartCoroutine(ShakePot());

                DestroyUsedCards();

                GameObject newCard = Instantiate(recipe.resultCardPrefab);
                Card cardComp = newCard.GetComponent<Card>();
                if (cardComp != null)
                    handManager.AddCardToHand(cardComp);

                return;
            }
        }

        Debug.Log("❌ No valid fusion recipe found!");
    }

    private bool IsFusionMatch(List<FusionRecipeSlot> recipeSlots, List<CardStats> selectedCards)
    {
        if (recipeSlots.Count != selectedCards.Count)
            return false;

        List<CardStats> tempList = new List<CardStats>(selectedCards);

        foreach (var slot in recipeSlots)
        {
            bool matched = false;

            for (int i = 0; i < tempList.Count; i++)
            {
                CardStats card = tempList[i];

                // Match either specific card or by tag
                if ((slot.specificCard != null && card == slot.specificCard) ||
                    (!string.IsNullOrEmpty(slot.requiredTag) && card.cardTag == slot.requiredTag))
                {
                    tempList.RemoveAt(i);
                    matched = true;
                    break;
                }
            }

            if (!matched)
                return false;
        }

        return true;
    }

    private void DestroyUsedCards()
    {
        if (fusionArea1.CurrentCard != null)
        {
            Destroy(fusionArea1.CurrentCard.gameObject);
            fusionArea1.ClearSlot();
        }
        if (fusionArea2.CurrentCard != null)
        {
            Destroy(fusionArea2.CurrentCard.gameObject);
            fusionArea2.ClearSlot();
        }
        if (fusionArea3 != null && fusionArea3.CurrentCard != null)
        {
            Destroy(fusionArea3.CurrentCard.gameObject);
            fusionArea3.ClearSlot();
        }
    }

    private IEnumerator ShakePot()
    {
        Vector3 startRot = cookingPot.localEulerAngles;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float z = Mathf.Sin(Time.time * 60f) * shakeMagnitude;
            cookingPot.localEulerAngles = new Vector3(startRot.x, startRot.y, startRot.z + z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cookingPot.localEulerAngles = startRot;
    }
}
