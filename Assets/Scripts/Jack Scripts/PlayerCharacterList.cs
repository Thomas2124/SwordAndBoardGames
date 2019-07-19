using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterList : MonoBehaviour
{
    public List<string> myCharacters;
    private string[] loadData;

    // Start is called before the first frame update
    void Start()
    {
        loadData = PlayerPrefsX.GetStringArray("CharacterlistOB");
        myCharacters = new List<string>(loadData);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Checker()
    {
        var result = string.Join(", ", myCharacters.ToArray());
        Debug.Log(result);
    }
}
