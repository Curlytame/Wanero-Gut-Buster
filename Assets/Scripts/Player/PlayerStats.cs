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

    // 🔹 Individual Buff tracking
    [System.Serializable]
    public class ActiveBuff
    {
        public int value;
        public int remainingTurns;
    }

    private List<ActiveBuff> activeBuffs = new List<ActiveBuff>();

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

    // --- Buff System ---
    public void ApplyBuff(int value, int duration)
    {
        ActiveBuff newBuff = new ActiveBuff { value = value, remainingTurns = duration };
        activeBuffs.Add(newBuff);
        attackBonus += value;

        Debug.Log($"🟢 Buff applied: +{value} attack for {duration} turns (Total attackBonus: {attackBonus}).");
    }

    // Called when player presses End Turn
    public void TickBuffs()
    {
        if (activeBuffs.Count == 0) return;

        Debug.Log("🕒 Checking buffs...");

        List<ActiveBuff> expired = new List<ActiveBuff>();

        foreach (var buff in activeBuffs)
        {
            buff.remainingTurns--;
            if (buff.remainingTurns <= 0)
                expired.Add(buff);
        }

        // Remove expired buffs and subtract their value
        foreach (var buff in expired)
        {
            activeBuffs.Remove(buff);
            attackBonus -= buff.value;
            Debug.Log($"🔻 Buff expired: -{buff.value} attack (Remaining total bonus: {attackBonus}).");
        }
    }

    private void UpdateEnergyUI()
    {
        if (energyText != null)
        {
            energyText.text = $"Energy: {currentEnergy} / {maxEnergy}";
        }
    }
}
