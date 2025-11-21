using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("Core Stats")]
    public int maxHealth = 100;
    [SerializeField] private int _currentHealth = 100; // Serialize private field

    public int defence = 0;
    public int attackBonus = 0;

    [Header("Energy")]
    public int maxEnergy = 3;
    public int currentEnergy = 3;
    public int energyGained = 1; // 🔹 New: how much energy is gained (e.g., per turn)

    [Header("Cards")]
    public int cardLimit = 10;
    public int cardDrawCount = 1;

    [Header("UI References")]
    public TextMeshProUGUI energyText; // 🔹 Assign in Inspector

    // Property wrapper to access health safely
    public int currentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, maxHealth);
    }

    void Awake()
    {
        // Ensure currentHealth is initialized correctly
        if (_currentHealth <= 0 || _currentHealth > maxHealth)
            _currentHealth = maxHealth;

        UpdateEnergyUI();
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
    }

    public void ModifyEnergy(int amount)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + amount, 0, maxEnergy);
        UpdateEnergyUI();
    }

    public void GainEnergy()
    {
        ModifyEnergy(energyGained);
    }

    private void UpdateEnergyUI()
    {
        if (energyText != null)
        {
            energyText.text = $"Energy: {currentEnergy} / {maxEnergy}";
        }
    }
}
