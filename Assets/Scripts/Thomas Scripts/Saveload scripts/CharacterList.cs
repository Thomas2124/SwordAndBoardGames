using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public bool pickedCharacter;
    public bool pick1;
    public bool pick2;
    public bool pick3;

    public PlaceChecker checkerScript;

    [Header("First Character")]
    public string characterName;
    public float health = 200f;
    public float attackRating = 40f;
    public float defenceRating = 60f;
    public int level = 3;
    public float exp = 100f;

    [Header("Second Character")]
    public string characterName2;
    public float health2 = 150f;
    public float attackRating2 = 20f;
    public float defenceRating2 = 80f;
    public int level2 = 5;
    public float exp2 = 200f;

    [Header("Third Character")]
    public string characterName3;
    public float health3 = 250f;
    public float attackRating3 = 80f;
    public float defenceRating3 = 10f;
    public int level3 = 2;
    public float exp3 = 300f;

    [Header("Replace Stats")]
    public string n;
    public float h;
    public float a;
    public float d;
    public int l;
    public float e;

    [Header("fishman")]
    public string fishman_Name = "fishman";
    public float fishman_health = 50f;
    public float fishman_attackRating = 40f;
    public float fishman_defenceRating = 40f;
    public int fishman_level = 1;
    public float fishman_exp = 0f;

    [Header("werewolf")]
    public string werewolf_Name = "werewolf";
    public float werewolf_health = 140f;
    public float werewolf_attackRating = 70f;
    public float werewolf_defenceRating = 50f;
    public int werewolf_level = 1;
    public float werewolf_exp = 0f;

    [Header("bukkake Slime")]
    public string bukkakeSlime_Name = "bukkake Slime";
    public float bukkakeSlime_health = 140f;
    public float bukkakeSlime_attackRating = 100f;
    public float bukkakeSlime_defenceRating = 100f;
    public int bukkakeSlime_level = 1;
    public float bukkakeSlime_exp = 0f;

    [Header("dragonoid")]
    public string dragonoid_Name = "dragonoid";
    public float dragonoid_health = 80f;
    public float dragonoid_attackRating = 60f;
    public float dragonoid_defenceRating = 60f;
    public int dragonoid_level = 1;
    public float dragonoid_exp = 0f;

    [Header("golem")]
    public string golem_Name = "golem";
    public float golem_health = 200f;
    public float golem_attackRating = 70f;
    public float golem_defenceRating = 100f;
    public int golem_level = 1;
    public float golem_exp = 0f;

    [Header("catperson")]
    public string catperson_Name = "catperson";
    public float catperson_health = 100f;
    public float catperson_attackRating = 50f;
    public float catperson_defenceRating = 30f;
    public int catperson_level = 1;
    public float catperson_exp = 0f;

    [Header("angel")]
    public string angel_Name = "angel";
    public float angel_health = 200f;
    public float angel_attackRating = 100f;
    public float angel_defenceRating = 70f;
    public int angel_level = 1;
    public float angel_exp = 0f;

    [Header("devil")]
    public string devil_Name = "devil";
    public float devil_health = 180f;
    public float devil_attackRating = 90f;
    public float devil_defenceRating = 60f;
    public int devil_level = 1;
    public float devil_exp = 0f;

    [Header("orge")]
    public string orge_Name = "orge";
    public float orge_health = 100f;
    public float orge_attackRating = 30f;
    public float orge_defenceRating = 50f;
    public int orge_level = 1;
    public float orge_exp = 0f;

    [Header("gargoyle")]
    public string gargoyle_Name = "gargoyle";
    public float gargoyle_health = 140f;
    public float gargoyle_attackRating = 40f;
    public float gargoyle_defenceRating = 70f;
    public int gargoyle_level = 1;
    public float gargoyle_exp = 0f;

    [Header("garuda")]
    public string garuda_Name = "garuda";
    public float garuda_health = 50f;
    public float garuda_attackRating = 60f;
    public float garuda_defenceRating = 60f;
    public int garuda_level = 1;
    public float garuda_exp = 0f;

    [Header("loxodon")]
    public string loxodon_Name = "loxodon";
    public float loxodon_health = 180f;
    public float loxodon_attackRating = 60f;
    public float loxodon_defenceRating = 60f;
    public int loxodon_level = 1;
    public float loxodon_exp = 0f;

    [Header("minotaur")]
    public string minotaur_Name = "minotaur";
    public float minotaur_health = 140f;
    public float minotaur_attackRating = 50f;
    public float minotaur_defenceRating = 70f;
    public int minotaur_level = 1;
    public float minotaur_exp = 0f;

    [Header("spiderperson")]
    public string spiderperson_Name = "spiderperson";
    public float spiderperson_health = 120f;
    public float spiderperson_attackRating = 80f;
    public float spiderperson_defenceRating = 80f;
    public int spiderperson_level = 1;
    public float spiderperson_exp = 0f;

    [Header("hobnoblin")]
    public string hobnoblin_Name = "hobnoblin";
    public float hobnoblin_health = 100f;
    public float hobnoblin_attackRating = 50f;
    public float hobnoblin_defenceRating = 30f;
    public int hobnoblin_level = 1;
    public float hobnoblin_exp = 0f;

    public GameObject firstPlace;
    public GameObject secondPlace;
    public GameObject thirdPlace;
    // Start is called before the first frame update
    void Awake()
    {
        checkerScript = GameObject.Find("EGO place getter").GetComponent<PlaceChecker>();
        pickedCharacter = false;
        pick1 = true;
        pick2 = false;
        pick3 = false;
        if (ExpSaveSystem.LoadPlayer() == null)
        {
            
        }
        else
        {
            ExpSaver expData = ExpSaveSystem.LoadPlayer();
            fishman_exp = expData.fishman_exp;
            werewolf_exp = expData.werewolf_exp;
            bukkakeSlime_exp = expData.bukkakeSlime_exp;
            dragonoid_exp = expData.dragonoid_exp;
            golem_exp = expData.golem_exp;
            catperson_exp = expData.catperson_exp;
            angel_exp = expData.angel_exp;
            devil_exp = expData.devil_exp;
            orge_exp = expData.orge_exp;
            gargoyle_exp = expData.gargoyle_exp;
            garuda_exp = expData.garuda_exp;
            loxodon_exp = expData.loxodon_exp;
            minotaur_exp = expData.minotaur_exp;
            spiderperson_exp = expData.spiderperson_exp;
            hobnoblin_exp = expData.hobnoblin_exp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        firstPlace = checkerScript.firstCharacter;
        secondPlace = checkerScript.secondCharacter;
        thirdPlace = checkerScript.thirdCharacter;

        if (firstPlace != null)
        {
            CharacterSetter(firstPlace.tag, 1);
            ReplaceStats(1, n, h, a, d, l, e);
        }

        if (secondPlace != null)
        {
            CharacterSetter(secondPlace.tag, 2);
            ReplaceStats(2, n, h, a, d, l, e);
        }

        if (thirdPlace != null)
        {
            CharacterSetter(thirdPlace.tag, 3);
            ReplaceStats(3, n, h, a, d, l, e);
        }

        if (firstPlace != null && secondPlace != null && thirdPlace != null)
        {
            SaveStats();
        }
        /*if (pick1 == true)
        {
           if (pickedCharacter == true)
            {
                ReplaceStats(1, n, h, a, d, l, e);
                pick2 = true;
                pickedCharacter = false;
            }
        }

        if (pick2 == true)
        {
            pick1 = false;
            if (pickedCharacter == true)
            {
                ReplaceStats(2, n, h, a, d, l, e);
                pick3 = true;
                pickedCharacter = false;
            }
        }

        if (pick3 == true)
        {
            pick2 = false;
            if (pickedCharacter == true)
            {
                ReplaceStats(3, n, h, a, d, l, e);
                pickedCharacter = false;
                pick3 = false;
            }
        }*/
    }

    void CharacterSetter(string characterTag, int myNum)
    {
        string theName = characterTag;
        switch (theName)
        {
            case "fishman":
                Option1();
                break;
            case "werewolf":
                Option2();
                break;
            case "bukkake Slime":
                Option3();
                break;
            case "dragonoid":
                Option4();
                break;
            case "golem":
                Option5();
                break;
            case "catperson":
                Option6();
                break;
            case "angel":
                Option7();
                break;
            case "devil":
                Option8();
                break;
            case "orge":
                Option9();
                break;
            case "gargoyle":
                Option10();
                break;
            case "garuda":
                Option11();
                break;
            case "loxodon":
                Option12();
                break;
            case "minotaur":
                Option13();
                break;
            case "spiderperson":
                Option14();
                break;
            case "hobnoblin":
                Option15();
                break;
        }
    }

    void Character1Stats()
    {

    }

    public void SaveStats() //Saves data
    {
        SaveSystem.SavePlayer(this);
    }

    public void ReplaceStats(int number, string n, float h, float a, float d, int l, float e)
    {
        if (number == 1)
        {
            characterName = n;
            health = h;
            attackRating = a;
            defenceRating = d;
            level = l;
            exp = e;
        }

        if (number == 2)
        {
            characterName2 = n;
            health2 = h;
            attackRating2 = a;
            defenceRating2 = d;
            level2 = l;
            exp2 = e;
        }

        if (number == 3)
        {
            characterName3 = n;
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
        n = fishman_Name;
        h = fishman_health;
        a = fishman_attackRating;
        d = fishman_defenceRating;
        l = fishman_level;
        e = fishman_exp;
    }

    public void Option2()
    {
        pickedCharacter = true;
        n = werewolf_Name;
        h = werewolf_health;
        a = werewolf_attackRating;
        d = werewolf_defenceRating;
        l = werewolf_level;
        e = werewolf_exp;
    }

    public void Option3()
    {
        pickedCharacter = true;
        n = bukkakeSlime_Name;
        h = bukkakeSlime_health;
        a = bukkakeSlime_attackRating;
        d = bukkakeSlime_defenceRating;
        l = bukkakeSlime_level;
        e = bukkakeSlime_exp;
    }

    public void Option4()
    {
        pickedCharacter = true;
        n = dragonoid_Name;
        h = dragonoid_health;
        a = dragonoid_attackRating;
        d = dragonoid_defenceRating;
        l = dragonoid_level;
        e = dragonoid_exp;
    }

    public void Option5()
    {
        pickedCharacter = true;
        n = golem_Name;
        h = golem_health;
        a = golem_attackRating;
        d = golem_defenceRating;
        l = golem_level;
        e = golem_exp;
    }

    public void Option6()
    {
        pickedCharacter = true;
        n = catperson_Name;
        h = catperson_health;
        a = catperson_attackRating;
        d = catperson_defenceRating;
        l = catperson_level;
        e = catperson_exp;
    }

    public void Option7()
    {
        pickedCharacter = true;
        n = angel_Name;
        h = angel_health;
        a = angel_attackRating;
        d = angel_defenceRating;
        l = angel_level;
        e = angel_exp;
    }

    public void Option8()
    {
        pickedCharacter = true;
        n = devil_Name;
        h = devil_health;
        a = devil_attackRating;
        d = devil_defenceRating;
        l = devil_level;
        e = devil_exp;
    }

    public void Option9()
    {
        pickedCharacter = true;
        n = orge_Name;
        h = orge_health;
        a = orge_attackRating;
        d = orge_defenceRating;
        l = orge_level;
        e = orge_exp;
    }

    public void Option10()
    {
        pickedCharacter = true;
        n = gargoyle_Name;
        h = gargoyle_health;
        a = gargoyle_attackRating;
        d = gargoyle_defenceRating;
        l = gargoyle_level;
        e = gargoyle_exp;
    }

    public void Option11()
    {
        pickedCharacter = true;
        n = garuda_Name;
        h = garuda_health;
        a = garuda_attackRating;
        d = garuda_defenceRating;
        l = garuda_level;
        e = garuda_exp;
    }

    public void Option12()
    {
        pickedCharacter = true;
        n = loxodon_Name;
        h = loxodon_health;
        a = loxodon_attackRating;
        d = loxodon_defenceRating;
        l = loxodon_level;
        e = loxodon_exp;
    }

    public void Option13()
    {
        pickedCharacter = true;
        n = minotaur_Name;
        h = minotaur_health;
        a = minotaur_attackRating;
        d = minotaur_defenceRating;
        l = minotaur_level;
        e = minotaur_exp;
    }

    public void Option14()
    {
        pickedCharacter = true;
        n = spiderperson_Name;
        h = spiderperson_health;
        a = spiderperson_attackRating;
        d = spiderperson_defenceRating;
        l = spiderperson_level;
        e = spiderperson_exp;
    }

    public void Option15()
    {
        pickedCharacter = true;
        n = hobnoblin_Name;
        h = hobnoblin_health;
        a = hobnoblin_attackRating;
        d = hobnoblin_defenceRating;
        l = hobnoblin_level;
        e = hobnoblin_exp;
    }
}
