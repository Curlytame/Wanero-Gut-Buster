using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyCard", menuName = "Cards/Enemy Card Stats")]
public class EnemyCardStats : ScriptableObject
{
    [Header("Card Info")]
    public string cardName;
    [TextArea] public string description;

    [Header("Energy")]
    public int energyCost = 1;

    [Header("Abilities")]
    public bool canDamage;
    public int damageValue;

    public bool canHeal;
    public int healValue;

    public bool canBuff;
    public int buffValue;
    public int buffDuration = 2; // 🟩 Buff duration in turns

    public bool canDrawCard;
    public int drawCount;

    [Header("AI Settings")]
    [Range(0f, 1f)] public float useChance = 1f;
    public float playDelay = 0.5f;
}
