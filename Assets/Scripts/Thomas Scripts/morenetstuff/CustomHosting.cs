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
    NetworkID netId;
    public void SetupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    public void SetupMatchMakingHost()
    {
        NetworkManager.singleton.StartMatchMaker();
        NetworkManager.singleton.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;

        NetworkManager.singleton.matchMaker.CreateMatch(ipAddress, NetworkManager.singleton.matchSize, true, "", "", "", 0, 0, NetworkManager.singleton.OnMatchCreate);

    }

    public void JoinMatchMakingGame()
    {
        NetworkManager.singleton.StartMatchMaker();
        NetworkManager.singleton.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
        if (NetworkManager.singleton.matches != null)
        {
            string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
            for (int i = 0; i < NetworkManager.singleton.matches.Count; i++)
            {
                var match = NetworkManager.singleton.matches[i];
                if (match.name == ipAddress)
                {
                    NetworkManager.singleton.matchName = ipAddress;
                    NetworkManager.singleton.matchMaker.JoinMatch(netId, "", "", "", 0, 0, NetworkManager.singleton.OnMatchJoined);
                }
            }
        }
    }

    public void BackToMenuButton()
    {
        NetworkManager.Shutdown();
        SceneManager.LoadScene("Thomas_CharacterScene");
    }

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }

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

    void LevelScene()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}
