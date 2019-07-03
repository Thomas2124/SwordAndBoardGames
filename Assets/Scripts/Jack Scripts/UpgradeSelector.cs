using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelector : MonoBehaviour
{
    public enum CharacterName
    {
        fishman,
        werewolf, 
        dragonoid,
        golem, 
        catperson, 
        angel,
        devil, 
        orge, 
        gargoyle, 
        garuda,
        loxodon,
        minotaur,
        spiderperson,
        hobnoblin,
    }
    public CharacterName Name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<ArrayIsFullScritp>())
        //{
        //    GetComponent<Upgrade>().selectedCharacter = Name.ToString();
        //}
    }
}  
