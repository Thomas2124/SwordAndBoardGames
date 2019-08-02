using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterList : MonoBehaviour
{
    public List<string> myCharacters;   //Players obtained character list
    private string[] loadData;          //converter 
    public int premiumCurrency;         //Players currency
    public Text currencydisplay;        //currency displayer
    public string[] clearArray;

    // Start is called before the first frame update
    void Start()
    {
        loadData = PlayerPrefsX.GetStringArray("CharacterlistOB");
        myCharacters = new List<string>(loadData);
    }

    // Update is called once per frame
    void Update()
    {
        currencydisplay.text = premiumCurrency.ToString();
    }

    //checks what is in your obtained list (dev)
    public void Checker()
    {
        var result = string.Join(", ", myCharacters.ToArray());
        Debug.Log(result);
    }

    public void ClearBoi()
    {
        myCharacters.Clear();
        
        PlayerPrefsX.SetStringArray("CharacterlistOB", clearArray);
    }
}
