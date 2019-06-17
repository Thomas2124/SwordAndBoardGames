using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNetScript : NetworkBehaviour
{
    //public Text myPlayerText;
    //public Button myNextButton;
    //public bool isPlayer1 = false;
    //public bool isPlayer2 = false;

    [SyncVar]
    public Text myPlayerText;
    public Button myNextButton;
    public string PlayerName = "player";
    public bool isPlayer1 = false;
    public bool isPlayer2 = false;

    [Command]
    void CmdChangeName(string name)
    {
        PlayerName = name;
        myPlayerText.text = PlayerName;
        RpcOnChangePlayerName(name);
    }

    [ClientRpc]
    void RpcOnChangePlayerName(string n)
    {
        PlayerName = n;
        myPlayerText.text = PlayerName;

    }

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer == true)
        {
            DummyManager script = GameObject.Find("GameManager").GetComponent<DummyManager>();
            if (script.player1Joined == false)
            {
                script.player1Joined = true;
                isPlayer1 = true;
                isPlayer2 = false;
                PlayerName = "Bob";
                CmdChangeName(PlayerName);
                myNextButton.transform.position = new Vector2(myNextButton.transform.position.x, myNextButton.transform.position.y + 200f);
            }
            else if (script.player1Joined == true)
            {
                script.player2Joined = true;
                isPlayer1 = false;
                isPlayer2 = true;
                PlayerName = "Mike";
                CmdChangeName(PlayerName);
                myNextButton.transform.position = new Vector2(myNextButton.transform.position.x, myNextButton.transform.position.y - 50f);
            }
            else if(script.player1Joined == true && script.player2Joined == true)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
