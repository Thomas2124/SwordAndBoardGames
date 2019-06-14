using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceChecker : MonoBehaviour
{
    public GameObject place1;
    public GameObject place2;
    public GameObject place3;

    public GameObject firstCharacter;
    public GameObject secondCharacter;
    public GameObject thirdCharacter;
    // Start is called before the first frame update
    void Start()
    {
        place1 = GameObject.Find("CharacterSlot1.image");
        place2 = GameObject.Find("CharacterSlot2.image");
        place3 = GameObject.Find("CharacterSlot3.image");
    }

    // Update is called once per frame
    void Update()
    {
        if (place1.transform.childCount > 0)
        {
            firstCharacter = place1.transform.GetChild(0).gameObject;
        }

        if (place2.transform.childCount > 0)
        {
            secondCharacter = place2.transform.GetChild(0).gameObject;
        }

        if (place2.transform.childCount > 0)
        {
            thirdCharacter = place3.transform.GetChild(0).gameObject;
        }
    }
}
