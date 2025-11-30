using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Core Stats")]
    public int maxHealth = 50;
    [SerializeField] private int _currentHealth = 50;

    public int attackBonus = 0;
    public int defense = 0;

    [Header("Energy")]
    public int maxEnergy = 3;
    public int currentEnergy = 3;

    [System.Serializable]
    public class BuffData
    {
        public bool isAttackBuff;
        public int amount;
        public int remainingTurns;
    }

    public List<BuffData> activeBuffs = new List<BuffData>();

    public int currentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, maxHealth);
    }

    private void Awake()
    {
        if (_currentHealth <= 0 || _currentHealth > maxHealth)
            _currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
    }

    // Apply buff
    public void ApplyBuff(bool isAttackBuff, int amount, int duration)
    {
        if (isAttackBuff)
            attackBonus += amount;
        else
            defense += amount;

        activeBuffs.Add(new BuffData
        {
            isAttackBuff = isAttackBuff,
            amount = amount,
            remainingTurns = duration
        });

        Debug.Log($"🟢 Enemy gained {(isAttackBuff ? "Attack" : "Defense")} buff +{amount} for {duration} turns.");
    }

    // Tick buffs durations
    public void TickBuffDurations()
    {
        for (int i = activeBuffs.Count - 1; i >= 0; i--)
        {
            activeBuffs[i].remainingTurns--;

            if (activeBuffs[i].remainingTurns <= 0)
            {
                if (activeBuffs[i].isAttackBuff)
                {
                    attackBonus -= activeBuffs[i].amount;
                    Debug.Log($"🔻 Enemy attack buff expired (-{activeBuffs[i].amount})");
                }
                else
                {
                    defense -= activeBuffs[i].amount;
                    Debug.Log($"🔻 Enemy defense buff expired (-{activeBuffs[i].amount})");
                }

                activeBuffs.RemoveAt(i);
            }
        }
    }
}
