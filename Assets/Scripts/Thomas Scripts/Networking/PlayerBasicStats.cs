using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBasicStats : MonoBehaviour
{
    public string playerName;
    public int score;
    public string playerSetName;
    public GameObject button;
    public GameObject inputField;
    HighScores highscoreManager;
    public int noNeedToSet = 0;

    // Start is called before the first frame update
    void Awake()
    {
        highscoreManager = GetComponent<HighScores>();
        if (PlayerPrefs.GetString("PlayerName") != null && PlayerPrefs.GetInt("PlayerScore") > 0)
        {
            button.SetActive(false);
            inputField.SetActive(false);
            playerName = PlayerPrefs.GetString("PlayerName");
            print(playerName);
            score = PlayerPrefs.GetInt("PlayerScore");

            noNeedToSet = 2;
        }
        else
        {
            noNeedToSet = 0;
            button.SetActive(true);
            inputField.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSetName != null && noNeedToSet == 1)
        {
            PlayerPrefs.SetString("PlayerName", playerSetName);

            if (PlayerPrefs.GetInt("PlayerScore") > 0)
            {
                score = PlayerPrefs.GetInt("PlayerScore");
            }
            else
            {
                PlayerPrefs.SetInt("PlayerScore", 1);
                score = PlayerPrefs.GetInt("PlayerScore");
            }

            if (PlayerPrefs.GetString("PlayerName") != "")
            {
                playerName = PlayerPrefs.GetString("PlayerName");
            }

            if (PlayerPrefs.GetString("PlayerName") != "" && PlayerPrefs.GetInt("PlayerScore") > 0)
            {
                highscoreManager.AddNewHighScore(playerName, score);
            }

            button.SetActive(false);
            inputField.SetActive(false);
        }
    }

    public void SetName()
    {
        playerSetName = GameObject.Find("InputFieldName").transform.Find("Text").GetComponent<Text>().text;
        noNeedToSet = 1;
    }
}
