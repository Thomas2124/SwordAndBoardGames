using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : MonoBehaviour
{
    public List<string> myCharacters;
    public PlayerCharacterList theScript;

    public GameObject fishman_prefab;
    public GameObject werewolf_prefab;
    public GameObject bukkakeSlime_prefab;
    public GameObject dragonoid_prefab;
    public GameObject golem_prefab;
    public GameObject catperson_prefab;
    public GameObject angel_prefab;
    public GameObject devil_prefab;
    public GameObject orge_prefab;
    public GameObject gargoyle_prefab;
    public GameObject garuda_prefab;
    public GameObject loxodon_prefab;
    public GameObject minotaur_prefab;
    public GameObject spiderperson_prefab;
    public GameObject hobnoblin_prefab;

    public GameObject spawnObject;
    // Start is called before the first frame update
    void Start()
    {
        theScript = GameObject.Find("MyCharacter").GetComponent<PlayerCharacterList>();
        spawnObject = GameObject.Find("TheObject");
        myCharacters = theScript.myCharacters;
        CreateCharacterPrefabs();
    }

    //spawns characters
    void CreateCharacterPrefabs()
    {
        foreach (string item in myCharacters)
        {
            switch (item)
            {
                case "Fishman":
                    Instantiate(fishman_prefab, spawnObject.transform.parent);
                    break;
                case "Werewolf":
                    Instantiate(werewolf_prefab, spawnObject.transform.parent);
                    break;
                case "Bukkake Slime":
                    Instantiate(bukkakeSlime_prefab, spawnObject.transform.parent);
                    break;
                case "Dragonoid":
                    Instantiate(dragonoid_prefab, spawnObject.transform.parent);
                    break;
                case "Golem":
                    Instantiate(golem_prefab, spawnObject.transform.parent);
                    break;
                case "Catperson":
                    Instantiate(catperson_prefab, spawnObject.transform.parent);
                    break;
                case "Angel":
                    Instantiate(angel_prefab, spawnObject.transform.parent);
                    break;
                case "Devil":
                    Instantiate(devil_prefab, spawnObject.transform.parent);
                    break;
                case "Orge":
                    Instantiate(orge_prefab, spawnObject.transform.parent);
                    break;
                case "Gargoyle":
                    Instantiate(gargoyle_prefab, spawnObject.transform.parent);
                    break;
                case "Garuda":
                    Instantiate(garuda_prefab, spawnObject.transform.parent);
                    break;
                case "Loxodon":
                    Instantiate(loxodon_prefab, spawnObject.transform.parent);
                    break;
                case "Minotaur":
                    Instantiate(minotaur_prefab, spawnObject.transform.parent);
                    break;
                case "Spiderperson":
                    Instantiate(spiderperson_prefab, spawnObject.transform.parent);
                    break;
                case "Hobnoblin":
                    Instantiate(hobnoblin_prefab, spawnObject.transform.parent);
                    break;
            }
        }
    }
}
