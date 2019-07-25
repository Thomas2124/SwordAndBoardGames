using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clearexp : MonoBehaviour
{
    public GameObject clearButton;
    public GameObject yesButton;
    public GameObject noButton;

    public PlayerScript script;

    
    // Start is called before the first frame update
    void Start()
    {
        clearButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AreYouSure()
    {
        clearButton.SetActive(false);
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }

    public void No()
    {
        clearButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

    public void Yes()
    {
        clearButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);

        script.fishman_exp = 0f;
        script.werewolf_exp = 0f;
        script.bukkakeSlime_exp = 0f;
        script.dragonoid_exp = 0f;
        script.golem_exp = 0f;
        script.catperson_exp = 0f;
        script.angel_exp = 0f;
        script.devil_exp = 0f;
        script.orge_exp = 0f;
        script.gargoyle_exp = 0f;
        script.garuda_exp = 0f;
        script.loxodon_exp = 0f;
        script.minotaur_exp = 0f;
        script.spiderperson_exp = 0f;
        script.hobnoblin_exp = 0f;

        ExpSaveSystem.SavePlayer(script);
    }
}
