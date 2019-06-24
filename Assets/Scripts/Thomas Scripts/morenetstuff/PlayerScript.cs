using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : NetworkBehaviour
{
    public bool isWinner;
    //Character 1
    [SyncVar]
    public float health = 100f;
    public bool isDefending;
    public bool isDead;

    //Character 2
    [SyncVar]
    public float health2 = 100f;
    public bool isDefending2;
    public bool isDead2;

    //Character 3
    [SyncVar]
    public float health3 = 100f;
    public bool isDefending3;
    public bool isDead3;

    [SyncVar]
    public string name;

    [SyncVar]
    public Vector3 textPosition = Vector3.zero;

    [SyncVar]
    public float damage = 25f;

    public Vector3 healthPosition = Vector3.zero;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject playerName;
    public GameObject playerButton;
    public GameObject defendButton;
    public GameObject enemyButton1;
    public GameObject enemyButton2;
    public GameObject enemyButton3;
    public GameObject characterArrow;
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
    public Vector3 arrowPosition = Vector3.zero;
    public GameObject[] enemy;
    public bool bool1;
    public bool bool2;
    public bool attackPressed;

    [SyncVar]
    public int characterNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            isWinner = false;
            isDead = false;
            isDead2 = false;
            isDead3 = false;
            connectID = NetworkServer.connections.Count;
            if (connectID == 1)
            {
                isMyTurn = true;
            }
            else
            {
                isMyTurn = false;
            }

            characterNumber = 1;
            playerButton.SetActive(isMyTurn);
            defendButton.SetActive(isMyTurn);
            enemyButton1.SetActive(false);
            enemyButton2.SetActive(false);
            enemyButton3.SetActive(false);
            characterArrow.SetActive(false);
        }
        else if (!isLocalPlayer)
        {
            playerButton.SetActive(false);
            defendButton.SetActive(false);
            enemyButton1.SetActive(false);
            enemyButton2.SetActive(false);
            enemyButton3.SetActive(false);
            characterArrow.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            CmdFindPLayers();

            CmdHealthBar(health, health2, health3, healthPosition);

            CmdNameSetter(tempName, tempPosition);

            CmdCharacterPosition();

            playerButton.SetActive(isMyTurn);
            defendButton.SetActive(isMyTurn);

            CmdCharacterLoop();

            CmdDeathChecker();

            ButtonChecker();
        }
    }

    [Command]
    void CmdCharacterLoop()
    {
        bool myBool = isMyTurn;
        RpcCharacterLoop(myBool);
    }

    [ClientRpc]
    void RpcCharacterLoop(bool myBool)
    {
        if (myBool == true)
        {
            characterArrow.SetActive(true);
            if (characterNumber == 1)
            {
                if (isDead == false)
                {
                    ArrowSetter(1);
                    characterArrow.transform.localPosition = arrowPosition;
                }
                else
                {
                    characterNumber += 1;
                }
            }
            else if (characterNumber == 2)
            {
                if (isDead2 == false)
                {
                    ArrowSetter(2);
                    characterArrow.transform.localPosition = arrowPosition;
                }
                else
                {
                    characterNumber += 1;
                }
            }
            else if (characterNumber == 3)
            {
                if (isDead3 == false)
                {
                    ArrowSetter(3);
                    characterArrow.transform.localPosition = arrowPosition;
                }
                else
                {
                    characterNumber += 1;
                }
            }
            else
            {
                characterArrow.SetActive(false);
                CmdTurnSetter(bool1, bool2);
            }
        }
    }

    void ArrowSetter(int num)
    {
        if (connectID == 1)
        {
            if (characterNumber == 1)
            {
                arrowPosition = new Vector3(-300f, 150f, 0f);
            }

            if (characterNumber == 2)
            {
                arrowPosition = new Vector3(-300f, 0f, 0f);
            }

            if (characterNumber == 3)
            {
                arrowPosition = new Vector3(-300f, -150f, 0f);
            }
        }
        else
        {
            if (characterNumber == 1)
            {
                arrowPosition = new Vector3(300f, 150f, 0f);
            }

            if (characterNumber == 2)
            {
                arrowPosition = new Vector3(300f, 0f, 0f);
            }

            if (characterNumber == 3)
            {
                arrowPosition = new Vector3(300f, -150f, 0f);
            }
        }
    }

    [Command]
    void CmdDeathChecker()
    {
        float heal1 = health;
        float heal2 = health2;
        float heal3 = health3;

        RpcDeathChecker(heal1, heal2, heal3);
    }

    [ClientRpc]
    void RpcDeathChecker(float heal1, float heal2, float heal3)
    {
        if (heal1 <= 0f)
        {
            this.health = 0f;
            this.isDead = true;
            this.character1.SetActive(false);
        }

        if (heal2 <= 0f)
        {
            this.health2 = 0f;
            this.isDead2 = true;
            this.character2.SetActive(false);
        }

        if (heal3 <= 0f)
        {
            this.health3 = 0f;
            this.isDead3 = true;
            this.character3.SetActive(false);
        }

        if (this.isDead == true && this.isDead2 == true && this.isDead3 == true)
        {
            myOpponent.isWinner = true;
        }

        if (this.isWinner == true)
        {
            this.gameObject.SetActive(false);
            myOpponent.gameObject.SetActive(false);
        }
    }

    void ButtonChecker() //Checks which opponents can be attacked
    {
        if (myOpponent.isDead == true)
        {
            enemyButton1.SetActive(false);
        }

        if (myOpponent.isDead2 == true)
        {
            enemyButton2.SetActive(false);
        }

        if (myOpponent.isDead3 == true)
        {
            enemyButton3.SetActive(false);
        }
    }

    //position of character images
    [Command]
    void CmdCharacterPosition()
    {
        Vector3 chara1 = Vector3.zero;
        Vector3 chara2 = Vector3.zero;
        Vector3 chara3 = Vector3.zero;

        if (connectID == 1)
        {
            chara1 = new Vector3(-300f, 150f, 0f);
            chara2 = new Vector3(-300f, 0f, 0f);
            chara3 = new Vector3(-300f, -150f, 0f);
        }
        else
        {
            chara1 = new Vector3(300f, 150f, 0f);
            chara2 = new Vector3(300f, 0f, 0f);
            chara3 = new Vector3(300f, -150f, 0f);
        }

        RpcCharacterPosition(chara1, chara2, chara3);
    }

    [ClientRpc]
    void RpcCharacterPosition(Vector3 chara1, Vector3 chara2, Vector3 chara3)
    {
        character1.transform.localPosition = chara1;
        character2.transform.localPosition = chara2;
        character3.transform.localPosition = chara3;
    }

    //sets turn values
    [Command]
    void CmdTurnSetter(bool myBool, bool enemyBool)
    {
        myBool = false;
        enemyBool = true;
        int myNum = 1;
        RpcTurnSetter(myBool, enemyBool, myNum);
    }

    [ClientRpc]
    void RpcTurnSetter(bool myBool, bool enemyBool, int num)
    {
        this.isMyTurn = myBool;
        myOpponent.isMyTurn = enemyBool;
        this.characterNumber = num;
        myOpponent.characterNumber = num;
        if (this.isMyTurn == true)
        {
            this.isDefending = false;
            this.isDefending2 = false;
            this.isDefending3 = false;
        }
    }

    //player healthbar
    [Command]
    void CmdHealthBar(float value, float value2, float value3, Vector3 pos)
    {
        pos = healthPosition;
        Vector3 pos2 = Vector3.zero;
        Vector3 pos3 = Vector3.zero;
        if (connectID == 1)
        {
            pos = new Vector3(-300f, 225f, 0f);
            pos2 = new Vector3(-300f, 75f, 0f);
            pos3 = new Vector3(-300f, -75f, 0f);
        }
        else
        {
            pos = new Vector3(300f, 225f, 0f);
            pos2 = new Vector3(300f, 75f, 0f);
            pos3 = new Vector3(300f, -75f, 0f);
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
        characterNumber += 1;
        DefendChecker(3);
    }

    [Command]
    void CmdAttack2()
    {
        characterNumber += 1;
        DefendChecker(3);
    }

    [Command]
    void CmdAttack3()
    {
        characterNumber += 1;
        DefendChecker(3);
    }

    [ClientRpc]
    void RpcAttackOptions(float hit, float enemy, bool set, bool attack1, bool attack2, bool attack3, float defending)
    {
        AttackButtonsOnOff(set);
        float newDamage;
        if (defending > 0f)
        {
            newDamage = hit / defending;
        }
        else
        {
            newDamage = hit;
        }

        if (attack1 == false && attack2 == false && attack3 == false)
        {
            myOpponent.TakeDamage(newDamage, enemy);
        }
        else
        {
            if (attack1 == true)
            {
                myOpponent.TakeDamage(newDamage, 1);
            }
            else
            {

            }

            if (attack2 == true)
            {
                myOpponent.TakeDamage(newDamage, 2);
            }
            else
            {

            }

            if (attack3 == true)
            {
                myOpponent.TakeDamage(newDamage, 3);

            }
            else
            {

            }
        }
    }

    void DefendChecker(int target)
    {
        bool defend1 = myOpponent.isDefending;
        bool defend2 = myOpponent.isDefending2;
        bool defend3 = myOpponent.isDefending3;

        if (target == 1)
        {
            float hit = damage;
            bool set = false;

            int theDefending = 0;
            bool attack1 = false;
            bool attack2 = false;
            bool attack3 = false;

            if (myOpponent.isDead == false)
            {
                if (myOpponent.isDefending == true)
                {
                    theDefending += 1;
                    attack1 = true;
                }
            }

            if (myOpponent.isDead2 == false)
            {
                if (myOpponent.isDefending2 == true)
                {
                    theDefending += 1;
                    attack2 = true;
                }
            }

            if (myOpponent.isDead3 == false)
            {
                if (myOpponent.isDefending3 == true)
                {
                    theDefending += 1;
                    attack3 = true;
                }
            }

            RpcAttackOptions(hit, 1f, set, attack1, attack2, attack3, theDefending);
        }

        if (target == 2)
        {
            float hit = damage;
            bool set = false;

            int theDefending = 0;
            bool attack1 = false;
            bool attack2 = false;
            bool attack3 = false;

            if (myOpponent.isDead == false)
            {
                if (myOpponent.isDefending == true)
                {
                    theDefending += 1;
                    attack1 = true;
                }
            }

            if (myOpponent.isDead2 == false)
            {
                if (myOpponent.isDefending2 == true)
                {
                    theDefending += 1;
                    attack2 = true;
                }
            }

            if (myOpponent.isDead3 == false)
            {
                if (myOpponent.isDefending3 == true)
                {
                    theDefending += 1;
                    attack3 = true;
                }
            }

            RpcAttackOptions(hit, 2f, set, attack1, attack2, attack3, theDefending);
        }

        if (target == 3)
        {
            float hit = damage;
            bool set = false;

            int theDefending = 0;
            bool attack1 = false;
            bool attack2 = false;
            bool attack3 = false;

            if (myOpponent.isDead == false)
            {
                if (myOpponent.isDefending == true)
                {
                    theDefending += 1;
                    attack1 = true;
                }
            }

            if (myOpponent.isDead2 == false)
            {
                if (myOpponent.isDefending2 == true)
                {
                    theDefending += 1;
                    attack2 = true;
                }
            }

            if (myOpponent.isDead3 == false)
            {
                if (myOpponent.isDefending3 == true)
                {
                    theDefending += 1;
                    attack3 = true;
                }
            }

            RpcAttackOptions(hit, 3f, set, attack1, attack2, attack3, theDefending);
        }
    }

    //Defending Option
    [Command]
    public void CmdDefending()
    {
        bool defend = true;
        int number = characterNumber;
        RpcDefending(defend, number);
    }

    [ClientRpc]
    void RpcDefending(bool myBool, int number)
    {
        switch (number)
        {
            case 1:
                this.isDefending = true;
                this.characterNumber += 1;
                break;
            case 2:
                this.isDefending2 = true;
                this.characterNumber += 1;
                break;
            case 3:
                this.isDefending3 = true;
                this.characterNumber += 1;
                break;
        }
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
        enemyButton1.transform.localPosition = new Vector3(0f, 150f, 0f);
        enemyButton2.transform.localPosition = new Vector3(0f, 0f, 0f);
        enemyButton3.transform.localPosition = new Vector3(0f, -150f, 0f);
    }
}
