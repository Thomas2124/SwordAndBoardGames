using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        CoinFlip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CoinFlip()
    {
        int RandomNum = Random.Range(1, 100); //Random Number
        if (RandomNum <= 50) //Sets Players Turn
        {
            player1.GetComponent<Player1>().isMyTurn = true;
            player1.GetComponent<Player1>().TurnStarted();
            player2.GetComponent<Player2>().isMyTurn = false;
        }
        else
        {
            player2.GetComponent<Player2>().isMyTurn = true;
            player2.GetComponent<Player2>().TurnStarted();
            player1.GetComponent<Player1>().isMyTurn = false;
        }
    }

    void Attack()
    {

    }
}
