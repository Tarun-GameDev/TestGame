using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public float moveSpeed = 5f; //npc movement speed
    public float attackRange = 4f; //attack range
    [SerializeField] Vector3 goalPos;
    [SerializeField] float dist; //distance from player
    public float posLimit;  //pos limit so the npcs dont go out of the map

    Player _player;
    void Start()
    {
        _player = Player.instance;

        SetRandomPoint();
    }

    void Update()
    {

        
        if (_player != null)
        {
            dist = (_player.transform.position - transform.position).magnitude; //dist calculate from player to npc

            if (dist <= attackRange)
            {
                chasePlayer();
            }
            else
                RandomlyMove();
        }
        else
            RandomlyMove();


        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    //Chasing Player 
    void chasePlayer()
    {
        Vector3 _pos = new Vector3(_player.transform.position.x, 0f, _player.transform.position.z);

        transform.LookAt(_pos);
    }


    //Moving Randomly
    void RandomlyMove()
    {
        float distFromGoal = (goalPos - transform.position).magnitude;

        if(distFromGoal <= .1f)
        {
            SetRandomPoint();
        }
        else
        {
            transform.LookAt(goalPos);
        }
    }

    
    //Random Position
    void SetRandomPoint()
    {
        float xPos = Random.Range(-posLimit, posLimit);
        float zpos = Random.Range(-posLimit, posLimit);

        goalPos = new Vector3(xPos, 0f, zpos);
    }
}
