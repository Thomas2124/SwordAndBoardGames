using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : NetworkBehaviour
{
    [SyncVar(hook = "TakeDamage")]
    public float health = 100f;

    [SyncVar(hook = "PlayerNameSetter")]
    public string name;

    [SyncVar(hook = "PlayerPositionSetter")]
    public Vector3 textPosition = Vector3.zero;

    public GameObject playerName;
    public GameObject playerButton;

    public float damage = 25f;
    public string tempName;
    public Vector3 tempPosition = Vector3.zero;
    public GameObject[] enemy;
    public PlayerScript myOpponent;
    public Image healthBar;

    public int connectID;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            connectID = NetworkServer.connections.Count;
            //playerName.SetActive(true);
            playerButton.SetActive(true);
            healthBar.enabled = true;
            CmdNameSetter(tempName, tempPosition);
            //CmdTextPositionToServer(tempPosition, tempName);
        }
        else if (!isLocalPlayer)
        {
            //playerName.SetActive(false);
            playerButton.SetActive(false);
            healthBar.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            enemy = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject item in enemy)
            {
                if (item.GetComponent<PlayerScript>() != this)
                {
                    myOpponent = item.GetComponent<PlayerScript>();
                }
            }

            healthBar.fillAmount = health / 100f;

            CmdNameSetter(tempName, tempPosition);
        }
    }

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

        playerName.GetComponent<Text>().text = myString;
        playerName.GetComponent<Text>().transform.localPosition = myVector;

        RpcNameSetter(myString, myVector);
    }

    [ClientRpc]
    void RpcNameSetter(string myString, Vector3 myVector)
    {
        playerName.GetComponent<Text>().text = myString;
        playerName.GetComponent<Text>().transform.localPosition = myVector;
    }

    public void Attack()
    {
        CmdStartAttack(damage);
    }

    [Command]
    void CmdStartAttack(float hit)
    {
        myOpponent.TakeDamage(hit);
        RpcStartAttack(hit);
    }

    [ClientRpc]
    void RpcStartAttack(float hit)
    {
        myOpponent.TakeDamage(hit);
    }

    void PlayerNameSetter(string theName)
    {
        playerName.GetComponent<Text>().text = theName;
    }

    void PlayerPositionSetter(Vector3 pos)
    {
        playerName.GetComponent<Text>().transform.localPosition = pos;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
    }
}
