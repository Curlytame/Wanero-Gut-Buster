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
    public int buffDuration = 2;

    public bool canDrawCard;
    public int drawCount;

    [Header("Card Type")]
    public EnemyCardType cardType;
}

public enum EnemyCardType
{
    Attack,
    Heal,
    Buff,
    Debuff
}
