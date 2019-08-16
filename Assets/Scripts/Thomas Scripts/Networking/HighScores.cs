using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    const string privateCode = "6uCeOrISQUu2PrTl7LSYkQ_SCC2XRwnUiy3NOLyUCqSA";
    const string publicCode = "5d32920276827f1758755ed4";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    //public static HighScores instance;
    DisplayHighscores highscoreDisplay;


    void Awake()
    {
        highscoreDisplay = GetComponent<DisplayHighscores>();
    }

    public void AddNewHighScore(string username, int score)
    {
        StartCoroutine(UploadNewHighScore(username, score));
    }

    IEnumerator UploadNewHighScore(string username, int score) //upload stats
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + /*WWW.EscapeURL(username)*/username + "/" + score);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            //print("Upload Successful");
            DownloadHighScores();
        }
        else
        {
            //print("Error loading: " + www.error);
        }
    }

    public void DownloadScore()
    {
        StartCoroutine("DownloadHighScores");
    }

    IEnumerator DownloadHighScores()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);

            highscoreDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++) //set scores and names
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
