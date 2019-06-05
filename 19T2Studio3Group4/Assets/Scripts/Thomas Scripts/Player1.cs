using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
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
    public GameObject enemy4Button;
    public GameObject enemy5Button;
    public GameObject enemy6Button;
    public bool once = false;
    public GameObject attackButton;
    public GameObject defendButton;
    public GameObject specialButton;
    public int enemiesDefending = 0;
    public bool defending;
    public bool special;

    void Awake()
    {
        opponent = GameObject.FindGameObjectWithTag("Player2");
        attacked = false;
        characterPicked = false;
        character1 = true;
        character2 = false;
        character3 = false;
        enemy4Button = GameObject.FindGameObjectWithTag("Enemy4Button");
        enemy5Button = GameObject.FindGameObjectWithTag("Enemy5Button");
        enemy6Button = GameObject.FindGameObjectWithTag("Enemy6Button");
        attackButton = GameObject.FindGameObjectWithTag("AttackButton");
        defendButton = GameObject.FindGameObjectWithTag("Defend1");
        specialButton = GameObject.FindGameObjectWithTag("Special1");
    }

    void Update()
    {
        if (once == false)
        {
            enemy4Button.SetActive(false);
            enemy5Button.SetActive(false);
            enemy6Button.SetActive(false);
            once = true;
        }

        enemyCharacters = opponent.GetComponent<Player2>().characters; //enemy characters = opponents characters
        playerText = GameObject.FindGameObjectWithTag("PlayerText").GetComponent<Text>();
        charatext = GameObject.FindGameObjectWithTag("CharacterText").GetComponent<Text>();

        if (isMyTurn == true)
        {
            playerText.text = "Player 1 Turn";
        }
        else
        {
            MainButtonTurnOff();
            character1 = false;
            character2 = false;
            character3 = false;
        }

        for (int i = 0; i < enemyCharacters.Length; i++) //Adds characters to attackable characters list
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

        if (character1 == true) //Top Characters Turn
        {
            charatext.text = characters[0].name;
            if (characters[0].GetComponent<Character>().isDead == false)
            {
                if (attacked == true)
                {
                    characters[0].GetComponent<Character>().isAttacking = true;
                    characters[0].GetComponent<Character>().isDefending = false;
                    characters[0].GetComponent<Character>().useSpecial = false;
                    if (characterPicked == true)
                    {
                        EnemyDefending();
                        if (enemiesDefending <= 0) //Checks for defend characters, if so spread damage amongst them
                        {
                            attackableCharacters[attackNumber].GetComponent<Character>().TakeDamage(characters[0].GetComponent<Character>().attackRating);
                            characters[0].GetComponent<Character>().specialBar += 25f;
                            BoolSetter();
                        }
                        else
                        {
                            for (int i = 0; i < attackableCharacters.Count; i++)
                            {
                                if (attackableCharacters[i].GetComponent<Character>().isDefending == true)
                                {
                                    attackableCharacters[i].GetComponent<Character>().TakeDamage(characters[0].GetComponent<Character>().attackRating / enemiesDefending);
                                    characters[0].GetComponent<Character>().specialBar += 25f / enemiesDefending;
                                }
                            }

                            BoolSetter();
                        }
                    }
                }

                if (defending == true)
                {
                    characters[0].GetComponent<Character>().isAttacking = false;
                    characters[0].GetComponent<Character>().useSpecial = false;
                    characters[0].GetComponent<Character>().isDefending = true;
                    BoolSetter();
                }

                if (special == true)
                {
                    characters[0].GetComponent<Character>().isAttacking = false;
                    characters[0].GetComponent<Character>().isDefending = false;
                    characters[0].GetComponent<Character>().useSpecial = true;
                    foreach (GameObject item in attackableCharacters)
                    {
                        item.GetComponent<Character>().TakeDamage(characters[2].GetComponent<Character>().attackRating);
                    }
                    characters[0].GetComponent<Character>().specialBar = 0f;
                    BoolSetter();
                }

                if (characters[0].GetComponent<Character>().specialBar == 100f)
                {
                    specialButton.SetActive(true);
                }
                else
                {
                    specialButton.SetActive(false);
                }
            }
            else
            {
                BoolSetter();
            }
        }

        if (character2 == true) //Middle Characters Turn
        {
            charatext.text = characters[1].name;
            character1 = false;
            if (characters[1].GetComponent<Character>().isDead == false)
            {
                if (attacked == true)
                {
                    characters[1].GetComponent<Character>().isAttacking = true;
                    characters[1].GetComponent<Character>().isDefending = false;
                    characters[1].GetComponent<Character>().useSpecial = false;
                    if (characterPicked == true)
                    {
                        EnemyDefending();
                        if (enemiesDefending <= 0) //Checks for defend characters, if so spread damage amongst them
                        {
                            attackableCharacters[attackNumber].GetComponent<Character>().TakeDamage(characters[1].GetComponent<Character>().attackRating);
                            characters[1].GetComponent<Character>().specialBar += 25f;
                            BoolSetter2();
                        }
                        else
                        {
                            for (int i = 0; i < attackableCharacters.Count; i++)
                            {
                                if (attackableCharacters[i].GetComponent<Character>().isDefending == true)
                                {
                                    attackableCharacters[i].GetComponent<Character>().TakeDamage(characters[1].GetComponent<Character>().attackRating / enemiesDefending);
                                    characters[1].GetComponent<Character>().specialBar += 25f / enemiesDefending;
                                }
                            }

                            BoolSetter2();
                        }
                    }
                }

                if (defending == true)
                {
                    characters[1].GetComponent<Character>().isAttacking = false;
                    characters[1].GetComponent<Character>().useSpecial = false;
                    characters[1].GetComponent<Character>().isDefending = true;
                    BoolSetter2();
                }

                if (special == true)
                {
                    characters[1].GetComponent<Character>().isAttacking = false;
                    characters[1].GetComponent<Character>().isDefending = false;
                    characters[1].GetComponent<Character>().useSpecial = true;
                    foreach (GameObject item in attackableCharacters)
                    {
                        item.GetComponent<Character>().TakeDamage(characters[2].GetComponent<Character>().attackRating);
                    }
                    characters[1].GetComponent<Character>().specialBar = 0f;
                    BoolSetter2();
                }

                if (characters[1].GetComponent<Character>().specialBar == 100f)
                {
                    specialButton.SetActive(true);
                }
                else
                {
                    specialButton.SetActive(false);
                }
            }
            else
            {
                BoolSetter2();
            }
        }

        if (character3 == true) //Bottom Characters Turn
        {
            charatext.text = characters[2].name;
            character2 = false;

            if (characters[2].GetComponent<Character>().isDead == false)
            {
                if (attacked == true)
                {
                    characters[2].GetComponent<Character>().isAttacking = true;
                    characters[2].GetComponent<Character>().isDefending = false;
                    characters[2].GetComponent<Character>().useSpecial = false;
                    if (characterPicked == true)
                    {
                        EnemyDefending();
                        if (enemiesDefending <= 0) //Checks for defend characters, if so spread damage amongst them
                        {
                            attackableCharacters[attackNumber].GetComponent<Character>().TakeDamage(characters[2].GetComponent<Character>().attackRating);
                            characters[2].GetComponent<Character>().specialBar += 25f;
                            BoolSetter3();
                        }
                        else
                        {
                            for (int i = 0; i < attackableCharacters.Count; i++)
                            {
                                if (attackableCharacters[i].GetComponent<Character>().isDefending == true)
                                {
                                    attackableCharacters[i].GetComponent<Character>().TakeDamage(characters[2].GetComponent<Character>().attackRating / enemiesDefending);
                                    characters[2].GetComponent<Character>().specialBar += 25f / enemiesDefending;
                                }
                            }

                            BoolSetter3();
                        }
                    }
                }

                if (defending == true)
                {
                    characters[2].GetComponent<Character>().isAttacking = false;
                    characters[2].GetComponent<Character>().useSpecial = false;
                    characters[2].GetComponent<Character>().isDefending = true;
                    BoolSetter3();
                }

                if (special == true)
                {
                    characters[2].GetComponent<Character>().isAttacking = false;
                    characters[2].GetComponent<Character>().isDefending = false;
                    characters[2].GetComponent<Character>().useSpecial = true;
                    foreach(GameObject item in attackableCharacters)
                    {
                        item.GetComponent<Character>().TakeDamage(characters[2].GetComponent<Character>().attackRating);
                    }
                    characters[2].GetComponent<Character>().specialBar = 0f;
                    BoolSetter3();
                }

                if (characters[2].GetComponent<Character>().specialBar == 100f)
                {
                    specialButton.SetActive(true);
                }
                else
                {
                    specialButton.SetActive(false);
                }
            }
            else
            {
                BoolSetter3();
            }
        }

        GameOver();
    }

    void EnemyDefending() //Checks how many enemy character are defending
    {
        for (int i = 0; i < attackableCharacters.Count; i++)
        {
            if (attackableCharacters[i].GetComponent<Character>().isDefending == true)
            {
                enemiesDefending += 1;
            }
        }
    }

    void ButtonChecker() //Checks which opponents can be attacked
    {
        for (int i = 0; i < attackableCharacters.Count; i++)
        {
            if (attackableCharacters[i].GetComponent<Character>().isDead == false)
            {
                if (attackableCharacters[i].name == enemyCharacters[0].name)
                {
                    enemy4Button.SetActive(true);
                }

                if (attackableCharacters[i].name == enemyCharacters[1].name)
                {
                    enemy5Button.SetActive(true);
                }

                if (attackableCharacters[i].name == enemyCharacters[2].name)
                {
                    enemy6Button.SetActive(true);
                }
            }
        }
    }

    public void TurnStarted() //Sets conditions for the start of the turn
    {
        MainButtonTurnOn();
        enemiesDefending = 0;
        isMyTurn = true;
        characterPicked = false;
        attacked = false;
        defending = false;
        special = false;
        character1 = true;
        ButtonTurnOff();
    }

    void BoolSetter() //Sets conditions for the middle character
    {
        MainButtonTurnOn();
        character2 = true;
        attacked = false;
        defending = false;
        special = false;
        characterPicked = false;
    }

    void BoolSetter2() //Sets conditions for the bottom character
    {
        MainButtonTurnOn();
        character3 = true;
        attacked = false;
        defending = false;
        special = false;
        characterPicked = false;
    }

    void BoolSetter3() //Sets conditions for the end of the turn
    {
        isMyTurn = false;
        character3 = false;
        characterPicked = false;
        attacked = false;
        defending = false;
        special = false;
        opponent.GetComponent<Player2>().TurnStarted();
    }

    void GameOver() //Checks if player characters are dead
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

    public void AttackButton() //Option if player wants to attack
    {
        MainButtonTurnOff();
        attacked = true;
        defending = false;
        special = false;
        ButtonChecker();
    }

    public void SpecialButton() //Option if player wants to use the special move
    {
        special = true;
        attacked = false;
        defending = false;
    }

    public void DefendButton() //Option if player wants to defend
    {
        special = false;
        attacked = false;
        defending = true;
    }

    public void AttackEnemy1() //Option to attack top enemy character
    {
        characterPicked = true;
        attackNumber = 0;
        ButtonTurnOff();
    }

    public void AttackEnemy2() //Option to attack middle enemy character
    {
        characterPicked = true;
        attackNumber = 1;
        ButtonTurnOff();
    }

    public void AttackEnemy3() //Option to attack bottom enemy character
    {
        characterPicked = true;
        attackNumber = 2;
        ButtonTurnOff();
    }

    void ButtonTurnOff() //turns off attack buttons
    {
        enemy4Button.SetActive(false);
        enemy5Button.SetActive(false);
        enemy6Button.SetActive(false);
    }

    void MainButtonTurnOff() //turns off primary options buttons
    {
        attackButton.SetActive(false);
        defendButton.SetActive(false);
        specialButton.SetActive(false);
    }

    void MainButtonTurnOn() //turns on primary options buttons
    {
        attackButton.SetActive(true);
        defendButton.SetActive(true);
        specialButton.SetActive(true);
    }
}
