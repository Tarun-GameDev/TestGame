using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] TMP_InputField npcIP;
    [SerializeField] TMP_InputField attackRangeIP;
    [SerializeField] TMP_InputField npcSpeedIP;
    [SerializeField] TMP_InputField playerSpeedIP;
    [SerializeField] GameObject startMenu;


    //All Prefabs 
    [Header("Prefabs")]
    [SerializeField]
    GameObject playerObj;
    [SerializeField]GameObject goalObj;  //goal GameObj
    [SerializeField] GameObject npcPrefab; //MPC PRefab
    [SerializeField] GameObject ground; //Ground CUbe for adjusting the size based on npcs
    [SerializeField] GameObject cam; //Main camera 

    int npcs = 1;  //no of npcs
    float attackRange = 4f; 
    float playerSpeed = 10f;
    float npcSpeed = 5f;

    //ground size

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void InitializeInput()
    {

        //getting the npc count from inputFIels
        int _npcs = int.Parse(npcIP.text);
        if (_npcs >= 1)
            npcs = _npcs;
        else
            npcs = 1;

        //getting the attack Range  from inputFIels
        float _attackRange = float.Parse(attackRangeIP.text);
        if (_attackRange >= 1)
            attackRange = _attackRange;
        else
            attackRange = 6f;

        //getting the npcSpeed from inputFIels
        float _npcSpeed = float.Parse(npcSpeedIP.text);
        if (_npcSpeed >= 1)
            npcSpeed = _npcSpeed;
        else
            npcSpeed = 5f;


        //getting the playerspeed from inputFIels
        float _playerSpeed = float.Parse(playerSpeedIP.text);
        if (_playerSpeed >= 1)
            playerSpeed = _playerSpeed;
        else
            playerSpeed = 10f;

        startMenu.SetActive(false);

        StartTheGame();
    }

    void StartTheGame()
    {
        int groundSize;


        //moving the camera based on npc size
        if (npcs <= 3f)
        {
            groundSize = 15;

            if (cam != null)
                cam.transform.position = new Vector3(0f, 10, -15f);
        }
        else
        {
            groundSize = 15 + (1 * npcs);
            if (cam != null)
                cam.transform.position = new Vector3(0f, 10 + npcs, -17f - npcs);
        }

        //ground size based on npc

        if (ground != null)
            ground.transform.localScale = new Vector3(groundSize, 1f, groundSize);


        //Npc SPawing
        for (int i = 0; i < npcs; i++)
        {
            if (npcPrefab != null)
            {
                NPC _npc = Instantiate(npcPrefab, new Vector3(Random.Range(-groundSize / 2, groundSize / 2), 0f, Random.Range((-groundSize / 2)+(1f * npcs/2), (groundSize / 2)-(1f))), Quaternion.identity).GetComponent<NPC>();
                _npc.attackRange = attackRange;
                _npc.posLimit = groundSize / 2;
                _npc.moveSpeed = npcSpeed;
            }

        }


        //player setting by getting inputFIelds 
        if(playerObj != null)
        {
            playerObj.transform.position = new Vector3(0f, 0f, (-groundSize/2)+1f);
            playerObj.GetComponent<Player>().speed = playerSpeed;
            playerObj.SetActive(true);
        }

        //moving Goal Pos based on npcs
        if (goalObj != null)
        {
            goalObj.transform.position = new Vector3(0f, 0f, (groundSize/2)-1f);
            goalObj.SetActive(true);
        }
    }
}
