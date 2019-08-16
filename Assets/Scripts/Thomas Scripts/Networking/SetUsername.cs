using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetUsername : MonoBehaviour
{
    public GameObject button;
    public GameObject inputField;
    HighScores highscoreManager;
    public Text fieldText;

    // Start is called before the first frame update
    void Awake()
    {
        highscoreManager = GetComponent<HighScores>();
        if (PlayerPrefs.GetString("PlayerName") != "")
        {
            SceneManager.LoadScene("Stephen_Scene");
        }
        else
        {
            inputField = GameObject.Find("InputFieldName");
            fieldText = GameObject.Find("InputFieldName").transform.Find("Text").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fieldText.text != "" && fieldText.text.Length >= 5 && fieldText.text.Length <= 18)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void EnterGame() //sets name, add currency, set score, enter game
    {
        string playerSetName = GameObject.Find("InputFieldName").transform.Find("Text").GetComponent<Text>().text;
        PlayerPrefs.SetFloat("Currency", 2000f);
        PlayerPrefs.SetString("PlayerName", playerSetName);
        PlayerPrefs.SetInt("PlayerScore", 1);
        highscoreManager.AddNewHighScore(playerSetName, 1);
        SceneManager.LoadScene("Stephen_Scene");
    }
}
