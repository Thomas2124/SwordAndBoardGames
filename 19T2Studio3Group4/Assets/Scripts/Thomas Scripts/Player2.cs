using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public GameObject[] characters;
    public int orderNumber = 1;
    public bool isMyTurn = false;
    public bool isDefeated = false;
    public GameObject activeCharacter;
    public GameObject opponent;
    public GameObject[] enemyCharacters;
    public List<GameObject> attackableCharacters;
    public Text charatext;
    public Text playerText;
    public int attackNumber;
    public bool wait;
    public bool character1;
    public bool character2;
    public bool character3;
    public bool attacked;
    public bool characterPicked;
    public GameObject enemy1Button;
    public GameObject enemy2Button;
    public GameObject enemy3Button;
    public bool once = false;

    void Awake()
    {
        opponent = GameObject.FindGameObjectWithTag("Player1");
        attacked = false;
        characterPicked = false;
        character1 = true;
        character2 = false;
        character3 = false;
        enemy1Button = GameObject.FindGameObjectWithTag("Enemy1Button");
        enemy2Button = GameObject.FindGameObjectWithTag("Enemy2Button");
        enemy3Button = GameObject.FindGameObjectWithTag("Enemy3Button");
    }

    void Update()
    {
        if (once == false)
        {
            enemy1Button.SetActive(false);
            enemy2Button.SetActive(false);
            enemy3Button.SetActive(false);
            once = true;
        }
        enemyCharacters = opponent.GetComponent<Player1>().characters;
        playerText = GameObject.FindGameObjectWithTag("PlayerText").GetComponent<Text>();
        charatext = GameObject.FindGameObjectWithTag("CharacterText").GetComponent<Text>();
        if (isMyTurn == true)
        {
            //StartCoroutine(PlayerTurn());
        }
        else
        {
            //StopAllCoroutines();
            character1 = false;
            character2 = false;
            character3 = false;
        }

        for (int i = 0; i < enemyCharacters.Length; i++)
        {
            if (enemyCharacters[i].GetComponent<Character>().isDead == false)
            {
                bool temp = false;
                bool temp2 = false;
                if (attackableCharacters.Count != 0)
                {
                    if (temp2 == false)
                    {
                        for (int j = 0; j < attackableCharacters.Count; j++)
                        {
                            if (attackableCharacters[j] == enemyCharacters[i])
                            {
                                temp = false;
                                temp2 = true;
                            }
                        }
                    }

                    if (temp2 == false)
                    {
                        temp = true;
                    }

                    if (temp == true)
                    {
                        attackableCharacters.Add(enemyCharacters[i]);
                    }
                }
                else
                {
                    attackableCharacters.Add(enemyCharacters[i]);
                }
            }
        }

        foreach (GameObject item in attackableCharacters)
        {
            if (item.GetComponent<Character>().isDead == true)
            {
                attackableCharacters.Remove(item);
            }
        }

        GameOver();

        if (character1 == true)
        {
            charatext.text = characters[0].name;
            if (attacked == true)
            {
                //RandomNumber();
                characters[0].GetComponent<Character>().isAttacking = true;
                if (characterPicked == true)
                {
                    attackableCharacters[attackNumber].GetComponent<Character>().health -= characters[0].GetComponent<Character>().attackRating;
                    BoolSetter();
                }
            }
        }

        if (character2 == true)
        {
            charatext.text = characters[1].name;
            character1 = false;
            if (attacked == true)
            {
                //RandomNumber();
                characters[1].GetComponent<Character>().isAttacking = true;
                if (characterPicked == true)
                {
                    attackableCharacters[attackNumber].GetComponent<Character>().health -= characters[1].GetComponent<Character>().attackRating;
                    BoolSetter2();
                }
                
            }
        }

        if (character3 == true)
        {
            charatext.text = characters[2].name;
            character2 = false;
            if (attacked == true)
            {
                //RandomNumber();
                characters[2].GetComponent<Character>().isAttacking = true;
                if (characterPicked == true)
                {
                    attackableCharacters[attackNumber].GetComponent<Character>().health -= characters[2].GetComponent<Character>().attackRating;
                    opponent.GetComponent<Player1>().TurnStarted();
                    BoolSetter3();
                }
            }
        }
    }

    public void TurnStarted()
    {
        playerText.text = "Player 2 Turn";
        isMyTurn = true;
        character1 = true;
        characterPicked = false;
        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);
    }

    void BoolSetter()
    {
        character2 = true;
        attacked = false;
        characterPicked = false;
    }
    void BoolSetter2()
    {
        character3 = true;
        attacked = false;
        characterPicked = false;
    }
    void BoolSetter3()
    {
        isMyTurn = false;
        character3 = false;
        characterPicked = false;
        attacked = false;
    }

    void ButtonChecker()
    {
        if (enemyCharacters[0].GetComponent<Character>().isDead == true)
        {
            enemy1Button.SetActive(false);
        }
        else
        {
            enemy1Button.SetActive(true);
        }

        if (enemyCharacters[1].GetComponent<Character>().isDead == true)
        {
            enemy2Button.SetActive(false);
        }
        else
        {
            enemy2Button.SetActive(true);
        }

        if (enemyCharacters[2].GetComponent<Character>().isDead == true)
        {
            enemy3Button.SetActive(false);
        }
        else
        {
            enemy3Button.SetActive(true);
        }
    }
    void GameOver()
    {
        if (characters[0].GetComponent<Character>().isDead == true && characters[1].GetComponent<Character>().isDead == true && characters[2].GetComponent<Character>().isDead == true)
        {
            isDefeated = true;
        }
    }
    void RandomNumber()
    {
        attackNumber = Random.Range(0, attackableCharacters.Count);
        wait = false;
    }

    public void AttackButton()
    {
        attacked = true;
        ButtonChecker();
    }

    public void AttackEnemy1()
    {
        characterPicked = true;
        attackNumber = 0;
        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);
    }

    public void AttackEnemy2()
    {
        characterPicked = true;
        attackNumber = 1;
        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);
    }

    public void AttackEnemy3()
    {
        characterPicked = true;
        attackNumber = 2;
        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);
    }
}
