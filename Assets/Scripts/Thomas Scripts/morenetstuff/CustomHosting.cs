using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomHosting : NetworkBehaviour
{
    public string ipAddress;
    public Button StartHostButton;
    public Button JoinGameButton;
    public Button DisconnectButton;

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

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    void SetIPAddress()
    {
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

        }
    }

    void MenuScene()
    {
        StartHostButton.onClick.RemoveAllListeners();
        StartHostButton.onClick.AddListener(SetupHost);

        JoinGameButton.onClick.RemoveAllListeners();
        JoinGameButton.onClick.AddListener(JoinGame);
    }

    void LevelScene()
    {
        DisconnectButton.onClick.RemoveAllListeners();
        DisconnectButton.onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}
