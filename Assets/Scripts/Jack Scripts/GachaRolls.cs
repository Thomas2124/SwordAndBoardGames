using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaRolls : MonoBehaviour
{
    //Gacha Variables
    private int ranNum;                                     //generated number that represents the character pulled         
    public string[] characterlistSR;                        //string array of the characters in Super Rare
    public string[] characterlistR;                         //string array of the characters in Rare
    public string[] characterlistUC;                        //string array of the characters in Uncommon
    public string[] characterlistC;                         //string array of the characters in Common
    public List<string> characterRolled;                    //character names pulled during the current roll
    [SerializeField] private bool bigRoll = false;          //is it a multiple roll
    [SerializeField] private int counter;                   //counter to ensure that rolls occurs 5 times (multiroll)
    public int lowCost = 250;                               //Cost of a single roll
    public int highCost = 1000;                             //Cost of a multi roll
    public GameObject resultScreen;                         //The result screen panel
    public GameObject okButton1;                            //does another roll (multiroll)
    public GameObject okButton2;                            //closes the result screen

    //Result Variables  
    public Text raceText;                                   //the name of the character pulled displayed
    public Image resultSprite;                              //the sprite image of pulled character displayed
    public Image resultRarity;                              //the rarity image of pulled character displayed
    public Sprite[] characterSpriteSR;                      //corresponding character sprite data in super rare
    public Sprite[] characterSpriteR;                       //corresponding character sprite data in rare
    public Sprite[] characterSpriteUC;                      //corresponding character sprite data in uncommon
    public Sprite[] characterSpriteC;                       //corresponding character sprite data in common
    public Sprite[] rarity;                                 //rarity sprite data
    [SerializeField] private string selCharRarity;          //rolled characters rarity
    public Text[] summaryText;                              //says whether its a new, rank up or max character

    //Obtained? Variables
    public bool fishman = false;                            
    public bool werewolf = false;                           
    //public bool bukkakeSlime = false;
    public bool dragonoid = false;
    //public bool golem = false;
    public bool catperson = false;
    //public bool angel = false;
    public bool devil = false;
    public bool orge = false;
    public bool gargoyle = false;
    public bool garuda = false;
    public bool loxodon = false;
    public bool minotaur = false;
    public bool spiderperson = false;
    public bool hobnoblin = false;
    public string selectedCharacter;                        //character string is added to your obtained character list            
    public GameObject obtainedCharacters;                   //referencing the mycharacterlist script
    public float rankBonus = .01f;                          //how much bonus stat gained when a duplicate is rolled
    [SerializeField] private float commonLimit = 1.25f;     //common characters bonus stat limit
    [SerializeField] private float uncommonLimit = 1.5f;    //uncommon characters bonus stat limit
    [SerializeField] private float rareLimit = 1.75f;       //rare characters bonus stat limit
    [SerializeField] private float superrareLimit = 2f;     //super rare characters bonus stat limit

    //Bonus Stats Variables                                                          
    public float fishmanStarLevel = 1;
    public float werewolfStarLevel = 1;
    //public float bukkakeSlimeStarLevel = 1;
    public float dragonoidStarLevel = 1;
    //public float golemStarLevel = 1;
    public float catpersonStarLevel = 1;
    //public float angelStarLevel = 1;
    public float devilStarLevel = 1;
    public float orgeStarLevel = 1;
    public float gargoyleStarLevel = 1;
    public float garudaStarLevel = 1;
    public float loxodonStarLevel = 1;
    public float minotaurStarLevel = 1;
    public float spiderpersonStarLevel = 1;
    public float hobnoblinStarLevel = 1;

    //Checks if currency is enough to roll for a single roll
    public void NormalRoll()
    {
        if(obtainedCharacters.GetComponent<PlayerCharacterList>().premiumCurrency >= lowCost)
        {
            obtainedCharacters.GetComponent<PlayerCharacterList>().premiumCurrency -= lowCost;
            RandomPick();
        }
    }

    //checks if currency is enough to roll for a multi roll
    public void MultipleRoll()
    {
        if (obtainedCharacters.GetComponent<PlayerCharacterList>().premiumCurrency >= highCost)
        {
            counter = 5;
            bigRoll = true;
            obtainedCharacters.GetComponent<PlayerCharacterList>().premiumCurrency -= highCost;
            RandomPick();
        }
    }

    //Rolls the character
    public void RandomPick()
    {
        resultScreen.SetActive(true);
        counter--;
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
        if (counter == 0)
        {
            okButton1.SetActive(false);
            okButton2.SetActive(true);
        }
    }

    //display the character rolled
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
                break;
            case "Rare":
                Debug.Log("its a " + selCharRarity);
                raceText.text = characterlistR[ranNum];
                resultSprite.GetComponent<Image>().sprite = characterSpriteR[ranNum];
                resultRarity.GetComponent<Image>().sprite = rarity[1];            
                break;
            case "Uncommon":
                Debug.Log("its a " + selCharRarity);
                raceText.text = characterlistUC[ranNum];
                resultSprite.GetComponent<Image>().sprite = characterSpriteUC[ranNum];
                resultRarity.GetComponent<Image>().sprite = rarity[2];              
                break;
            case "Common":
                Debug.Log("its a " + selCharRarity);
                raceText.text = characterlistC[ranNum];
                resultSprite.GetComponent<Image>().sprite = characterSpriteC[ranNum];
                resultRarity.GetComponent<Image>().sprite = rarity[3];
                break;
        }
        Levelup();
    }

    private void RankUp()
    {
        summaryText[0].text = "Rank UP!!!";
        Debug.Log("Rank UP!!!");
    }

    private void Maxed()
    {
        summaryText[0].text = "MAXED!!!";
        Debug.Log("MAXED!!!");
    }
    private void New()
    {
        summaryText[0].text = "NEW!!!";
        Debug.Log("Obtained " + selectedCharacter);
        CheckName();
    }

    //uses what you rolled and check whether its a duplicate or not
    public void Levelup()
    {      
        //Adds the experience from getting a duplicate character
        foreach (string item in characterRolled)
        {
            selectedCharacter = item;
            switch (selectedCharacter)
            {
                case "Fishman":
                    if(fishman == true)
                    {
                        if(fishmanStarLevel < commonLimit)
                        {
                            fishmanStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        fishman = true;
                        New();
                    }
                    break;
                case "Werewolf":
                    if (werewolf == true)
                    {
                        if (werewolfStarLevel < uncommonLimit)
                        {
                            werewolfStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        werewolf = true;
                        New();
                    }
                    break;
                //case "Bukkake Slime":
                //    if (bukkakeSlime == true)
                //    {
                //        if (bukkakeSlimeStarLevel < superrareLimit)
                //        {
                //            bukkakeSlimeStarLevel += rankBonus;
                //            RankUp();
                //        }
                //        else
                //        {
                //            Maxed();
                //        }
                //    }
                //    else
                //    {
                //        bukkakeSlime = true;
                //        New();
                //    }
                //    break;
                case "Dragonoid":
                    if (dragonoid == true)
                    {
                        if (dragonoidStarLevel < uncommonLimit)
                        {
                            dragonoidStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        dragonoid = true;
                        New();
                    }
                    break;
                //case "Golem":
                //    if (golem == true)
                //    {
                //        if (golemStarLevel < superrareLimit)
                //        {
                //            golemStarLevel += rankBonus;
                //            RankUp();
                //        }
                //        else
                //        {
                //            Maxed();
                //        }
                //    }
                //    else
                //    {
                //        golem = true;
                //        New();
                //    }
                //    break;
                case "Catperson":
                    if (catperson == true)
                    {
                        if (catpersonStarLevel < commonLimit)
                        {
                            catpersonStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        catperson = true;
                        New();
                    }
                    break;
                //case "Angel":
                //    if (angel == true)
                //    {
                //        if (angelStarLevel < superrareLimit)
                //        {
                //            angelStarLevel += rankBonus;
                //            RankUp();
                //        }
                //        else
                //        {
                //            Maxed();
                //        }
                //    }
                //    else
                //    {
                //        angel = true;
                //        New();
                //    }
                //    break;
                case "Devil":
                    if (devil == true)
                    {
                        if (devilStarLevel < rareLimit)
                        {
                            devilStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        devil = true;
                        New();
                    }
                    break;
                case "Orge":
                    if (orge == true)
                    {
                        if (orgeStarLevel < commonLimit)
                        {
                            orgeStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        orge = true;
                        New();
                    }
                    break;
                case "Gargoyle":
                    if (gargoyle == true)
                    {
                        if (fishmanStarLevel < uncommonLimit)
                        {
                            gargoyleStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        gargoyle = true;
                        New();
                    }
                    break;
                case "Garuda":
                    if (garuda == true)
                    {
                        if (garudaStarLevel < commonLimit)
                        {
                            garudaStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        garuda = true;
                        New();
                    }
                    break;
                case "Loxodon":
                    if (loxodon == true)
                    {
                        if (loxodonStarLevel < rareLimit)
                        {
                            loxodonStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        loxodon = true;
                        New();
                    }
                    break;
                case "Minotaur":
                    if (minotaur == true)
                    {
                        if (minotaurStarLevel < uncommonLimit)
                        {
                            minotaurStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        minotaur = true;
                        New();
                    }
                    break;
                case "Spiderperson":
                    if (spiderperson == true)
                    {
                        if (spiderpersonStarLevel < rareLimit)
                        {
                            spiderpersonStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        spiderperson = true;
                        New();
                    }
                    break;
                case "Hobnoblin":
                    if (hobnoblin == true)
                    {
                        if (hobnoblinStarLevel < commonLimit)
                        {
                            hobnoblinStarLevel += rankBonus;
                            RankUp();
                        }
                        else
                        {
                            Maxed();
                        }
                    }
                    else
                    {
                        hobnoblin = true;
                        New();
                    }
                    break;
            }
        }

        bigRoll = false;
        PlayerPrefsX.SetStringArray("CharacterlistOB", obtainedCharacters.GetComponent<PlayerCharacterList>().myCharacters.ToArray());
        PlayerPrefs.SetFloat("Fishman_StarRankBonus", fishmanStarLevel);
        //PlayerPrefs.SetFloat("BukkakeSlime_StarRankBonus", bukkakeSlimeStarLevel);
        //PlayerPrefs.SetFloat("Angel_StarRankBonus", angelStarLevel);
        //PlayerPrefs.SetFloat("Golem_StarRankBonus", golemStarLevel);
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

    //adds to the character obtained list
    public void CheckName()
    {
        Debug.Log(selectedCharacter + " is added");
        obtainedCharacters.GetComponent<PlayerCharacterList>().myCharacters.Add(selectedCharacter);
    }
}
