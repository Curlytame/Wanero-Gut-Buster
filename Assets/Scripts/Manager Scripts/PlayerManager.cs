using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    public PlayerStats playerStats;
    public HandManager handManager;
    public GameManager gameManager;

    public void StartTurn()
    {
        Debug.Log("🔵 Player Turn Start");
        DrawCards();
    }

    private void DrawCards()
    {
        int count = playerStats.cardDrawCount;

        for (int i = 0; i < count; i++)
        {
            if (handManager.CurrentHandSize >= playerStats.cardLimit)
            {
                Debug.Log("Hand full");
                break;
            }

            gameManager.DrawCard();    // Animation also plays here automatically
        }
    }
}
