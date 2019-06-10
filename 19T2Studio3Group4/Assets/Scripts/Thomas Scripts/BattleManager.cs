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

    public Character character1;
    public Character character2;
    public Character character3;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        character1 = GameObject.Find("Character1").GetComponent<Character>();
        character2 = GameObject.Find("Character2").GetComponent<Character>();
        character3 = GameObject.Find("Character3").GetComponent<Character>();
        
        character1.health = data.health;
        character1.attackRating = data.attackRating;
        character1.defenceRating = data.defenceRating;
        character1.level = data.level;
        character1.exp = data.exp;

        character2.health = data.health2;
        character2.attackRating = data.attackRating2;
        character2.defenceRating = data.defenceRating2;
        character2.level = data.level2;
        character2.exp = data.exp2;

        character3.health = data.health3;
        character3.attackRating = data.attackRating3;
        character3.defenceRating = data.defenceRating3;
        character3.level = data.level3;
        character3.exp = data.exp3;

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
