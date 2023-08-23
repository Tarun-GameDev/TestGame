using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public int id;
    [SerializeField] GameObject cardText;
    public bool opened = false;
    [SerializeField] CardLevelManager levelManager;

    private void OnMouseDown()
    {
        Flip();
    }

    public void Flip()
    {
       if(!cardText.activeSelf && !opened)
        {
            levelManager.CardCheck(this);
            cardText.SetActive(true);
        }
           
    }
    
    public void DeFlip()
    {
        cardText.SetActive(false);
    }
}
