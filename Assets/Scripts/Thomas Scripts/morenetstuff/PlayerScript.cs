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
    public float health2 = 100f;

    [SyncVar]
    public float health3 = 100f;


    [SyncVar]
    public string name;

    [SyncVar]
    public Vector3 textPosition = Vector3.zero;

    [SyncVar]
    public float damage = 25f;

    public Vector3 healthPosition = Vector3.zero;
    public GameObject playerName;
    public GameObject playerButton;
    public GameObject enemyButton1;
    public GameObject enemyButton2;
    public GameObject enemyButton3;
    public PlayerScript myOpponent;
    public Image healthBar;
    public Image healthBar2;
    public Image healthBar3;

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
    public bool attackPressed;

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
            enemyButton1.SetActive(false);
            enemyButton2.SetActive(false);
            enemyButton3.SetActive(false);
        }
        else if (!isLocalPlayer)
        {
            playerButton.SetActive(false);
            enemyButton1.SetActive(false);
            enemyButton2.SetActive(false);
            enemyButton3.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            CmdFindPLayers();

            CmdHealthBar(health, health2, health3, healthPosition);

            CmdNameSetter(tempName, tempPosition);

            playerButton.SetActive(isMyTurn);
        }
    }

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
    void CmdHealthBar(float value, float value2, float value3, Vector3 pos)
    {
        pos = healthPosition;
        Vector3 pos2 = Vector3.zero;
        Vector3 pos3 = Vector3.zero; ;
        if (connectID == 1)
        {
            pos = new Vector3(-300f, 250f, 0f);
            pos2 = new Vector3(-300f, 200f, 0f);
            pos3 = new Vector3(-300f, 150f, 0f);
        }
        else
        {
            pos = new Vector3(300f, 250f, 0f);
            pos2 = new Vector3(300f, 200f, 0f);
            pos3 = new Vector3(300f, 150f, 0f);
        }

        RpcHealthBar(value, value2, value3, pos, pos2, pos3);
    }

    [ClientRpc]
    void RpcHealthBar(float value, float value2, float value3, Vector3 pos1, Vector3 pos2, Vector3 pos3)
    {
        healthBar.fillAmount = value / 100f;
        healthBar2.fillAmount = value2 / 100f;
        healthBar3.fillAmount = value3 / 100f;
        healthBar.transform.localPosition = pos1;
        healthBar2.transform.localPosition = pos2;
        healthBar3.transform.localPosition = pos3;
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
            AttackOptions();
        }
    }

    void AttackOptions()
    {
        AttackButtonsOnOff(true);
    }

    [Command]
    void CmdAttack1()
    {
        float hit = damage;
        AttackButtonsOnOff(false);
        RpcAttackOptions(hit, 1f);
        CmdTurnSetter(bool1, bool2);
    }

    [Command]
    void CmdAttack2()
    {
        float hit = damage;
        AttackButtonsOnOff(false);
        RpcAttackOptions(hit, 2f);
        CmdTurnSetter(bool1, bool2);
    }

    [Command]
    void CmdAttack3()
    {
        float hit = damage;
        AttackButtonsOnOff(false);
        RpcAttackOptions(hit, 3f);
        CmdTurnSetter(bool1, bool2);
    }

    [ClientRpc]
    void RpcAttackOptions(float hit, float enemy)
    {
        myOpponent.TakeDamage(hit, enemy);
    }

    void TakeDamage(float damage, float enemy)
    {
        switch (enemy)
        {
            case 1f:
                health -= damage;
                break;
            case 2f:
                health2 -= damage;
                break;
            case 3f:
                health3 -= damage;
                break;
        }

    }

    void AttackButtonsOnOff(bool set)
    {
        enemyButton1.SetActive(set);
        enemyButton2.SetActive(set);
        enemyButton3.SetActive(set);
    }
}
