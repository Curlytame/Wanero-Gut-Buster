using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Card Stats")]
public class CardStats : ScriptableObject
{
    [Header("Card Settings")]
    public string cardName;
    [TextArea] public string description;

    [Header("Card Costs")]
    public int energyCost = 1; // Always required

    [Header("Card Abilities")]
    public bool canDamage;
    public int damageValue;

    public bool canHeal;
    public int healValue;

    public bool canDrawCard;
    public int drawCount;

    public bool canBuffAttack;
    public int attackBuffValue;
    public int attackBuffDuration;

    public bool canBuffDefense;
    public int defenseBuffValue;
    public int defenseBuffDuration;
}
