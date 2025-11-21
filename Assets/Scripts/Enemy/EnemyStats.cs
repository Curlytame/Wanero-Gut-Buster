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

    // Property wrapper for safe access
    public int currentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, maxHealth);
    }

    private void Awake()
    {
        // Ensure current health is valid at start
        if (_currentHealth <= 0 || _currentHealth > maxHealth)
            _currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
    }
}
