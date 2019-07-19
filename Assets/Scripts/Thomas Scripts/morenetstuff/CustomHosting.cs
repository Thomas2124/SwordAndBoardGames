using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomHosting : NetworkManager
{
    //used if player wants to host a local match
    public void SetupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    //used if player wants to join a local match
    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    //used if player wants created an online match
    public void SetupMatchMakingHost()
    {
        NetworkManager.singleton.StartMatchMaker();
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;

        //creates match using the text from the inputfield as the room name
        NetworkManager.singleton.matchMaker.CreateMatch(ipAddress, NetworkManager.singleton.matchSize, true, "", "", "", 0, 0, NetworkManager.singleton.OnMatchCreate);

    }

    //used if player wants join an online match
    public void JoinMatchMakingGame()
    {
        NetworkManager.singleton.StartMatchMaker();
        NetworkManager.singleton.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
        if (NetworkManager.singleton.matches != null)
        {
            string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
            foreach (var item in NetworkManager.singleton.matches) //checks and compares all the the match names that are available 
            {
                if (item.name == ipAddress)
                {
                    print(item.name);
                    print(ipAddress);
                    NetworkID match = item.networkId;
                    NetworkManager.singleton.matchMaker.JoinMatch(match, "", "", "", 0, 0, NetworkManager.singleton.OnMatchJoined);
                }
            }
        }
    }

    //goes back to set scene
    public void BackToMenuButton()
    {
        NetworkManager.Shutdown(); //shutdowns server
        SceneManager.LoadScene("Thomas_CharacterScene");
    }

    //gets network port
    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    //gets IPadress for local matchmaking only
    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }

    //checks what level has been loaded
    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            MenuScene();
        }
        else
        {
            LevelScene();
        }
    }

    //sets onclick actions on set buttons
    void MenuScene()
    {
        GameObject.Find("HostButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("HostButton").GetComponent<Button>().onClick.AddListener(this.SetupHost);

        GameObject.Find("JoinButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("JoinButton").GetComponent<Button>().onClick.AddListener(this.JoinGame);

        GameObject.Find("MMHostButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("MMHostButton").GetComponent<Button>().onClick.AddListener(this.SetupMatchMakingHost);

        GameObject.Find("MMJoinButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("MMJoinButton").GetComponent<Button>().onClick.AddListener(this.JoinMatchMakingGame);

        GameObject.Find("BackButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("BackButton").GetComponent<Button>().onClick.AddListener(this.BackToMenuButton);
    }

    //sets onclick action for disconnect button while in a match
    void LevelScene()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}
