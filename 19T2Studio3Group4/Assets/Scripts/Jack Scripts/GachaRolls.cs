using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaRolls : MonoBehaviour
{
    //Script Variables
    private int ranNum;
    private string rarityRolled;
    public string[] characterlistSR;
    public string[] characterlistR;
    public string[] characterlistUC;
    public string[] characterlistC;
    public string characterRolled;
    public Text raceText;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //Super Rare
            ranNum = Random.Range(0, 2);
            characterRolled = characterlistSR[ranNum];
            Results();
        }
        if (ranNum >= 1 && ranNum <= 3)
        {
            //Rare
            ranNum = Random.Range(0, 2);
            characterRolled = characterlistR[ranNum];
            Results();
        }
        if (ranNum >= 4 && ranNum <= 9)
        {
            //Uncommon
            ranNum = Random.Range(0, 3);
            characterRolled = characterlistUC[ranNum];
            Results();
        }
        if (ranNum >= 10 && ranNum <= 19)
        {
            //Commmon
            ranNum = Random.Range(0, 4);
            characterRolled = characterlistC[ranNum];
            Results();
        }
    }

    public void Results()
    {
        raceText.text = characterRolled;
        //do a quick summary of what they recieve then press ok
        //perform check if character exists if yes then open another panel showing that the character has leveled up
        //if not then return to gacha screen page
    }

}
