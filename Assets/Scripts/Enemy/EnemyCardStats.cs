using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyCard", menuName = "Cards/Enemy Card Stats")]
public class EnemyCardStats : ScriptableObject
{
    [Header("Card Info")]
    public string cardName;
    [TextArea] public string description;

    [Header("Energy")]
    public int energyCost = 1; // Energy required to play this card

    [Header("Abilities")]
    public bool canDamage;
    public int damageValue;

    public bool canHeal;
    public int healValue;

    public bool canBuff;
    public int buffValue;

    public bool canDrawCard;
    public int drawCount;

    [Header("AI Usage Settings")]
    [Tooltip("How likely the AI is to choose this card (0 = never, 1 = always).")]
    [Range(0f, 1f)] public float useChance = 1f;

    [Tooltip("Optional delay before the enemy plays this card.")]
    public float playDelay = 0.5f;
}
