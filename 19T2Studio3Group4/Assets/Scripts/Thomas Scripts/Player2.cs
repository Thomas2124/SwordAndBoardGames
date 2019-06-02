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
    public Text charatext;

    void Awake()
    {
        opponent = GameObject.FindGameObjectWithTag("Player1");
        enemyCharacters = opponent.GetComponent<Player1>().characters;
    }

    // Update is called once per frame
    void Update()
    {
        charatext = GameObject.FindGameObjectWithTag("CharacterText").GetComponent<Text>();
        if (isMyTurn == true)
        {
            StartCoroutine(PlayerTurn());
        }
        else
        {
            StopCoroutine(PlayerTurn());
        }
    }

    void GameOver()
    {

    }

    IEnumerator PlayerTurn()
    {
        characters[0].GetComponent<Character>().isAttacking = true;
        charatext.text = characters[0].name;
        yield return new WaitForSeconds(2f);
        characters[1].GetComponent<Character>().isAttacking = true;
        charatext.text = characters[1].name;
        yield return new WaitForSeconds(2f);
        characters[2].GetComponent<Character>().isAttacking = true;
        charatext.text = characters[2].name;
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < characters.Length; i++)
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
                    else
                    {
                        targetEnemy.GetComponent<Character>().TakeDamage(damage);
                    }
                    print("Hit");
                }
                yield return new WaitForSeconds(2f);
            }

        }


        yield return new WaitForSeconds(10f);
        isMyTurn = false;
        opponent.GetComponent<Player1>().isMyTurn = true;
        /*else
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
