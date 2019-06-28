using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    //Variables
    public int upGradeMaterials = 0;
    public bool hasMaterial = false;
    public string selectedCharacter;

    public int fishmanStarLevel = 4;
    public int werewolfStarLevel = 3;
    public int bukkakeSlimeStarLevel = 1;
    public int dragonoidStarLevel = 3;
    public int golemStarLevel = 1;
    public int catpersonStarLevel = 4;
    public int angelStarLevel = 1;
    public int devilStarLevel = 2;
    public int orgeStarLevel = 4;
    public int gargoyleStarLevel = 3;
    public int garudaStarLevel = 4;
    public int loxodonStarLevel = 2;
    public int minotaurStarLevel = 3;
    public int spiderpersonStarLevel = 2;
    public int hobnoblinStarLevel = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GimmeOne()
    {
        upGradeMaterials++;
    }

    public void GradeUp()
    {
        if(upGradeMaterials > 0)
        {
            hasMaterial = true;
            //enable the button for upgrading
            upGradeMaterials--;
            switch (selectedCharacter)
            {
                case "fishman":
                    if (fishmanStarLevel < 5)
                    {
                        fishmanStarLevel++;
                    }
                    break;
                case "werewolf":
                    if (werewolfStarLevel < 5)
                    {
                        werewolfStarLevel++;
                    }
                    break;
                case "bukkake Slime":
                    if (bukkakeSlimeStarLevel < 5)
                    {
                        bukkakeSlimeStarLevel++;
                    }
                    break;
                case "dragonoid":
                    if (dragonoidStarLevel < 5)
                    {
                        dragonoidStarLevel++;
                    }
                    break;
                case "golem":
                    if (golemStarLevel < 5)
                    {
                        golemStarLevel++;
                    }
                    break;
                case "catperson":
                    if (catpersonStarLevel < 5)
                    {
                        catpersonStarLevel++;
                    }
                    break;
                case "angel":
                    if (angelStarLevel < 5)
                    {
                        angelStarLevel++;
                    }
                    break;
                case "devil":
                    if (devilStarLevel < 5)
                    {
                        devilStarLevel++;
                    }
                    break;
                case "orge":
                    if (orgeStarLevel < 5)
                    {
                        orgeStarLevel++;
                    }
                    break;
                case "gargoyle":
                    if (gargoyleStarLevel < 5)
                    {
                        gargoyleStarLevel++;
                    }
                    break;
                case "garuda":
                    if (garudaStarLevel < 5)
                    {
                        garudaStarLevel++;
                    }
                    break;
                case "loxodon":
                    if (loxodonStarLevel < 5)
                    {
                        loxodonStarLevel++;
                    }
                    break;
                case "minotaur":
                    if (minotaurStarLevel < 5)
                    {
                        minotaurStarLevel++;
                    }
                    break;
                case "spiderperson":
                    if (spiderpersonStarLevel < 5)
                    {
                        spiderpersonStarLevel++;
                    }
                    break;
                case "hobnoblin":
                    if (hobnoblinStarLevel < 5)
                    {
                        hobnoblinStarLevel++;
                    }
                    break;
            }
        }
        else
        {
            hasMaterial = false;
        }
        //check what character is being selected
        //check what level the character is at
        //does the player have the upgrade material
        //
    }
}
