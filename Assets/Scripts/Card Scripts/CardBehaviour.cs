using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public CardStats cardStats;  // Reference to the ScriptableObject

    public void PlayCard()
    {
        // Call effects depending on what’s enabled in the asset
        if (cardStats.canDamage)
        {
            cardStats.DoDamage();
        }

        if (cardStats.canHeal)
        {
            cardStats.DoHeal();
        }

        if (cardStats.canDrawCard)
        {
            cardStats.DoDrawCard();
        }

        if (cardStats.canBuff)
        {
            cardStats.DoBuff();
        }
    }
}
