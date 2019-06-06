using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public bool player1Lost;
    public bool player2Lost;
    public GameObject victoryObject;
    public Text victoryText;

    // Start is called before the first frame update
    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        victoryObject = GameObject.FindWithTag("Victory Object");
        victoryText = GameObject.FindGameObjectWithTag("Victory Text").GetComponent<Text>();
        victoryObject.SetActive(false);
        CoinFlip();
    }

    // Update is called once per frame
    void Update()
    {
        Victory();
    }

    void Victory() //Check if a player wins
    {
        player1Lost = player1.GetComponent<Player1>().isDefeated;
        player2Lost = player2.GetComponent<Player2>().isDefeated;

        if (player1Lost == true)
        {
            victoryObject.SetActive(true);
            player1.GetComponent<Player1>().enabled = false;
            player2.GetComponent<Player2>().enabled = false;
            victoryText.text = "Player 2 Wins!";
        }

        if (player2Lost == true)
        {
            victoryObject.SetActive(true);
            player1.GetComponent<Player1>().enabled = false;
            player2.GetComponent<Player2>().enabled = false;
            victoryText.text = "Player 1 Wins!";
        }
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
