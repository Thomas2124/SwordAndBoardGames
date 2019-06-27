using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaRolls : MonoBehaviour
{
    //Gacha Variables
    private int ranNum;                     //generated number that represents the character pulled         
    public string[] characterlistSR;        //lists of the characters in their respective rarity
    public string[] characterlistR;
    public string[] characterlistUC;
    public string[] characterlistC;
    public List<string> characterRolled;    //character names pulled during the current roll
    private bool normRoll;                  //affects what kind of summary page is shown

    //Obtained? Variables
    public bool fishman = false;
    public bool werewolf = false;
    public bool bukkakeSlime = false;
    public bool dragonoid = false;
    public bool golem = false;
    public bool catperson = false;
    public bool angel = false;
    public bool devil = false;
    public bool orge = false;
    public bool gargoyle = false;
    public bool garuda = false;
    public bool loxodon = false;
    public bool minotaur = false;
    public bool spiderperson = false;
    public bool hobnoblin = false;

    //Result Variables
    public Text raceText;                   //the name of the character pulled displayed
    public Image resultSprite;              //the sprite image of pulled character displayed
    public Image resultRarity;              //the rarity image of pulled character displayed
    public Sprite[] characterSprite;        //corresponding character sprite data
    public Sprite[] rarity;                 //corresponding rarity sprite data
    public GameObject[] normSummary;        //normal roll summary page, how many images to show


    //Level Up Variables
    private float expGained = 300f;
    public float fishman_exp;
    public float werewolf_exp;
    public float bukkakeSlime_exp;
    public float dragonoid_exp;
    public float golem_exp;
    public float catperson_exp;
    public float angel_exp;
    public float devil_exp;
    public float orge_exp;
    public float gargoyle_exp;
    public float garuda_exp; 
    public float loxodon_exp;
    public float minotaur_exp;
    public float spiderperson_exp;
    public float hobnoblin_exp;

    // Start is called before the first frame update
    void Start()
    {
        if (GachaSaveSystem.LoadPlayer() == null)
        {

        }
        else
        {
            GachaExpList expData = GachaSaveSystem.LoadPlayer();
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

    public void NormalRoll()
    {
        normRoll = true;
        //rolls a random number to determine rarity class
        ranNum = Random.Range(0, 19);
        // rarity is split into a groups of varying chance to be selected
        if(ranNum == 0)
        {
            // randomly selects character within the array for the result
            //Super Rare
            ranNum = Random.Range(0, characterlistSR.Length -1);
            characterRolled.Add(characterlistSR[ranNum]);
            Results();
        }
        if (ranNum >= 1 && ranNum <= 3)
        {
            //Rare
            ranNum = Random.Range(0, characterlistR.Length -1);
            characterRolled.Add(characterlistR[ranNum]);
            Results();
        }
        if (ranNum >= 4 && ranNum <= 9)
        {
            //Uncommon
            ranNum = Random.Range(0, characterlistUC.Length -1);
            characterRolled.Add(characterlistUC[ranNum]);
            Results();
        }
        if (ranNum >= 10 && ranNum <= 19)
        {
            //Commmon
            ranNum = Random.Range(0, characterlistC.Length -1);
            characterRolled.Add(characterlistC[ranNum]);
            Results();
        }
    }

    public void Results()
    {
        //the results of the pull are generated 
        resultSprite.GetComponent<Image>().sprite = characterSprite[ranNum];
        raceText.text = characterRolled[0];
        resultRarity.GetComponent<Image>().sprite = rarity[0];
        normSummary[0].SetActive(true);
        normSummary[0].GetComponent<Image>().sprite = characterSprite[ranNum];
    }

    public void Levelup()
    {

        //Adds the experience from getting a duplicate character
        foreach(string item in characterRolled)
        {
            string checkname = item;
            switch (checkname)
            {
                case "fishman":
                    if(fishman == true)
                    {
                        fishman_exp += expGained;
                    }
                    else
                    {
                        fishman = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                        //add to obtained list (talk with thomas)
                    }
                    break;
                case "werewolf":
                    if (werewolf == true)
                    {
                        werewolf_exp += expGained;
                    }
                    else
                    {
                        werewolf = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "bukkake Slime":
                    if (bukkakeSlime == true)
                    {
                        bukkakeSlime_exp += expGained;
                    }
                    else
                    {
                        bukkakeSlime = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "dragonoid":
                    if (dragonoid == true)
                    {
                        dragonoid_exp += expGained;
                    }
                    else
                    {
                        dragonoid = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "golem":
                    if (golem == true)
                    {
                        golem_exp += expGained;
                    }
                    else
                    {
                        golem = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "catperson":
                    if (catperson == true)
                    {
                        catperson_exp += expGained;
                    }
                    else
                    {
                        catperson = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "angel":
                    if (angel == true)
                    {
                        angel_exp += expGained;
                    }
                    else
                    {
                        angel = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "devil":
                    if (devil == true)
                    {
                        devil_exp += expGained;
                    }
                    else
                    {
                        devil = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "orge":
                    if (orge == true)
                    {
                        orge_exp += expGained;
                    }
                    else
                    {
                        orge = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "gargoyle":
                    if (gargoyle == true)
                    {
                        gargoyle_exp += expGained;
                    }
                    else
                    {
                        gargoyle = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "garuda":
                    if (garuda == true)
                    {
                        garuda_exp += expGained;
                    }
                    else
                    {
                        garuda = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "loxodon":
                    if (loxodon == true)
                    {
                        loxodon_exp += expGained;
                    }
                    else
                    {
                        loxodon = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "minotaur":
                    if (minotaur == true)
                    {
                        minotaur_exp += expGained;
                    }
                    else
                    {
                        minotaur = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "spiderperson":
                    if (spiderperson == true)
                    {
                        spiderperson_exp += expGained;
                    }
                    else
                    {
                        spiderperson = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
                case "hobnoblin":
                    if (hobnoblin == true)
                    {
                        hobnoblin_exp += expGained;
                    }
                    else
                    {
                        hobnoblin = true;
                        GetComponent<PlayerCharacterList>().myCharacters.Add(checkname);
                    }
                    break;
            }
        }

        //Saves the characters experience into the savefile
        GachaSaveSystem.SavePlayer(this);

        characterRolled.Clear();
    }
}
