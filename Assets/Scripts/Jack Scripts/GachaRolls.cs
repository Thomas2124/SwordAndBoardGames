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
    public List<string> characterRolled; //character names pulled during the current roll

    //Result Variables
    public Text raceText;                   //the name of the character pulled displayed
    public Image resultSprite;              //the sprite image of pulled character displayed
    public Image resultRarity;              //the rarity image of pulled character displayed
    public Sprite[] characterSpriteSR;        //corresponding character sprite data
    public Sprite[] characterSpriteR;
    public Sprite[] characterSpriteUC;
    public Sprite[] characterSpriteC;
    public Sprite[] rarity;                 //corresponding rarity sprite data
    public GameObject[] normSummary;        //normal roll summary page, how many images to show
    [SerializeField] private string selCharRarity;
    public Text[] summaryText;

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
    public string selectedCharacter;
    public GameObject obtainedCharacters;
    public float rankBonus = .25f;
    [SerializeField] private float commonLimit = 1.25f;
    [SerializeField] private float uncommonLimit = 1.5f;
    [SerializeField] private float rareLimit = 1.75f;
    [SerializeField] private float superrareLimit = 2f;
    
    //Augmentation Variables c = 1.25 / uc = 1.5 / r = 1.75 / sr = 2
    //                                                          
    public float fishmanStarLevel = 1;
    public float werewolfStarLevel = 1;
    public float bukkakeSlimeStarLevel = 1;
    public float dragonoidStarLevel = 1;
    public float golemStarLevel = 1;
    public float catpersonStarLevel = 1;
    public float angelStarLevel = 1;
    public float devilStarLevel = 1;
    public float orgeStarLevel = 1;
    public float gargoyleStarLevel = 1;
    public float garudaStarLevel = 1;
    public float loxodonStarLevel = 1;
    public float minotaurStarLevel = 1;
    public float spiderpersonStarLevel = 1;
    public float hobnoblinStarLevel = 1;

    // Start is called before the first frame update
    void Start()
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
            selCharRarity = "Super Rare";
            ranNum = Random.Range(0, characterlistSR.Length -1);
            characterRolled.Add(characterlistSR[ranNum]);
            Debug.Log(characterlistSR[ranNum] + " is rolled");
            Results();
        }
        if (ranNum >= 1 && ranNum <= 3)
        {
            //Rare
            selCharRarity = "Rare";
            ranNum = Random.Range(0, characterlistR.Length -1);
            characterRolled.Add(characterlistR[ranNum]);
            Debug.Log(characterlistR[ranNum] + " is rolled");
            Results();
        }
        if (ranNum >= 4 && ranNum <= 9)
        {
            //Uncommon
            selCharRarity = "Uncommon";
            ranNum = Random.Range(0, characterlistUC.Length -1);
            characterRolled.Add(characterlistUC[ranNum]);
            Debug.Log(characterlistUC[ranNum] + " is rolled");
            Results();
        }
        if (ranNum >= 10 && ranNum <= 19)
        {
            //Commmon
            selCharRarity = "Common";
            ranNum = Random.Range(0, characterlistC.Length -1);
            characterRolled.Add(characterlistC[ranNum]);
            Debug.Log(characterlistC[ranNum] + " is rolled");
            Results();
        }
    }

    public void RiggedRoll()
    {
        //characterRolled.Add(characterlistUC[4]);
        //characterRolled.Add(characterlistC[3]);
        //characterRolled.Add(characterlistC[4]);
        ////for the Tutorial by rigging what the player is first given
        //resultSprite.GetComponent<Image>().sprite = characterSprite[ranNum];
        //raceText.text = characterRolled[0];
        //resultRarity.GetComponent<Image>().sprite = rarity[0];

        //normSummary[0].SetActive(true);
        //normSummary[1].SetActive(true);
        //normSummary[2].SetActive(true);
        //normSummary[0].GetComponent<Image>().sprite = characterSprite[ranNum];
        //normSummary[1].GetComponent<Image>().sprite = characterSprite[ranNum];
        //normSummary[2].GetComponent<Image>().sprite = characterSprite[ranNum];
    }

    public void Results()
    {
        //the results of the pull are generated 
        switch (selCharRarity)
        {
            case "Super Rare":
                Debug.Log("its a " + selCharRarity);
                raceText.text = characterlistSR[ranNum];
                resultSprite.GetComponent<Image>().sprite = characterSpriteSR[ranNum];
                resultRarity.GetComponent<Image>().sprite = rarity[0];
                normSummary[0].SetActive(true);
                normSummary[0].GetComponent<Image>().sprite = characterSpriteSR[ranNum];
                break;
            case "Rare":
                Debug.Log("its a " + selCharRarity);
                raceText.text = characterlistR[ranNum];
                resultSprite.GetComponent<Image>().sprite = characterSpriteR[ranNum];
                resultRarity.GetComponent<Image>().sprite = rarity[1];
                normSummary[0].SetActive(true);
                normSummary[0].GetComponent<Image>().sprite = characterSpriteR[ranNum];
                break;
            case "Uncommon":
                Debug.Log("its a " + selCharRarity);
                raceText.text = characterlistUC[ranNum];
                resultSprite.GetComponent<Image>().sprite = characterSpriteUC[ranNum];
                resultRarity.GetComponent<Image>().sprite = rarity[2];
                normSummary[0].SetActive(true);
                normSummary[0].GetComponent<Image>().sprite = characterSpriteUC[ranNum];
                break;
            case "Common":
                Debug.Log("its a " + selCharRarity);
                raceText.text = characterlistC[ranNum];
                resultSprite.GetComponent<Image>().sprite = characterSpriteC[ranNum];
                resultRarity.GetComponent<Image>().sprite = rarity[3];
                normSummary[0].SetActive(true);
                normSummary[0].GetComponent<Image>().sprite = characterSpriteC[ranNum];
                break;
        }     
    }

    public void Levelup()
    {
       
        //Adds the experience from getting a duplicate character
        foreach (string item in characterRolled)
        {
            string checkname = item;
            switch (checkname)
            {
                case "Fishman":
                    if(fishman == true)
                    {
                        if(fishmanStarLevel < commonLimit)
                        {
                            fishmanStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        fishman = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Werewolf":
                    if (werewolf == true)
                    {
                        if (werewolfStarLevel < uncommonLimit)
                        {
                            werewolfStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        werewolf = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Bukkake Slime":
                    if (bukkakeSlime == true)
                    {
                        if (bukkakeSlimeStarLevel < superrareLimit)
                        {
                            bukkakeSlimeStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        bukkakeSlime = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Dragonoid":
                    if (dragonoid == true)
                    {
                        if (dragonoidStarLevel < uncommonLimit)
                        {
                            dragonoidStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        dragonoid = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Golem":
                    if (golem == true)
                    {
                        if (golemStarLevel < superrareLimit)
                        {
                            golemStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        golem = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Catperson":
                    if (catperson == true)
                    {
                        if (catpersonStarLevel < commonLimit)
                        {
                            catpersonStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        catperson = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Angel":
                    if (angel == true)
                    {
                        if (angelStarLevel < superrareLimit)
                        {
                            angelStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        angel = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Devil":
                    if (devil == true)
                    {
                        if (devilStarLevel < rareLimit)
                        {
                            devilStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        devil = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Orge":
                    if (orge == true)
                    {
                        if (orgeStarLevel < commonLimit)
                        {
                            orgeStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        orge = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Gargoyle":
                    if (gargoyle == true)
                    {
                        if (fishmanStarLevel < uncommonLimit)
                        {
                            gargoyleStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        gargoyle = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Garuda":
                    if (garuda == true)
                    {
                        if (garudaStarLevel < commonLimit)
                        {
                            garudaStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        garuda = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Loxodon":
                    if (loxodon == true)
                    {
                        if (loxodonStarLevel < rareLimit)
                        {
                            loxodonStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        loxodon = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Minotaur":
                    if (minotaur == true)
                    {
                        if (minotaurStarLevel < uncommonLimit)
                        {
                            minotaurStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        minotaur = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Spiderperson":
                    if (spiderperson == true)
                    {
                        if (spiderpersonStarLevel < rareLimit)
                        {
                            spiderpersonStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        spiderperson = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
                case "Hobnoblin":
                    if (hobnoblin == true)
                    {
                        if (hobnoblinStarLevel < commonLimit)
                        {
                            hobnoblinStarLevel += rankBonus;
                            summaryText[0].text = "Rank UP!!!";
                            Debug.Log("Rank UP!!!");
                        }
                        else
                        {
                            summaryText[0].text = "MAXED!!!";
                            Debug.Log("MAXED!!!");
                        }
                    }
                    else
                    {
                        hobnoblin = true;
                        summaryText[0].text = "NEW!!!";
                        Debug.Log("Obtained " + checkname);
                        selectedCharacter = checkname;
                        CheckName();
                    }
                    break;
            }
        }

        PlayerPrefs.SetFloat("Fishman_StarRankBonus", fishmanStarLevel);
        PlayerPrefs.SetFloat("BukkakeSlime_StarRankBonus", bukkakeSlimeStarLevel);
        PlayerPrefs.SetFloat("Angel_StarRankBonus", angelStarLevel);
        PlayerPrefs.SetFloat("Golem_StarRankBonus", golemStarLevel);
        PlayerPrefs.SetFloat("Devil_StarRankBonus", devilStarLevel);
        PlayerPrefs.SetFloat("Loxodon_StarRankBonus", loxodonStarLevel);
        PlayerPrefs.SetFloat("Spiderperson_StarRankBonus", spiderpersonStarLevel);
        PlayerPrefs.SetFloat("Minotaur_StarRankBonus", minotaurStarLevel);
        PlayerPrefs.SetFloat("Gargoyle_StarRankBonus", gargoyleStarLevel);
        PlayerPrefs.SetFloat("Dragonoid_StarRankBonus", dragonoidStarLevel);
        PlayerPrefs.SetFloat("Werewolf_StarRankBonus", werewolfStarLevel);
        PlayerPrefs.SetFloat("Catperson_StarRankBonus", catpersonStarLevel);
        PlayerPrefs.SetFloat("Orge_StarRankBonus", orgeStarLevel);
        PlayerPrefs.SetFloat("Garuda_StarRankBonus", garudaStarLevel);
        PlayerPrefs.SetFloat("HobNoblin_StarRankBonus", hobnoblinStarLevel);
        characterRolled.Clear();
    }

    public void CheckName()
    {
        Debug.Log("you done goofed1");
        Debug.Log(selectedCharacter + "is added");
        obtainedCharacters.GetComponent<PlayerCharacterList>().myCharacters.Add(selectedCharacter);
        //PlayerPrefs.SetString();
        //foreach (string item in obtainedCharacters.GetComponent<PlayerCharacterList>().myCharacters)
        //{
        //    PlayerPrefs.SetString(item, item);
        //}
    }
}
