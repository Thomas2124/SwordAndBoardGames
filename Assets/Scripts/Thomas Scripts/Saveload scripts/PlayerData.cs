using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [Header("First Character")]
    public string characterName;
    public float health;
    public float attackRating;
    public float defenceRating;

    [Header("Second Character")]
    public string characterName2;
    public float health2;
    public float attackRating2;
    public float defenceRating2;

    [Header("Third Character")]
    public string characterName3;
    public float health3;
    public float attackRating3;
    public float defenceRating3;

    public PlayerData(CharacterList myList)
    {
        characterName = myList.characterName;
        health = myList.health;
        attackRating = myList.attackRating;
        defenceRating = myList.defenceRating;

        characterName2 = myList.characterName2;
        health2 = myList.health2;
        attackRating2 = myList.attackRating2;
        defenceRating2 = myList.defenceRating2;

        characterName3 = myList.characterName3;
        health3 = myList.health3;
        attackRating3 = myList.attackRating3;
        defenceRating3 = myList.defenceRating3;
    }
}
