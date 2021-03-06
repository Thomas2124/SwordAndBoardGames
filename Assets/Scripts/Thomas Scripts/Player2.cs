﻿using System.Collections;
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
    public GameObject attackButton;
    public GameObject defendButton;
    public GameObject specialButton;
    public int enemiesDefending = 0;
    public bool defending;
    public bool special;
    public List<int> characterAttackNumbers;
    public int targetNum;
    public int timerNum;
    public float nextTime;
    public Text timerText;

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
        attackButton = GameObject.FindGameObjectWithTag("Attack2");
        defendButton = GameObject.FindGameObjectWithTag("Defend2");
        specialButton = GameObject.FindGameObjectWithTag("Special2");
    }

    void Update()
    {
        timerText = GameObject.FindGameObjectWithTag("P2timer").GetComponent<Text>();
        if (once == false)
        {
            timerNum = 60;
            timerText.enabled = false;
            enemy1Button.SetActive(false);
            enemy2Button.SetActive(false);
            enemy3Button.SetActive(false);
            characterAttackNumbers.Clear();
            CharacterReset();
            once = true;
        }

        enemyCharacters = opponent.GetComponent<Player1>().characters; //enemy characters = opponents characters
        playerText = GameObject.FindGameObjectWithTag("PlayerText").GetComponent<Text>();
        charatext = GameObject.FindGameObjectWithTag("CharacterText").GetComponent<Text>();

        if (isMyTurn == true)
        {
            playerText.text = "Player 2 Turn";
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
            Character script = characters[0].GetComponent<Character>();
            charatext.text = characters[0].name;
            if (script.isDead == false)
            {
                if (attacked == true)
                {
                    script.isAttacking = true;
                    if (characterPicked == true)
                    {
                        BoolSetter(0);
                    }
                }

                if (defending == true)
                {
                    script.isDefending = true;
                    BoolSetter(0);
                }

                if (special == true)
                {
                    script.useSpecial = true;
                    BoolSetter(0);
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
            Character script = characters[1].GetComponent<Character>();
            charatext.text = characters[1].name;
            if (script.isDead == false)
            {
                if (attacked == true)
                {
                    script.isAttacking = true;
                    if (characterPicked == true)
                    {
                        BoolSetter(1);
                    }
                }

                if (defending == true)
                {
                    script.isDefending = true;
                    BoolSetter(1);
                }

                if (special == true)
                {
                    script.useSpecial = true;
                    BoolSetter(1);
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
            Character script = characters[2].GetComponent<Character>();
            charatext.text = characters[2].name;
            if (script.isDead == false)
            {
                if (attacked == true)
                {
                    script.isAttacking = true;
                    if (characterPicked == true)
                    {
                        AttackingTurn();
                    }
                }

                if (defending == true)
                {
                    script.isDefending = true;
                    AttackingTurn();
                }

                if (special == true)
                {
                    script.useSpecial = true;
                    AttackingTurn();
                }

                SpecialButtonChecker(2);
            }
            else
            {
                AttackingTurn();
            }
        }

        GameOver();
        TurnTimer();
    }

    void TurnTimer()
    {
        if (Time.time > nextTime && isMyTurn == true)
        {
            timerText.enabled = true;
            nextTime = Time.time + 1f;
            timerNum -= 1;
            timerText.text = timerNum.ToString();
        }

        if (timerNum <= 0)
        {
            BoolSetter(2);
        }
    }

    void AttackingTurn()
    {
        PlayerTurnChecker(0);
        PlayerTurnChecker(1);
        PlayerTurnChecker(2);
        BoolSetter(2);
    }

    void PlayerTurnChecker(int character)
    {
        Character script = characters[character].GetComponent<Character>();
        if (script.isDead == false)
        {
            if (script.isAttacking == true)
            {
                if (character == 0)
                {
                    if (characterAttackNumbers != null)
                    {
                        targetNum = characterAttackNumbers[0];
                    }
                    else
                    {
                        targetNum = characterAttackNumbers[0];
                    }
                }

                if (character == 1)
                {
                    if (characterAttackNumbers.Count == 1)
                    {
                        targetNum = characterAttackNumbers[0];
                    }
                    else
                    {
                        targetNum = characterAttackNumbers[1];
                    }
                }

                if (character == 2)
                {
                    if (characterAttackNumbers.Count == 1)
                    {
                        targetNum = characterAttackNumbers[0];
                    }
                    else if (characterAttackNumbers.Count == 2)
                    {
                        targetNum = characterAttackNumbers[1];
                    }
                    else
                    {
                        targetNum = characterAttackNumbers[2];
                    }
                }

                PlayerAttack(character, targetNum);
            }

            if (script.isDefending == true)
            {
                PlayerDefend(character);
            }

            if (script.useSpecial == true)
            {
                PlayerSpecial(character);
            }
        }
    }

    void PlayerAttack(int character, int number) //Player Attack Option
    {
        EnemyDefending();
        if (enemiesDefending <= 0) //Checks for defend characters, if so spread damage amongst them
        {
            float defenceNum = attackableCharacters[number].GetComponent<Character>().defenceRating / 100f;
            attackableCharacters[number].GetComponent<Character>().TakeDamage(characters[character].GetComponent<Character>().attackRating * defenceNum);
            characters[character].GetComponent<Character>().specialBar += 25f;
            BoolSetter(character);
        }
        else
        {
            for (int i = 0; i < attackableCharacters.Count; i++)
            {
                float defenceNum = attackableCharacters[number].GetComponent<Character>().defenceRating / 100f;
                if (attackableCharacters[i].GetComponent<Character>().isDefending == true)
                {
                    float damage = characters[character].GetComponent<Character>().attackRating / enemiesDefending;
                    attackableCharacters[i].GetComponent<Character>().TakeDamage(damage * defenceNum);
                    characters[character].GetComponent<Character>().specialBar += 25f / enemiesDefending;
                }
            }

            BoolSetter(character);
        }
    }

    void PlayerDefend(int character) //Player Defend Option
    {
        BoolSetter(character);
    }

    void PlayerSpecial(int character) //Player Special Option
    {
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
                    enemy1Button.SetActive(true);
                }

                if (attackableCharacters[i].name == enemyCharacters[1].name)
                {
                    enemy2Button.SetActive(true);
                }

                if (attackableCharacters[i].name == enemyCharacters[2].name)
                {
                    enemy3Button.SetActive(true);
                }
            }
        }
    }

    public void TurnStarted() //Sets conditions for the start of the turn
    {
        CharacterReset();
        MainButtonTurnOn();
        characterAttackNumbers.Clear();
        enemiesDefending = 0;
        isMyTurn = true;
        characterPicked = false;
        attacked = false;
        defending = false;
        special = false;
        character1 = true;
        character2 = false;
        character3 = false;
        ButtonTurnOff();
    }

    void BoolSetter(int number) //Sets conditions for the characters
    {
        if (number == 0)
        {
            MainButtonTurnOn();
            character2 = true;
            character1 = false;
            attacked = false;
            defending = false;
            special = false;
            characterPicked = false;
        }

        if (number == 1)
        {
            MainButtonTurnOn();
            character3 = true;
            character2 = false;
            attacked = false;
            defending = false;
            special = false;
            characterPicked = false;
        }

        if (number == 2)
        {
            timerNum = 60;
            timerText.enabled = false;
            isMyTurn = false;
            character3 = false;
            characterPicked = false;
            attacked = false;
            defending = false;
            special = false;
            opponent.GetComponent<Player1>().TurnStarted();
        }
    }

    void CharacterReset()
    {
        foreach (GameObject item in characters)
        {
            Character theScript = item.GetComponent<Character>();
            theScript.isAttacking = false;
            theScript.isDefending = false;
            theScript.useSpecial = false;
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
        characterAttackNumbers.Add(attackNumber);
        ButtonTurnOff();
    }

    public void AttackEnemy2() //Option to attack middle enemy character
    {
        characterPicked = true;
        attackNumber = 1;
        characterAttackNumbers.Add(attackNumber);
        ButtonTurnOff();
    }

    public void AttackEnemy3() //Option to attack bottom enemy character
    {
        characterPicked = true;
        attackNumber = 2;
        characterAttackNumbers.Add(attackNumber);
        ButtonTurnOff();
    }

    void ButtonTurnOff() //turns off attack buttons
    {
        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);
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
