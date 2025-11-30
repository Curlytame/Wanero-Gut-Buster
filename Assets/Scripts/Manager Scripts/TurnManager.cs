using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public enum Turn { Player, Enemy }
    public Turn currentTurn = Turn.Player;

    [Header("References")]
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public PlayerStats playerStats;
    public Button endTurnButton;

    [Header("Turn Indicators")]
    public GameObject playerTurnIndicator;
    public GameObject enemyTurnIndicator;
    public float indicatorDuration = 1f;   // how long to show

    private void Start()
    {
        if (endTurnButton != null)
            endTurnButton.onClick.AddListener(EndPlayerTurn);

        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        currentTurn = Turn.Player;
        ShowIndicator(playerTurnIndicator);

        Debug.Log("🔵 Player Turn Start");

        // Tick player's buffs at the start of their turn
        if (playerStats != null)
            playerStats.TickBuffs();

        playerManager.StartTurn();

        if (endTurnButton != null)
            endTurnButton.interactable = true;
    }

    private void EndPlayerTurn()
    {
        if (currentTurn != Turn.Player) return;

        Debug.Log("🔴 Player Turn End");

        if (playerStats != null)
        {
            playerStats.GainEnergy();
            Debug.Log($"➕ Gained {playerStats.energyGained} energy");
        }

        if (endTurnButton != null)
            endTurnButton.interactable = false;

        // Show enemy turn indicator
        ShowIndicator(enemyTurnIndicator);

        // Start enemy turn
        StartCoroutine(enemyManager.StartEnemyTurn(() =>
        {
            StartPlayerTurn();
        }));
    }

    // 🔵 Show indicator briefly
    private void ShowIndicator(GameObject indicator)
    {
        if (indicator == null) return;
        StartCoroutine(TurnIndicatorRoutine(indicator));
    }

    private IEnumerator TurnIndicatorRoutine(GameObject indicator)
    {
        indicator.SetActive(true);
        yield return new WaitForSeconds(indicatorDuration);
        indicator.SetActive(false);
    }
}
