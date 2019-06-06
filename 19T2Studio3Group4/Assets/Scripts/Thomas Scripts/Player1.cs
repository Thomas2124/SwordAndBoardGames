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
                    PlayerAttack(0);
                }

                if (defending == true)
                {
                    PlayerDefend(0);
                }

                if (special == true)
                {
                    PlayerSpecial(0);
                }

                SpecialButtonChecker(0);
            }
            else
            {
                BoolSetter(0);
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
                    PlayerAttack(1);
                }

                if (defending == true)
                {
                    PlayerDefend(1);
                }

                if (special == true)
                {
                    PlayerSpecial(1);
                }

                SpecialButtonChecker(1);
            }
            else
            {
                BoolSetter(1);
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
                    PlayerAttack(2);
                }

                if (defending == true)
                {
                    PlayerDefend(2);
                }

                if (special == true)
                {
                    PlayerSpecial(2);
                }

                SpecialButtonChecker(2);
            }
            else
            {
                BoolSetter(2);
            }
        }

        GameOver();
    }

    void PlayerAttack(int character) //Player Attack Option
    {
        characters[character].GetComponent<Character>().isAttacking = true;
        characters[character].GetComponent<Character>().isDefending = false;
        characters[character].GetComponent<Character>().useSpecial = false;
        if (characterPicked == true)
        {
            EnemyDefending();
            if (enemiesDefending <= 0) //Checks for defend characters, if so spread damage amongst them
            {
                attackableCharacters[attackNumber].GetComponent<Character>().TakeDamage(characters[character].GetComponent<Character>().attackRating);
                characters[character].GetComponent<Character>().specialBar += 25f;
                BoolSetter(character);
            }
            else
            {
                for (int i = 0; i < attackableCharacters.Count; i++)
                {
                    if (attackableCharacters[i].GetComponent<Character>().isDefending == true)
                    {
                        attackableCharacters[i].GetComponent<Character>().TakeDamage(characters[character].GetComponent<Character>().attackRating / enemiesDefending);
                        characters[character].GetComponent<Character>().specialBar += 25f / enemiesDefending;
                    }
                }

                BoolSetter(character);
            }
        }
    }

    void PlayerDefend(int character) //Player Defend Option
    {
        characters[character].GetComponent<Character>().isAttacking = false;
        characters[character].GetComponent<Character>().useSpecial = false;
        characters[character].GetComponent<Character>().isDefending = true;
        BoolSetter(character);
    }

    void PlayerSpecial(int character) //Player Special Option
    {
        characters[character].GetComponent<Character>().isAttacking = false;
        characters[character].GetComponent<Character>().isDefending = false;
        characters[character].GetComponent<Character>().useSpecial = true;
        foreach (GameObject item in attackableCharacters)
        {
            item.GetComponent<Character>().TakeDamage(characters[character].GetComponent<Character>().attackRating);
        }
        characters[character].GetComponent<Character>().specialBar = 0f;
        BoolSetter(character);
    }

    void SpecialButtonChecker(int character) //activates special button 
    {
        if (characters[character].GetComponent<Character>().specialBar == 100f)
        {
            specialButton.SetActive(true);
        }
        else
        {
            specialButton.SetActive(false);
        }
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

    void BoolSetter(int number) //Sets conditions for the characters
    {
        if (number == 0)
        {
            MainButtonTurnOn();
            character2 = true;
            attacked = false;
            defending = false;
            special = false;
            characterPicked = false;
        }

        if (number == 1)
        {
            MainButtonTurnOn();
            character3 = true;
            attacked = false;
            defending = false;
            special = false;
            characterPicked = false;
        }

        if (number == 2)
        {
            isMyTurn = false;
            character3 = false;
            characterPicked = false;
            attacked = false;
            defending = false;
            special = false;
            opponent.GetComponent<Player2>().TurnStarted();
        }
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
