using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public enum Turn { Player, Enemy }
    public Turn currentTurn = Turn.Player;

    [Header("References")]
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public PlayerStats playerStats;
    public Button endTurnButton;

    private void Start()
    {
        if (endTurnButton != null)
            endTurnButton.onClick.AddListener(EndPlayerTurn);

        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        currentTurn = Turn.Player;
        Debug.Log("🔵 Player Turn Start");
        playerManager.StartTurn();

        if (endTurnButton != null)
            endTurnButton.interactable = true;
    }

    private void EndPlayerTurn()
    {
        if (currentTurn != Turn.Player) return;

        Debug.Log("🔴 Player Turn End");

        // Tick all buffs (attack + defense)
        if (playerStats != null)
            playerStats.TickBuffs();

        // Grant energy from player's energyGained value when they end turn
        if (playerStats != null)
        {
            playerStats.GainEnergy();
            Debug.Log($"➕ Gained {playerStats.energyGained} energy (now {playerStats.currentEnergy}/{playerStats.maxEnergy})");
        }

        if (endTurnButton != null)
            endTurnButton.interactable = false;

        StartCoroutine(enemyManager.StartEnemyTurn(() =>
        {
            StartPlayerTurn();
        }));
    }
}
