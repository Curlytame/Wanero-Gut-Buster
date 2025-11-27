using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    [Header("Core Stats")]
    public int maxHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    public int defence = 0;
    public int attackBonus = 0;

    [Header("Energy")]
    public int maxEnergy = 3;
    public int currentEnergy = 3;
    public int energyGained = 1;

    [Header("Cards")]
    public int cardLimit = 10;
    public int cardDrawCount = 1;

    [Header("UI References")]
    public TextMeshProUGUI energyText;

    // Buff structures
    [System.Serializable]
    public class ActiveBuff
    {
        public int value;
        public int remainingTurns;
    }

    private List<ActiveBuff> attackBuffs = new List<ActiveBuff>();
    private List<ActiveBuff> defenseBuffs = new List<ActiveBuff>();

    public int currentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, maxHealth);
    }

    void Awake()
    {
        if (_currentHealth <= 0 || _currentHealth > maxHealth)
            _currentHealth = maxHealth;

        UpdateEnergyUI();
    }

    // --- Health ---
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
    }

    // --- Energy ---
    public void ModifyEnergy(int amount)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + amount, 0, maxEnergy);
        UpdateEnergyUI();
    }

    public void GainEnergy()
    {
        ModifyEnergy(energyGained);
    }

    // --- Buff Application ---
    public void ApplyAttackBuff(int value, int duration)
    {
        var buff = new ActiveBuff { value = value, remainingTurns = duration };
        attackBuffs.Add(buff);
        attackBonus += value;

        Debug.Log($"🟢 Attack Buff +{value} applied ({duration} turns). Total AttackBonus: {attackBonus}");
    }

    public void ApplyDefenseBuff(int value, int duration)
    {
        var buff = new ActiveBuff { value = value, remainingTurns = duration };
        defenseBuffs.Add(buff);
        defence += value;

        Debug.Log($"🛡 Defense Buff +{value} applied ({duration} turns). Total Defense: {defence}");
    }

    // --- Buff Countdown (called when Player ends turn) ---
    public void TickBuffs()
    {
        TickBuffList(attackBuffs, ref attackBonus, "Attack");
        TickBuffList(defenseBuffs, ref defence, "Defense");
    }

    private void TickBuffList(List<ActiveBuff> buffList, ref int statRef, string type)
    {
        if (buffList.Count == 0) return;

        List<ActiveBuff> expired = new List<ActiveBuff>();

        foreach (var buff in buffList)
        {
            buff.remainingTurns--;
            if (buff.remainingTurns <= 0)
                expired.Add(buff);
        }

        foreach (var buff in expired)
        {
            buffList.Remove(buff);
            statRef -= buff.value;
            Debug.Log($"🔻 {type} Buff expired: -{buff.value} ({type} now {statRef})");
        }
    }

    private void UpdateEnergyUI()
    {
        if (energyText != null)
            energyText.text = $"Energy: {currentEnergy} / {maxEnergy}";
    }
}
