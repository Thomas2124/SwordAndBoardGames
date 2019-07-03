using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class BackToMenuButton : NetworkBehaviour
{
    public NetworkManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToCharacterScreen()
    {
        manager.StopServer();
        manager.StopClient();
        SceneManager.LoadScene("TL_TestLocalMultiplayer");
    }
}
