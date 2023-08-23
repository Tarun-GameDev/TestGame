using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePlayer : MonoBehaviour
{
    public int diceNo;

    [SerializeField] Transform[] _Positions;
    [SerializeField] int currentStep = 0;
    [SerializeField] int id = 0;
    [SerializeField] int maxSteps = 6;

    //0
    //

    public void movePlayer(int _Steps)
    {
       
        currentStep += _Steps;
      

        if(currentStep >= _Positions.Length)
        {
            //
            transform.position = _Positions[_Positions.Length-1].transform.position;
        }
        else
            transform.position = _Positions[currentStep].transform.position;

        if (currentStep >= maxSteps)
        {
            Debug.Log("GameOver, Player" + id + "Win");
        }
    }
}
