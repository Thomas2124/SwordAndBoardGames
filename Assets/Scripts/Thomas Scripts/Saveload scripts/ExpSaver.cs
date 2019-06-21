using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExpSaver
{
    [Header("fishman")]
    public float fishman_exp;

    [Header("werewolf")]
    public float werewolf_exp;

    [Header("bukkake Slime")]
    public float bukkakeSlime_exp;

    [Header("dragonoid")]
    public float dragonoid_exp;

    [Header("golem")]
    public float golem_exp;

    [Header("catperson")]
    public float catperson_exp;

    [Header("angel")]
    public float angel_exp;

    [Header("devil")]
    public float devil_exp;

    [Header("orge")]
    public float orge_exp;

    [Header("gargoyle")]
    public float gargoyle_exp;

    [Header("garuda")]
    public float garuda_exp;

    [Header("loxodon")]
    public float loxodon_exp;

    [Header("minotaur")]
    public float minotaur_exp;

    [Header("spiderperson")]
    public float spiderperson_exp;

    [Header("hobnoblin")]
    public float hobnoblin_exp;

    public ExpSaver(BattleManager myList)
    {
        fishman_exp = myList.fishman_exp;
        werewolf_exp = myList.werewolf_exp;
        bukkakeSlime_exp = myList.bukkakeSlime_exp;
        dragonoid_exp = myList.dragonoid_exp;
        golem_exp = myList.golem_exp;
        catperson_exp = myList.catperson_exp;
        angel_exp = myList.angel_exp;
        devil_exp = myList.devil_exp;
        orge_exp = myList.orge_exp;
        gargoyle_exp = myList.gargoyle_exp;
        garuda_exp = myList.garuda_exp;
        loxodon_exp = myList.loxodon_exp;
        minotaur_exp = myList.minotaur_exp;
        spiderperson_exp = myList.spiderperson_exp;
        hobnoblin_exp = myList.hobnoblin_exp;
    }
}
