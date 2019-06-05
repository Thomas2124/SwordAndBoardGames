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
    public GameObject attackButton;
    public GameObject defendButton;
    public GameObject specialButton;
    public int enemiesDefending = 0;
    public bool defending;
    public bool special;

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
            playerText.text = "Player 2 Turn";
        }
        else
        {
            MainButtonTurnOff();
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

        GameOver();

        if (character1 == true)
        {
            charatext.text = characters[0].name;
            if (characters[0].GetComponent<Character>().isDead == false)
            {
                if (attacked == true)
                {
                    //RandomNumber();
                    characters[0].GetComponent<Character>().isAttacking = true;
                    characters[0].GetComponent<Character>().isDefending = false;
                    characters[0].GetComponent<Character>().useSpecial = false;
                    if (characterPicked == true)
                    {
                        EnemyDefending();
                        if (enemiesDefending <= 0)
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
                    for (int i = 0; i < attackableCharacters.Count; i++)
                    {
                        attackableCharacters[i].GetComponent<Character>().TakeDamage(characters[0].GetComponent<Character>().attackRating);
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

        if (character2 == true)
        {
            charatext.text = characters[1].name;
            character1 = false;
            if (characters[1].GetComponent<Character>().isDead == false)
            {
                if (attacked == true)
                {
                    //RandomNumber();
                    characters[1].GetComponent<Character>().isAttacking = true;
                    characters[1].GetComponent<Character>().isDefending = false;
                    characters[1].GetComponent<Character>().useSpecial = false;
                    if (characterPicked == true)
                    {
                        EnemyDefending();
                        if (enemiesDefending <= 0)
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
                    for (int i = 0; i < attackableCharacters.Count; i++)
                    {
                        attackableCharacters[i].GetComponent<Character>().TakeDamage(characters[1].GetComponent<Character>().attackRating);
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

        if (character3 == true)
        {
            charatext.text = characters[2].name;
            character2 = false;

            if (characters[2].GetComponent<Character>().isDead == false)
            {
                if (attacked == true)
                {
                    //RandomNumber();
                    characters[2].GetComponent<Character>().isAttacking = true;
                    characters[2].GetComponent<Character>().isDefending = false;
                    characters[2].GetComponent<Character>().useSpecial = false;
                    if (characterPicked == true)
                    {
                        EnemyDefending();
                        if (enemiesDefending <= 0)
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
                    for (int i = 0; i < attackableCharacters.Count; i++)
                    {
                        attackableCharacters[i].GetComponent<Character>().TakeDamage(characters[2].GetComponent<Character>().attackRating);
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
    }

    void EnemyDefending()
    {
        for (int i = 0; i < attackableCharacters.Count; i++)
        {
            if (attackableCharacters[i].GetComponent<Character>().isDefending == true)
            {
                enemiesDefending += 1;
            }
        }
    }

    void ButtonChecker()
    {
        /*foreach (GameObject item in attackableCharacters)
        {
            if (item.GetComponent<Character>().isDead == true)
            {
                attackableCharacters.Remove(item);
            }
        }*/

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

    public void TurnStarted()
    {
        MainButtonTurnOn();
        isMyTurn = true;
        characterPicked = false;
        attacked = false;
        defending = false;
        special = false;
        character1 = true;
        ButtonTurnOff();
    }

    void BoolSetter()
    {
        MainButtonTurnOn();
        character2 = true;
        attacked = false;
        defending = false;
        special = false;
        characterPicked = false;
    }

    void BoolSetter2()
    {
        MainButtonTurnOn();
        character3 = true;
        attacked = false;
        defending = false;
        special = false;
        characterPicked = false;
    }

    void BoolSetter3()
    {
        isMyTurn = false;
        character3 = false;
        characterPicked = false;
        attacked = false;
        defending = false;
        special = false;
        opponent.GetComponent<Player1>().TurnStarted();
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
        MainButtonTurnOff();
        attacked = true;
        defending = false;
        special = false;
        ButtonChecker();
    }

    public void SpecialButton()
    {
        special = true;
        attacked = false;
        defending = false;
    }

    public void DefendButton()
    {
        special = false;
        attacked = false;
        defending = true;
    }

    public void AttackEnemy1()
    {
        characterPicked = true;
        attackNumber = 0;
        ButtonTurnOff();
    }

    public void AttackEnemy2()
    {
        characterPicked = true;
        attackNumber = 1;
        ButtonTurnOff();
    }

    public void AttackEnemy3()
    {
        characterPicked = true;
        attackNumber = 2;
        ButtonTurnOff();
    }

    void ButtonTurnOff()
    {
        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);
    }

    void MainButtonTurnOff()
    {
        attackButton.SetActive(false);
        defendButton.SetActive(false);
        specialButton.SetActive(false);
    }

    void MainButtonTurnOn()
    {
        attackButton.SetActive(true);
        defendButton.SetActive(true);
        specialButton.SetActive(true);
    }
}
