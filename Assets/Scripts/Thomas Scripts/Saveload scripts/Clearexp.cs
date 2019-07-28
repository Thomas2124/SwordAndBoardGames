using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clearexp : MonoBehaviour
{
    public GameObject clearButton;
    public GameObject yesButton;
    public GameObject noButton;
    public int resetNum;

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ResetExp", 0);
        clearButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        resetNum = PlayerPrefs.GetInt("ResetExp");
    }

    public void AreYouSure()
    {
        clearButton.SetActive(false);
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }

    public void No()
    {
        PlayerPrefs.SetInt("ResetExp", 0);
        clearButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

    public void Yes()
    {
        PlayerPrefs.SetInt("ResetExp", 1);
        clearButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
}
