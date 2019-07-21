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
    void Start()
    {
        PlayerPrefs.DeleteKey("PlayerName");
        PlayerPrefs.DeleteKey("PlayerScore");
        if (PlayerPrefs.GetString("PlayerName") != "")
        {
            SceneManager.LoadScene("Stephen_Scene");
        }
        else
        {
            PlayerPrefs.DeleteKey("PlayerName");
            PlayerPrefs.DeleteKey("PlayerScore");
            highscoreManager = GetComponent<HighScores>();
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

    public void EnterGame()
    {
        string playerSetName = GameObject.Find("InputFieldName").transform.Find("Text").GetComponent<Text>().text;
        PlayerPrefs.SetString("PlayerName", playerSetName);
        PlayerPrefs.SetInt("PlayerScore", 1);
        highscoreManager.AddNewHighScore(playerSetName, 1);
        SceneManager.LoadScene("Stephen_Scene");
    }
}
