using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuests : MonoBehaviour
{
    public float winCounter = 0;
    public float matchesPlayed = 0;
    public float rollCounter = 0;

    public float winGoal = 1;
    public float matchesGoal = 5;
    public float rollGoal = 3;

    public float winReward = 100;
    public float matchesReward = 100;
    public float rollReward = 100;

    public bool claimWin = false;
    public bool claimMatches = false;
    public bool claimRoll = false;

    public GameObject RewardButtonWin;
    public GameObject RewardButtonMatches;
    public GameObject RewardButtonRoll;

    public Image winsBar;
    public Image matchesBar;
    public Image rollsBar;

    public Text winsText;
    public Text matchesText;
    public Text rollsText;

    //public PlayerCharacterList theScript;
    public float currency;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("MyCharacter").GetComponent<PlayerCharacterList>();

        if (PlayerPrefs.GetFloat("Currency") == 0f)
        {
            PlayerPrefs.SetFloat("Currency", 0f);
        }

        /*if (PlayerPrefs.GetFloat("Wins") == 0f)
        {
            winCounter = PlayerPrefs.GetFloat("Wins");
        }

        if (PlayerPrefs.GetFloat("Matches") == 0f)
        {
            matchesPlayed = PlayerPrefs.GetFloat("Matches");
        }

        if (PlayerPrefs.GetFloat("Rolls") == 0f)
        {
            rollCounter = PlayerPrefs.GetFloat("Rolls");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("winGoal") != 0f)
        {
            winGoal = PlayerPrefs.GetFloat("winGoal");
        }

        if (PlayerPrefs.GetFloat("matchesGoal") != 0f)
        {
            matchesGoal = PlayerPrefs.GetFloat("matchesGoal");
        }

        if (PlayerPrefs.GetFloat("rollGoal") != 0f)
        {
            rollGoal = PlayerPrefs.GetFloat("rollGoal");
        }

        winCounter = PlayerPrefs.GetFloat("Wins");
        matchesPlayed = PlayerPrefs.GetFloat("Matches");
        rollCounter = PlayerPrefs.GetFloat("Rolls");
        currency = PlayerPrefs.GetFloat("Currency");
        winsBar.fillAmount = winCounter / winGoal;
        matchesBar.fillAmount = matchesPlayed / matchesGoal;
        rollsBar.fillAmount = rollCounter / rollGoal;

        winsText.text = winCounter.ToString() + " / " + winGoal.ToString();
        matchesText.text = matchesPlayed.ToString() + " / " + matchesGoal.ToString();
        rollsText.text = rollCounter.ToString() + " / " + rollGoal.ToString();

        if (winCounter >= winGoal)
        {
            winCounter = winGoal;
            claimWin = true;
            RewardButtonWin.SetActive(true);
        }
        else
        {
            claimWin = false;
            RewardButtonWin.SetActive(false);
        }

        if (matchesPlayed >= matchesGoal)
        {
            matchesPlayed = matchesGoal;
            claimMatches = true;
            RewardButtonMatches.SetActive(true);
        }
        else
        {
            claimMatches = false;
            RewardButtonMatches.SetActive(false);
        }

        if (rollCounter >= rollGoal)
        {
            rollCounter = rollGoal;
            claimRoll = true;
            RewardButtonRoll.SetActive(true);
        }
        else
        {
            claimRoll = false;
            RewardButtonRoll.SetActive(false);
        }
    }

    public void ClaimRewardWins()
    {
        float value = PlayerPrefs.GetFloat("Currency") + winReward;
        PlayerPrefs.SetFloat("Currency", value);
        PlayerPrefs.SetFloat("winGoal", winGoal + 1f);
        winCounter = 0f;
        PlayerPrefs.SetInt("Wins", 0);
        RewardButtonWin.SetActive(false);
    }

    public void ClaimRewardMatches()
    {
        float value = PlayerPrefs.GetFloat("Currency") + matchesReward;
        PlayerPrefs.SetFloat("Currency", value);
        PlayerPrefs.SetFloat("matchesGoal", matchesGoal + 1f);
        matchesPlayed = 0f;
        PlayerPrefs.SetInt("Matches", 0);
        RewardButtonMatches.SetActive(false);
    }

    public void ClaimRewardRolls()
    {
        float value = PlayerPrefs.GetFloat("Currency") + rollReward;
        PlayerPrefs.SetFloat("Currency", value);
        PlayerPrefs.SetFloat("rollGoal", rollGoal + 1f);
        rollCounter = 0f;
        PlayerPrefs.SetInt("Rolls", 0);
        RewardButtonRoll.SetActive(false);
    }
}
