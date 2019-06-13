using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaRolls : MonoBehaviour
{
    //Script Variables
    private float ranNum;
    private string rarityRolled;
    

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
            //Access character rarity list and goes into another chance roll
            Results();
        }
        if (ranNum >= 1 && ranNum <= 3)
        {
            //Rare
            //Access character rarity list and goes into another chance roll
            Results();
        }
        if (ranNum >= 4 && ranNum <= 9)
        {
            //Uncommon
            //Access character rarity list and goes into another chance roll
            Results();
        }
        if (ranNum >= 10 && ranNum <= 19)
        {
            //Commmon
            //Access character rarity list and goes into another chance roll
            Results();
        }
    }

    public void Results()
    {
        //tells what image to place and rarity icon to use
        //also contains button to roll again or stop and return to gacha screen.
    }

    
    private void CharacterRoll()
    {
        //checks rarity rolled and goes thgrough list
        //use another random.range to select a character
        //either go back to previous function or go to reults function
    }

    public void SpecialRoll()
    {
        for (int i = 0; i < 5; i++)
        {
            NormalRoll();
            //or do another whole process depending on how it flows
        }
        // go into a custom UI results page or create a page that accommodates to both types of rolls
    }

}
