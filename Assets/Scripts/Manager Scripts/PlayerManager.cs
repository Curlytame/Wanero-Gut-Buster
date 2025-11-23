using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    public PlayerStats playerStats;
    public HandManager handManager;
    public GameManager gameManager; // Used to draw cards from the deck

    public void StartTurn()
    {
        Debug.Log("🔵 Player Turn Start");
        DrawCards();
        playerStats.currentEnergy = playerStats.maxEnergy;
    }

    private void DrawCards()
    {
        int drawCount = playerStats.cardDrawCount;

        for (int i = 0; i < drawCount; i++)
        {
            if (handManager.CurrentHandSize >= playerStats.cardLimit)
            {
                Debug.Log("Player hand full, cannot draw more cards.");
                break;
            }

            gameManager.DrawCard();
        }
    }
}
