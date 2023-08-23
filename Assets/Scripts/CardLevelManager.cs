using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLevelManager : MonoBehaviour
{
    public Card firstCard;
    public Card secondCard;


    public void CardCheck(Card _card)
    {
        if (firstCard == null)
        {
            firstCard = _card;
        }
        else
        {
            secondCard = _card;
            Cheking();
        }    
    }

    public void Cheking()
    {
        if (firstCard.id == secondCard.id)
        {
            firstCard.opened = true;
            secondCard.opened = true;

            firstCard = null;
            secondCard = null;
        }
        else 
        {
            firstCard.DeFlip();
            secondCard.DeFlip();

            firstCard = null;
            secondCard = null;
        }
    }
}
