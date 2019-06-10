using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public bool pickedCharacter;
    public bool pick1;
    public bool pick2;
    public bool pick3;
    [Header("First Character")]
    public float health = 200f;
    public float attackRating = 40f;
    public float defenceRating = 60f;
    public int level = 3;
    public float exp = 100f;
    [Header("Second Character")]
    public float health2 = 150f;
    public float attackRating2 = 20f;
    public float defenceRating2 = 80f;
    public int level2 = 5;
    public float exp2 = 200f;
    [Header("Third Character")]
    public float health3 = 250f;
    public float attackRating3 = 80f;
    public float defenceRating3 = 10f;
    public int level3 = 2;
    public float exp3 = 300f;
    [Header("Replace Stats")]
    public float h;
    public float a;
    public float d;
    public int l;
    public float e;
    // Start is called before the first frame update
    void Awake()
    {
        pickedCharacter = false;
        pick1 = true;
        pick2 = false;
        pick3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pick1 == true)
        {
            if (pickedCharacter == true)
            {
                ReplaceStats(1, h, a, d, l, e);
                pick2 = true;
                pickedCharacter = false;
            }
        }

        if (pick2 == true)
        {
            pick1 = false;
            if (pickedCharacter == true)
            {
                ReplaceStats(2, h, a, d, l, e);
                pick3 = true;
                pickedCharacter = false;
            }
        }

        if (pick3 == true)
        {
            pick2 = false;
            if (pickedCharacter == true)
            {
                ReplaceStats(3, h, a, d, l, e);
                pickedCharacter = false;
                pick3 = false;
            }
        }
    }

    void Character1Stats()
    {

    }

    public void SaveStats() //Saves data
    {
        SaveSystem.SavePlayer(this);
    }

    public void ReplaceStats(int number, float h, float a, float d, int l, float e)
    {
        if (number == 1)
        {
            health = h;
            attackRating = a;
            defenceRating = d;
            level = l;
            exp = e;
        }

        if (number == 2)
        {
            health2 = h;
            attackRating2 = a;
            defenceRating2 = d;
            level2 = l;
            exp2 = e;
        }

        if (number == 3)
        {
            health3 = h;
            attackRating3 = a;
            defenceRating3 = d;
            level3 = l;
            exp3 = e;
        }
    }

    public void Option1()
    {
        pickedCharacter = true;
        h = 100f;
        a = 10f;
        d = 10f;
        l = 1;
        e = 100f;
    }

    public void Option2()
    {
        pickedCharacter = true;
        h = 200f;
        a = 20f;
        d = 20f;
        l = 2;
        e = 200f;
    }

    public void Option3()
    {
        pickedCharacter = true;
        h = 300f;
        a = 30f;
        d = 30f;
        l = 3;
        e = 300f;
    }

    public void Option4()
    {
        pickedCharacter = true;
        h = 400f;
        a = 40f;
        d = 40f;
        l = 4;
        e = 400f;
    }
}
