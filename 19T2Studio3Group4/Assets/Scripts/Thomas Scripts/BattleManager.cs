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
    public bool endWait = false;

    public Character character1;
    public Character character2;
    public Character character3;

    public float fishman_exp;
    public float werewolf_exp;
    public float bukkakeSlime_exp;
    public float dragonoid_exp;
    public float golem_exp;
    public float catperson_exp;
    public float angel_exp;
    public float devil_exp;
    public float orge_exp;
    public float gargoyle_exp;
    public float garuda_exp;
    public float loxodon_exp;
    public float minotaur_exp;
    public float spiderperson_exp;
    public float hobnoblin_exp;

    // Start is called before the first frame update
    void Awake()
    {
        endWait = false;
        if (ExpSaveSystem.LoadPlayer() == null)
        {

        }
        else
        {
            ExpSaver expData = ExpSaveSystem.LoadPlayer();
            fishman_exp = expData.fishman_exp;
            werewolf_exp = expData.werewolf_exp;
            bukkakeSlime_exp = expData.bukkakeSlime_exp;
            dragonoid_exp = expData.dragonoid_exp;
            golem_exp = expData.golem_exp;
            catperson_exp = expData.catperson_exp;
            angel_exp = expData.angel_exp;
            devil_exp = expData.devil_exp;
            orge_exp = expData.orge_exp;
            gargoyle_exp = expData.gargoyle_exp;
            garuda_exp = expData.garuda_exp;
            loxodon_exp = expData.loxodon_exp;
            minotaur_exp = expData.minotaur_exp;
            spiderperson_exp = expData.spiderperson_exp;
            hobnoblin_exp = expData.hobnoblin_exp;
        }

        PlayerData data = SaveSystem.LoadPlayer();
        character1 = GameObject.Find("Character1").GetComponent<Character>();
        character2 = GameObject.Find("Character2").GetComponent<Character>();
        character3 = GameObject.Find("Character3").GetComponent<Character>();

        character1.characterName= data.characterName;
        character1.health = data.health;
        character1.attackRating = data.attackRating;
        character1.defenceRating = data.defenceRating;

        character2.characterName = data.characterName2;
        character2.health = data.health2;
        character2.attackRating = data.attackRating2;
        character2.defenceRating = data.defenceRating2;

        character3.characterName = data.characterName3;
        character3.health = data.health3;
        character3.attackRating = data.attackRating3;
        character3.defenceRating = data.defenceRating3;

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

        if (player2Lost == true && endWait == false)
        {
            victoryObject.SetActive(true);
            GameObject[] p1Characters = player1.GetComponent<Player1>().characters;
            foreach (GameObject item in p1Characters)
            {
                string theName = item.GetComponent<Character>().characterName;
                switch (theName)
                {
                case "fishman":
                    fishman_exp += 50f;
                    break;
                case "werewolf":
                    werewolf_exp += 50f;
                    break;
                case "bukkake Slime":
                    bukkakeSlime_exp += 50f;
                    break;
                case "dragonoid":
                    dragonoid_exp += 50f;
                    break;
                case "golem":
                    golem_exp += 50f;
                    break;
                case "angel":
                    angel_exp += 50f;
                    break;
                case "devil":
                    devil_exp += 50f;
                    break;
                case "orge":
                    orge_exp += 50f;
                    break;
                case "gargoyle":
                    gargoyle_exp += 50f;
                    break;
                case "garuda":
                    garuda_exp += 50f;
                    break;
                case "loxodon":
                    loxodon_exp += 50f;
                    break;
                case "minotaur":
                    minotaur_exp += 50f;
                    break;
                case "spiderperson":
                    spiderperson_exp += 50f;
                    break;
                case "hobnoblin":
                    hobnoblin_exp += 50f;
                    break;
                }
            }

            ExpSaveSystem.SavePlayer(this);
            player1.GetComponent<Player1>().enabled = false;
            player2.GetComponent<Player2>().enabled = false;
            victoryText.text = "Player 1 Wins!";
            endWait = true;

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
