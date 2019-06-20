using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaRolls : MonoBehaviour
{
    //Gacha Variables
    private int ranNum;
    private string rarityRolled;
    public string[] characterlistSR;
    public string[] characterlistR;
    public string[] characterlistUC;
    public string[] characterlistC;
    public List<string> characterRolled;

    //Result Variables
    public Text raceText;
    public Image resultSprite;
    public Image resultRarity;
    public Sprite[] characterSprite;
    public Sprite[] rarity;


    //Level Up Variables
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
        
    }

    public void NormalRoll()
    {
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
        resultSprite.GetComponent<SpriteRenderer>().sprite = characterSprite[ranNum];
        raceText.text = characterRolled[0];
        resultRarity.GetComponent<SpriteRenderer>().sprite = rarity[0];
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
                    fishman_exp += 50f;
                    break;
                case "werewolf":
                    werewolf_exp += 50f;
                    break;
                case "bukkake Slime":
                    bukkakeSlime_exp += 50f;
                    break;
                case "dragonoid":
                    dragonoid_exp += 50f;
                    break;
                case "golem":
                    golem_exp += 50f;
                    break;
                case "catperson":
                    catperson_exp += 50f;
                    break;
                case "angel":
                    angel_exp += 50f;
                    break;
                case "devil":
                    devil_exp += 50f;
                    break;
                case "orge":
                    orge_exp += 50f;
                    break;
                case "gargoyle":
                    gargoyle_exp += 50f;
                    break;
                case "garuda":
                    garuda_exp += 50f;
                    break;
                case "loxodon":
                    loxodon_exp += 50f;
                    break;
                case "minotaur":
                    minotaur_exp += 50f;
                    break;
                case "spiderperson":
                    spiderperson_exp += 50f;
                    break;
                case "hobnoblin":
                    hobnoblin_exp += 50f;
                    break;
            }
        }
        characterRolled.Clear();
        //Saves the characters experience into the savefile
    }
}
