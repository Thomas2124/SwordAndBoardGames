﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuests : MonoBehaviour
{
    public float winCounter = 0;
    public float win50Counter = 0;
    public float matchesPlayed = 0;
    public float rollCounter = 0;

    public float winGoal = 1;
    public float win50Goal = 50;
    public float matchesGoal = 5;
    public float rollGoal = 3;

    public float winReward = 100;
    public float matchesReward = 100;
    public float rollReward = 100;
    public float slimeReward = 150;
    public float golemReward = 150;
    public float angelReward = 150;
    public float wins50Reward = 500;

    public bool claimWin = false;
    public bool claimMatches = false;
    public bool claimRoll = false;
    public bool claimSlime = false;
    public bool claimGolem = false;
    public bool claimAngel = false;
    public bool claim50Wins = false;


    public GameObject RewardButtonWin;
    public GameObject RewardButtonMatches;
    public GameObject RewardButtonRoll;
    public GameObject RewardButtonSlime;
    public GameObject RewardButtonGolem;
    public GameObject RewardButtonAngel;
    public GameObject RewardButtonWin50;

    public Image winsBar;
    public Image matchesBar;
    public Image rollsBar;
    public Image wins50Bar;
    public Image slimeBar;
    public Image angelBar;
    public Image golemBar;

    public Text winsText;
    public Text matchesText;
    public Text rollsText;
    public Text slimeText;
    public Text angelText;
    public Text golemText;
    public Text wins50Text;

    public string[] characterRollList;
    public PlayerCharacterList listScript;

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
        //set values
        characterRollList = PlayerPrefsX.GetStringArray("CharacterlistOB");

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
        win50Counter = PlayerPrefs.GetFloat("win50Goal");
        winsBar.fillAmount = winCounter / winGoal;
        matchesBar.fillAmount = matchesPlayed / matchesGoal;
        rollsBar.fillAmount = rollCounter / rollGoal;

        //set text
        winsText.text = winCounter.ToString() + " / " + winGoal.ToString();
        matchesText.text = matchesPlayed.ToString() + " / " + matchesGoal.ToString();
        rollsText.text = rollCounter.ToString() + " / " + rollGoal.ToString();
        wins50Text.text = win50Counter.ToString() + " / "  + win50Goal.ToString();

        //Check and claim quests
        if (winCounter >= winGoal)//checks wins
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

        if (matchesPlayed >= matchesGoal)//checks matches
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

        if (rollCounter >= rollGoal)//checks rolls
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

        if (win50Counter >= win50Goal && PlayerPrefsX.GetBool("win50Claim") != true)//checks event wins
        {
            win50Counter = win50Goal;
            claim50Wins = true;
            RewardButtonWin50.SetActive(true);
        }
        else
        {
            claimWin = false;
            RewardButtonWin50.SetActive(false);
        }

        foreach (string item in characterRollList)//checks specific characters
        {
            claimSlime = PlayerPrefsX.GetBool("slimeClaim");
            claimGolem = PlayerPrefsX.GetBool("golemClaim");
            claimAngel = PlayerPrefsX.GetBool("angelClaim");

            if (claimSlime == true)
            {
                if (item == "Bukkake Slime")
                {
                    RewardButtonSlime.SetActive(true);
                }
                else
                {
                    //RewardButtonSlime.SetActive(true);
                }
            }
            else
            {
                RewardButtonSlime.SetActive(false);
            }

            if (claimGolem == true)
            {
                if (item == "Golem")
                {
                    RewardButtonGolem.SetActive(true);
                }
                else
                {
                    //RewardButtonGolem.SetActive(true);
                }
            }
            else
            {
                RewardButtonGolem.SetActive(false);
            }

            if (claimAngel == true)
            {
                if (item == "Angel")
                {
                    RewardButtonAngel.SetActive(true);
                }
                else
                {
                    //RewardButtonAngel.SetActive(true);
                }
            }
            else
            {
                RewardButtonAngel.SetActive(false);
            }
        }
    }

    public void ClaimRewardWins()//claim player wins
    {
        float value = PlayerPrefs.GetFloat("Currency") + winReward;
        PlayerPrefs.SetFloat("Currency", value);
        PlayerPrefs.SetFloat("winGoal", winGoal + 1f);
        winCounter = 0f;
        PlayerPrefs.SetInt("Wins", 0);
        RewardButtonWin.SetActive(false);
    }

    public void ClaimRewardMatches()//amount of matches
    {
        float value = PlayerPrefs.GetFloat("Currency") + matchesReward;
        PlayerPrefs.SetFloat("Currency", value);
        PlayerPrefs.SetFloat("matchesGoal", matchesGoal + 1f);
        matchesPlayed = 0f;
        PlayerPrefs.SetInt("Matches", 0);
        RewardButtonMatches.SetActive(false);
    }

    public void ClaimRewardRolls()//roll characters
    {
        float value = PlayerPrefs.GetFloat("Currency") + rollReward;
        PlayerPrefs.SetFloat("Currency", value);
        PlayerPrefs.SetFloat("rollGoal", rollGoal + 1f);
        rollCounter = 0f;
        PlayerPrefs.SetInt("Rolls", 0);
        RewardButtonRoll.SetActive(false);
    }

    public void ClaimReward50Wins()//get 50 wins
    {
        float value = PlayerPrefs.GetFloat("Currency") + wins50Reward;
        PlayerPrefs.SetFloat("Currency", value);
        PlayerPrefsX.SetBool("win50Claim", true);
        PlayerPrefs.SetFloat("win50Goal", 0f);
        RewardButtonWin50.SetActive(false);
    }

    public void ClaimRewardSlime()//roll slime character
    {
        if (claimSlime == false)
        {
            float value = PlayerPrefs.GetFloat("Currency") + slimeReward;
            PlayerPrefs.SetFloat("Currency", value);
            PlayerPrefsX.SetBool("slimeClaim", true);
            claimSlime = false;
            RewardButtonSlime.SetActive(false);
        }
        else
        {

        }
    }

    public void ClaimRewardGolem()//roll golem character
    {
        if (claimGolem == false)
        {
            float value = PlayerPrefs.GetFloat("Currency") + golemReward;
            PlayerPrefs.SetFloat("Currency", value);
            PlayerPrefsX.SetBool("golemClaim", true);
            claimGolem = false;
            RewardButtonGolem.SetActive(false);
        }
        else
        {

        }
    }

    public void ClaimRewardAngel()//roll angel character
    {
        if (claimAngel == false)
        {
            float value = PlayerPrefs.GetFloat("Currency") + angelReward;
            PlayerPrefs.SetFloat("Currency", value);
            PlayerPrefsX.SetBool("angelClaim", true);
            claimAngel = false;
            RewardButtonAngel.SetActive(false);
        }
        else
        {

        }
    }
}
