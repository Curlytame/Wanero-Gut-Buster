using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDropArea : MonoBehaviour, ICardDropArea
{

    public void OnCardDrop(Card card)
    {
        card.transform.position = transform.position;
        Debug.Log("Card dropped here");
    }

}
