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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 100f;
    }

    public void Attack()
    {

    }

    public void Defence()
    {

    }

    public void Special()
    {

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isDead = true;
        }
    }

    public void GainExp()
    {

    }

    public void GainLevel()
    {

    }
}
