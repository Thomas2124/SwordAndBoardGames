using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public float attackRating;
    public float defenceRating;
    public int level;
    public float exp;

    public PlayerData(CharacterList myList)
    {
        health = myList.health;
        attackRating = myList.attackRating;
        defenceRating = myList.defenceRating;
        level = myList.level;
        exp = myList.exp;
    }
}
