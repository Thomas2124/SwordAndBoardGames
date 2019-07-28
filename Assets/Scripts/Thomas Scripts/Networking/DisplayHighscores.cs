using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{
    public Text[] highscoreTexts;
    HighScores highscoreManager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i + 1 + ". Fetching...";
        }

        highscoreManager = GetComponent<HighScores>();

        StartCoroutine("RefreashHighscore");
    }

    public void OnHighscoresDownloaded(Highscore[] highScoresList)
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i + 1 + ". ";
            if (highScoresList.Length > i)
            {
                highscoreTexts[i].text += highScoresList[i].username + " - " + highScoresList[i].score;
            }
        }
    }

    IEnumerator RefreashHighscore()
    {
        while (true)
        {
            highscoreManager.DownloadScore();
            yield return new WaitForSeconds(30f);
        }
    }
}
