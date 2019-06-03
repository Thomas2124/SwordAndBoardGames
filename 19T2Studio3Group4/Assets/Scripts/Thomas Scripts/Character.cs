using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float health = 100f;
    public float attackRating = 10f;
    public float defenceRating = 10f;
    public float specialBar = 0f;
    public int level = 1;
    public float exp = 0f;
    public bool isDead = false;
    public bool isAttacking = false;
    public Image healthBar;
    // Start is called before the first frame update
    void Awake()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 100f;
        if (health <= 0f)
        {
            isDead = true;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    public void GainExp()
    {

    }

    public void GainLevel()
    {

    }
}
