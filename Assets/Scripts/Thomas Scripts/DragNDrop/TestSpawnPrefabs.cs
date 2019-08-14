using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnPrefabs : MonoBehaviour
{
    public GameObject teamScreen;
    [Header("List of loaded characters")]
    public List<string> theCharacters;

    [Header("Character Inventory")]
    public GameObject slotObject;

    [Header("List of characters script")]
    public PlayerCharacterList theScript;

    [Header("Character Prefabs")]
    public GameObject fishman_Sprite;
    public GameObject werewolf_Sprite;
    //public GameObject bukkakeSlime_Sprite;
    public GameObject dragonoid_Sprite;
    //public GameObject golem_Sprite;
    public GameObject catperson_Sprite;
    //public GameObject angel_Sprite;
    public GameObject devil_Sprite;
    public GameObject orge_Sprite;
    public GameObject gargoyle_Sprite;
    public GameObject garuda_Sprite;
    public GameObject loxodon_Sprite;
    public GameObject minotaur_Sprite;
    public GameObject spiderperson_Sprite;
    public GameObject hobnoblin_Sprite;

    public bool setCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        setCheck = true;
        //loads and sets list items from another script
        /*theScript = GameObject.Find("MyCharacters").GetComponent<PlayerCharacterList>();
        theCharacters = theScript.myCharacters;


        for (int i = 0; i < slotObject.transform.childCount; i++) //goes through each slot in the inventory
        {
            for (int j = 0; j < theCharacters.Count; j++) //goes through each character in the list
            {
                name = theCharacters[j];
                if (i == j) //if the inventory slot and the current list item are in the same order
                {
                    Transform slot = slotObject.transform.GetChild(i).gameObject.transform; //sets child object to spawn a prefab in
                    switch (name)
                    {
                        case "Fishman":
                            Instantiate(fishman_Sprite, slot);
                            break;
                        case "Werewolf":
                            Instantiate(werewolf_Sprite, slot);
                            break;
                        //case "Bukkake Slime":
                        //    Instantiate(bukkakeSlime_Sprite, slot);
                        //    break;
                        case "Dragonoid":
                            Instantiate(dragonoid_Sprite, slot);
                            break;
                        //case "Golem":
                        //    Instantiate(golem_Sprite, slot);
                        //    break;
                        case "Catperson":
                            Instantiate(catperson_Sprite, slot);
                            break;
                        //case "Angel":
                        //    Instantiate(angel_Sprite, slot);
                        //    break;
                        case "Devil":
                            Instantiate(devil_Sprite, slot);
                            break;
                        case "Orge":
                            Instantiate(orge_Sprite, slot);
                            break;
                        case "Gargoyle":
                            Instantiate(gargoyle_Sprite, slot);
                            break;
                        case "Garuda":
                            Instantiate(garuda_Sprite, slot);
                            break;
                        case "Loxodon":
                            Instantiate(loxodon_Sprite, slot);
                            break;
                        case "Minotaur":
                            Instantiate(minotaur_Sprite, slot);
                            break;
                        case "Spiderperson":
                            Instantiate(spiderperson_Sprite, slot);
                            break;
                        case "Hobnoblin":
                            Instantiate(hobnoblin_Sprite, slot);
                            break;
                    }
                }
            }
        }*/
    }

    void Update()
    {

        if (teamScreen.activeInHierarchy == true && setCheck == true)
        {
            theScript = GameObject.Find("MyCharacters").GetComponent<PlayerCharacterList>();
            theCharacters = theScript.myCharacters;

            for (int i = 0; i < slotObject.transform.childCount; i++) //goes through each slot in the inventory
            {
                for (int j = 0; j < theCharacters.Count; j++) //goes through each character in the list
                {
                    name = theCharacters[j];
                    if (i == j) //if the inventory slot and the current list item are in the same order
                    {
                        Transform slot = slotObject.transform.GetChild(i).gameObject.transform; //sets child object to spawn a prefab in
                        switch (name)
                        {
                            case "Fishman":
                                Instantiate(fishman_Sprite, slot);
                                break;
                            case "Werewolf":
                                Instantiate(werewolf_Sprite, slot);
                                break;
                            //case "Bukkake Slime":
                            //    Instantiate(bukkakeSlime_Sprite, slot);
                            //    break;
                            case "Dragonoid":
                                Instantiate(dragonoid_Sprite, slot);
                                break;
                            //case "Golem":
                            //    Instantiate(golem_Sprite, slot);
                            //    break;
                            case "Catperson":
                                Instantiate(catperson_Sprite, slot);
                                break;
                            //case "Angel":
                            //    Instantiate(angel_Sprite, slot);
                            //    break;
                            case "Devil":
                                Instantiate(devil_Sprite, slot);
                                break;
                            case "Orge":
                                Instantiate(orge_Sprite, slot);
                                break;
                            case "Gargoyle":
                                Instantiate(gargoyle_Sprite, slot);
                                break;
                            case "Garuda":
                                Instantiate(garuda_Sprite, slot);
                                break;
                            case "Loxodon":
                                Instantiate(loxodon_Sprite, slot);
                                break;
                            case "Minotaur":
                                Instantiate(minotaur_Sprite, slot);
                                break;
                            case "Spiderperson":
                                Instantiate(spiderperson_Sprite, slot);
                                break;
                            case "Hobnoblin":
                                Instantiate(hobnoblin_Sprite, slot);
                                break;
                        }
                    }
                }
            }

            setCheck = false;
        }
    }

    void OnDisable()
    {
        setCheck = true;
        for (int i = 0; i < slotObject.transform.childCount; i++) //goes through each slot in the inventory
        {
            if (slotObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject != null)
            {
                Destroy(slotObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject);
            }
        }
    }


}
