using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnPrefabs : MonoBehaviour
{
    public List<string> theCharacters;
    public GameObject slotObject;

    [Space]
    public GameObject fishman_Sprite;
    public GameObject werewolf_Sprite;
    public GameObject bukkakeSlime_Sprite;
    public GameObject dragonoid_Sprite;
    public GameObject golem_Sprite;
    public GameObject catperson_Sprite;
    public GameObject angel_Sprite;
    public GameObject devil_Sprite;
    public GameObject orge_Sprite;
    public GameObject gargoyle_Sprite;
    public GameObject garuda_Sprite;
    public GameObject loxodon_Sprite;
    public GameObject minotaur_Sprite;
    public GameObject spiderperson_Sprite;
    public GameObject hobnoblin_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slotObject.transform.childCount; i++)
        {
            for (int j = 0; j < theCharacters.Count; j++)
            {
                name = theCharacters[j];
                if (i == j)
                {
                    Transform slot = slotObject.transform.GetChild(i).gameObject.transform;
                    switch (name)
                    {
                        case "Fishman":
                            Instantiate(fishman_Sprite, slot);
                            break;
                        case "Werewolf":
                            Instantiate(werewolf_Sprite, slot);
                            break;
                        case "Bukkake Slime":
                            Instantiate(bukkakeSlime_Sprite, slot);
                            break;
                        case "Dragonoid":
                            Instantiate(dragonoid_Sprite, slot);
                            break;
                        case "Golem":
                            Instantiate(golem_Sprite, slot);
                            break;
                        case "Catperson":
                            Instantiate(catperson_Sprite, slot);
                            break;
                        case "Angel":
                            Instantiate(angel_Sprite, slot);
                            break;
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
    }
}
