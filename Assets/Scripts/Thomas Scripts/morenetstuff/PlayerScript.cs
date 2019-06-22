using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : NetworkBehaviour
{
    [SyncVar]
    public float health = 100f;

    [SyncVar]
    public string name;

    [SyncVar]
    public Vector3 textPosition = Vector3.zero;

    [SyncVar]
    public float damage = 25f;

    public Vector3 healthPosition = Vector3.zero;
    public GameObject playerName;
    public GameObject playerButton;
    public PlayerScript myOpponent;
    public Image healthBar;

    [SyncVar]
    public bool isMyTurn;

    [SyncVar]
    public int connectID;

    //Temp Variables
    public float tempDamage;
    public string tempName;
    public Vector3 tempPosition = Vector3.zero;
    public GameObject[] enemy;
    public bool bool1;
    public bool bool2;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            connectID = NetworkServer.connections.Count;
            if (connectID == 1)
            {
                isMyTurn = true;
            }
            else
            {
                isMyTurn = false;
            }
            playerButton.SetActive(isMyTurn);
        }
        else if (!isLocalPlayer)
        {
            playerButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            CmdFindPLayers();

            CmdHealthBar(health, healthPosition);

            CmdNameSetter(tempName, tempPosition);

            playerButton.SetActive(isMyTurn);
        }
    }

    /*//button setter
    [Command]
    void CmdButtonSetter()
    {
        bool myBool = isMyTurn;
        RpcButtonSetter(myBool);
    }

    [ClientRpc]
    void RpcButtonSetter(bool myBool)
    {
        playerButton.SetActive(myBool);
    }*/

    //sets turn values
    [Command]
    void CmdTurnSetter(bool myBool, bool enemyBool)
    {
        myBool = false;
        enemyBool = true;
        RpcTurnSetter(myBool, enemyBool);
    }

    [ClientRpc]
    void RpcTurnSetter(bool myBool, bool enemyBool)
    {
        this.isMyTurn = myBool;
        myOpponent.isMyTurn = enemyBool;
    }

    //player healthbar
    [Command]
    void CmdHealthBar(float value, Vector3 pos)
    {
        pos = healthPosition;
        if (connectID == 1)
        {
            pos = new Vector3(-300f, 250f, 0f);
        }
        else
        {
            pos = new Vector3(300f, 250f, 0f);
        }

        RpcHealthBar(value, pos);
    }

    [ClientRpc]
    void RpcHealthBar(float value, Vector3 pos)
    {
        healthBar.fillAmount = value / 100f;
        healthBar.transform.localPosition = pos;
    }

    //Finds other player
    [Command]
    void CmdFindPLayers()
    {
        RpcFindPlayers();
    }

    [ClientRpc]
    void RpcFindPlayers()
    {
        enemy = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject item in enemy)
        {
            if (item.GetComponent<PlayerScript>() != this)
            {
                myOpponent = item.GetComponent<PlayerScript>();
            }
        }
    }

    //Player Names and position setter
    [Command]
    void CmdNameSetter(string myString, Vector3 myVector)
    {
        myString = name;
        myVector = textPosition;

        if (connectID == 1)
        {
            myString = "Host";
            myVector = new Vector3(-300f, 300f, 0f);
        }
        else
        {
            myString = "Client";
            myVector = new Vector3(300f, 300f, 0f);
        }

        RpcNameSetter(myString, myVector);
    }

    [ClientRpc]
    void RpcNameSetter(string myString, Vector3 myVector)
    {
        playerName.GetComponent<Text>().text = myString;
        playerName.GetComponent<Text>().transform.localPosition = myVector;
    }

    //Player Attacking
    public void Attack() //Button
    {
        if (isLocalPlayer)
        {
            CmdStartAttack(tempDamage);
            CmdTurnSetter(bool1, bool2);
        }
    }

    [Command]
    void CmdStartAttack(float hit)
    {
        hit = damage;
        RpcStartAttack(hit);
    }

    [ClientRpc]
    void RpcStartAttack(float hit)
    {
        myOpponent.TakeDamage(hit);
    }

    void TakeDamage(float damage)
    {
        health -= damage;
    }
}
