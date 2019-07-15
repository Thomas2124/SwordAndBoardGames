using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyQuests : MonoBehaviour
{
    public int winCounter = 0;
    public int matchesPlayed = 0;
    public int rollCounter = 0;

    public int winGoal = 1;
    public int matchesGoal = 5;
    public int rollGoal = 3;

    public int winReward = 100;
    public int matchesReward = 100;
    public int rollReward = 100;

    public bool claimWin = false;
    public bool claimMatches = false;
    public bool claimRoll = false;

    public GameObject RewardButtonWin;
    public GameObject RewardButtonMatches;
    public GameObject RewardButtonRoll;

    public PlayerCharacterList theScript;
    public int currency;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("MyCharacter").GetComponent<PlayerCharacterList>();

        if (PlayerPrefs.GetInt("Wins") != null)
        {
            winCounter = PlayerPrefs.GetInt("Wins");
        }

        if (PlayerPrefs.GetInt("Matches") != null)
        {
            matchesPlayed = PlayerPrefs.GetInt("Matches");
        }

        if (PlayerPrefs.GetInt("Rolls") != null)
        {
            rollCounter = PlayerPrefs.GetInt("Rolls");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (winCounter == winGoal)
        {
            claimWin = true;
            RewardButtonWin.SetActive(true);
        }
        else
        {
            claimWin = false;
            RewardButtonWin.SetActive(false);
        }

        if (matchesPlayed == matchesGoal)
        {
            claimMatches = true;
            RewardButtonMatches.SetActive(true);
        }
        else
        {
            claimMatches = false;
            RewardButtonMatches.SetActive(false);
        }

        if (rollCounter == rollGoal)
        {
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
        currency += winReward;
        PlayerPrefs.SetInt("Wins", 0);
        RewardButtonWin.SetActive(false);
    }

    public void ClaimRewardMatches()
    {
        currency += matchesReward;
        PlayerPrefs.SetInt("Matches", 0);
        RewardButtonMatches.SetActive(false);
    }

    public void ClaimRewardRolls()
    {
        currency += rollReward;
        PlayerPrefs.SetInt("Rolls", 0);
        RewardButtonRoll.SetActive(false);
    }
}
