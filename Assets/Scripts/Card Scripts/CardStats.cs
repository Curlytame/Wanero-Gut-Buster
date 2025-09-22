using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Card Stats")]
public class CardStats : ScriptableObject
{
    [Header("Card Settings")]
    public string cardName;
    [TextArea] public string description;

    [Header("Card Abilities")]
    public bool canDamage;
    public bool canHeal;
    public bool canDrawCard;
    public bool canBuff;

    // Later you can implement actual logic here, for now just placeholders:
    public void DoDamage()
    {
        // TODO: Add damage logic
    }

    public void DoHeal()
    {
        // TODO: Add heal logic
    }

    public void DoDrawCard()
    {
        // TODO: Add draw card logic
    }

    public void DoBuff()
    {
        // TODO: Add buff logic
    }
}
