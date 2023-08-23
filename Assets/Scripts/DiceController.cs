using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceController : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI diceText;

    public DicePlayer _player1;
    public DicePlayer _player2;

    [SerializeField] bool first = true;
    public int diceNo;


    public void Roll()
    {
        diceNo = Random.Range(1, 6);
        diceText.text = diceNo.ToString();

        Debug.Log("Roll NO:" + diceNo);

        if (first)
        {
            _player1.movePlayer(diceNo);
            first = false;
        }
        else
        {
            _player2.movePlayer(diceNo);
            first = true;
        }

    }
}
