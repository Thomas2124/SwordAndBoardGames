using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomHosting : NetworkManager
{
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

        GameObject.Find("BackButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("BackButton").GetComponent<Button>().onClick.AddListener(this.BackToMenuButton);
    }

    void LevelScene()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}
