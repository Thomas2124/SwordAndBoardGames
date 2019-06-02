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

    // Start is called before the first frame update
    void Awake()
    {
        opponent = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        enemyCharacters = opponent.GetComponent<Player2>().characters;

        charatext = GameObject.FindGameObjectWithTag("CharacterText").GetComponent<Text>();
        if (isMyTurn == true)
        {
            StartCoroutine(PlayerTurn());
        }
        else
        {
            StopAllCoroutines();
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
    }

    void GameOver()
    {
        if (characters[0].GetComponent<Character>().isDead == true && characters[1].GetComponent<Character>().isDead == true && characters[2].GetComponent<Character>().isDead == true)
        {
            isDefeated = true;
        }
    }

    IEnumerator PlayerTurn()
    {
        bool hit = false;
        characters[0].GetComponent<Character>().isAttacking = true;
        charatext.text = characters[0].name;
        if (hit == false)
        {
            attackableCharacters[Random.Range(0, attackableCharacters.Count)].GetComponent<Character>().health -= characters[0].GetComponent<Character>().attackRating;
            hit = true;
        }

        yield return new WaitForSeconds(2f);

        bool hit2 = false;
        characters[1].GetComponent<Character>().isAttacking = true;
        charatext.text = characters[1].name;
        if (hit2 == false)
        {
            attackableCharacters[Random.Range(0, attackableCharacters.Count)].GetComponent<Character>().health -= characters[1].GetComponent<Character>().attackRating;
            hit2 = true;
        }


        yield return new WaitForSeconds(2f);

        bool hit3 = false;
        characters[2].GetComponent<Character>().isAttacking = true;
        charatext.text = characters[2].name;
        if (hit3 == false)
        {
            attackableCharacters[Random.Range(0, attackableCharacters.Count)].GetComponent<Character>().health -= characters[2].GetComponent<Character>().attackRating;
            hit3 = true;
        }
        yield return new WaitForSeconds(2f);
        opponent.GetComponent<Player2>().isMyTurn = true;
        isMyTurn = false;

        /*for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].GetComponent<Character>().isAttacking == true)
            {
                int randomNum = Random.Range(0, 3);
                float damage = characters[i].GetComponent<Character>().attackRating;
                GameObject targetEnemy = enemyCharacters[randomNum];
                if (targetEnemy.GetComponent<Character>().isDead == false)
                {
                    if (targetEnemy.GetComponent<Character>().isAttacking == false)
                    {
                        float chance = Random.Range(1f, 100f);
                        if (chance >= 50f)
                        {
                            targetEnemy.GetComponent<Character>().TakeDamage(damage);
                            print("Hit");
                        }
                        else
                        {
                            print("Blocked");
                        }
                    }
                }
                yield return new WaitForSeconds(2f);
            }
        }
        else
        {
            for (int j = 0; j < enemyCharacters.Length; j++)
            {
                if (enemyCharacters[j].GetComponent<Character>().isDead == false)
                {
                    if (enemyCharacters[j].GetComponent<Character>().isAttacking == false)
                    {
                        float chance = Random.Range(1f, 100f);
                        if (chance >= 50f)
                        {
                            enemyCharacters[j].GetComponent<Character>().TakeDamage(damage);
                            j = enemyCharacters.Length;
                        }
                        else
                        {
                            print("Blocked");
                            j = enemyCharacters.Length;
                        }
                    }
                    else
                    {
                        enemyCharacters[j].GetComponent<Character>().TakeDamage(damage);
                        j = enemyCharacters.Length;
                    }
                }
            }
        }*/
    }
}
