using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : NetworkBehaviour
{
    public bool isWinner;
    //Character 1
    [Header("Character 1")]
    [SyncVar]
    public float health = 100f;
    public float mana = 0f;
    public bool isDefending;
    public bool isDead;
    public float attackRating = 10f;
    public float defenceRating = 30f;
    public string characterName;
    public float myExp;

    float startDefence;

    //Character 2
    [Header("Character 2")]
    [SyncVar]
    public float health2 = 100f;
    public float mana2 = 0f;
    public bool isDefending2;
    public bool isDead2;
    public float attackRating2 = 25f;
    public float defenceRating2 = 50f;
    public string characterName2;
    public float myExp2;

    float startDefence2;

    //Character 3
    [Header("Character 3")]
    [SyncVar]
    public float health3 = 100f;
    public float mana3 = 0f;
    public bool isDefending3;
    public bool isDead3;
    public float attackRating3 = 40f;
    public float defenceRating3 = 60f;
    public string characterName3;
    public float myExp3;

    float startDefence3;

    [Header("Player Name")]
    public GameObject playerName;
    [SyncVar]
    public string name;
    [SyncVar]
    public Vector3 textPosition = Vector3.zero;

    [Header("Character Damage")]
    [SyncVar]
    //public float damage = 25f;
    public float finalDamage;
    public float baseHealth1;
    public float baseHealth2;
    public float baseHealth3;
    public float sourceDamage;
    public bool isSpecial;

    [Header("Character Objects")]
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;

    [Header("Player Turn Buttons")]
    public GameObject playerButton;
    public GameObject defendButton;
    public GameObject specialButton;
    public GameObject enemyButton1;
    public GameObject enemyButton2;
    public GameObject enemyButton3;
    public PlayerScript myOpponent;

    [Header("Player Bars/Images")]
    public GameObject characterArrow;
    public Image healthBar;
    public Image healthBar2;
    public Image healthBar3;
    public Image specialBar;
    public Image specialBar2;
    public Image specialBar3;

    public float percent;

    [Header("Turn Stuff")]
    [SyncVar]
    public int characterNumber;
    [SyncVar]
    public bool isMyTurn;
    [SyncVar]
    public int connectID;

    //Temp Variables
    float tempDamage;
    string tempName;
    Vector3 tempPosition = Vector3.zero;
    Vector3 arrowPosition = Vector3.zero;
    GameObject[] enemy;
    bool bool1;
    bool bool2;
    bool attackPressed;
    public bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            if (SaveSystem.LoadPlayer() != null)
            {
                CmdLoadData();
            }

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
            specialButton.SetActive(false);
            enemyButton1.SetActive(false);
            enemyButton2.SetActive(false);
            enemyButton3.SetActive(false);
            characterArrow.SetActive(false);
        }
        else if (!isLocalPlayer)
        {
            playerButton.SetActive(false);
            defendButton.SetActive(false);
            specialButton.SetActive(false);
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
            if (once == false)
            {
                CmdBaseHealthSetter(baseHealth1, baseHealth2, baseHealth3);
            }

            CmdFindPLayers();

            CmdHealthBar(health, health2, health3);

            CmdSpecialBar(mana, mana2, mana3);

            CmdNameSetter(tempName, tempPosition);

            CmdCharacterPosition();

            playerButton.SetActive(isMyTurn);

            defendButton.SetActive(isMyTurn);

            CmdDeathChecker();

            ButtonChecker();

            CmdCharacterLoop();

            SpecialButtonActive(characterNumber);

            CmdArrow(isMyTurn);
        }
    }

    [Command]
    void CmdLoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //Character 1
        string name1 = data.characterName;
        float theExp1 = data.exp;
        startDefence = defenceRating;

        //Character 2
        string name2 = data.characterName2;
        float theExp2 = data.exp2;
        startDefence = defenceRating2;

        //Character 3
        string name3 = data.characterName3;
        float theExp3 = data.exp3;
        startDefence = defenceRating3;

        RpcLoadData(name1, name2, name3, theExp1, theExp2, theExp3);
    }

    [ClientRpc]
    void RpcLoadData(string name1, string name2, string name3, float theExp1, float theExp2, float theExp3)
    {
        //Character 1
        characterName = name1;
        myExp = theExp1;

        //Character 2
        characterName2 = name2;
        myExp2 = theExp2;

        //Character 3
        characterName3 = name3;
        myExp3 = theExp3;
    }

    //turns character arrow on and off
    [Command]
    void CmdArrow(bool turnBool)
    {
        RpcArrow(turnBool);
    }

    [ClientRpc]
    void RpcArrow(bool turnBool)
    {
        characterArrow.SetActive(turnBool);
    }

    //sets starting health for characters health bar
    [Command]
    void CmdBaseHealthSetter(float num, float num2, float num3)
    {
        RpcBaseHealthSetter(num, num2, num3);
    }

    [ClientRpc]
    void RpcBaseHealthSetter(float num1, float num2, float num3)
    {
        baseHealth1 = health;
        baseHealth2 = health2;
        baseHealth3 = health3;
        once = true;
    }

    //Used to progress through players character
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

    //Used to show the current active character
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

    //Used to check if a character is dead and if the game is over
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

    //Checks which opponents can be attacked
    void ButtonChecker()
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

    //check if a character is able to use their special attack
    void SpecialButtonActive(int number)
    {
        switch (number)
        {
            case 1:
                if (mana >= 100f)
                {
                    SpecialButtonsOnOff(true);
                }
                else
                {
                    SpecialButtonsOnOff(false);
                }
                break;
            case 2:
                if (mana2 >= 100f)
                {
                    SpecialButtonsOnOff(true);
                }
                else
                {
                    SpecialButtonsOnOff(false);
                }
                break;
            case 3:
                if (mana3 >= 100f)
                {
                    SpecialButtonsOnOff(true);
                }
                else
                {
                    SpecialButtonsOnOff(false);
                }
                break;
            default:
                specialButton.SetActive(false);
                break;
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

    //sets turn values for the player
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

    //set position of players specialbar
    [Command]
    void CmdSpecialBar(float value, float value2, float value3)
    {
        Vector3 pos1 = Vector3.zero;
        Vector3 pos2 = Vector3.zero;
        Vector3 pos3 = Vector3.zero;
        if (connectID == 1)
        {
            pos1 = new Vector3(-400f, 150f, 0f);
            pos2 = new Vector3(-400f, 0f, 0f);
            pos3 = new Vector3(-400f, -150f, 0f);
        }
        else
        {
            pos1 = new Vector3(400f, 150f, 0f);
            pos2 = new Vector3(400f, 0f, 0f);
            pos3 = new Vector3(400f, -150f, 0f);
        }

        RpcSpecialBar(value, value2, value3, pos1, pos2, pos3);
    }

    [ClientRpc]
    void RpcSpecialBar(float value, float value2, float value3, Vector3 pos1, Vector3 pos2, Vector3 pos3)
    {
        specialBar.fillAmount = value / 100f;
        specialBar2.fillAmount = value2 / 100f;
        specialBar3.fillAmount = value3 / 100f;
        specialBar.transform.localPosition = pos1;
        specialBar2.transform.localPosition = pos2;
        specialBar3.transform.localPosition = pos3;
    }

    //set position of players Healthbar
    [Command]
    void CmdHealthBar(float value, float value2, float value3)
    {
        Vector3 pos1 = Vector3.zero;
        Vector3 pos2 = Vector3.zero;
        Vector3 pos3 = Vector3.zero;
        if (connectID == 1)
        {
            pos1 = new Vector3(-300f, 225f, 0f);
            pos2 = new Vector3(-300f, 75f, 0f);
            pos3 = new Vector3(-300f, -75f, 0f);
        }
        else
        {
            pos1 = new Vector3(300f, 225f, 0f);
            pos2 = new Vector3(300f, 75f, 0f);
            pos3 = new Vector3(300f, -75f, 0f);
        }

        RpcHealthBar(value, value2, value3, pos1, pos2, pos3, baseHealth1, baseHealth2, baseHealth3);
    }

    [ClientRpc]
    void RpcHealthBar(float value, float value2, float value3, Vector3 pos1, Vector3 pos2, Vector3 pos3, float bHealth, float bHealth2, float bHealth3)
    {
        healthBar.fillAmount = value / bHealth;
        healthBar2.fillAmount = value2 / bHealth2;
        healthBar3.fillAmount = value3 / bHealth3;
        healthBar.transform.localPosition = pos1;
        healthBar2.transform.localPosition = pos2;
        healthBar3.transform.localPosition = pos3;
    }

    //Finds other player within the current scene
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

    //sets Players Name and the position of it
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

    public void Attack1()
    {
        if (isSpecial == true)
        {
            CmdSpecialAttack(percent, 1);
        }
        else
        {
            CmdDefendChecker(1);
        }
    }

    public void Attack2()
    {
        if (isSpecial == true)
        {
            CmdSpecialAttack(percent, 2);
        }
        else
        {
            CmdDefendChecker(2);
        }
    }

    public void Attack3()
    {
        if (isSpecial == true)
        {
            CmdSpecialAttack(percent, 3);
        }
        else
        {
            CmdDefendChecker(3);
        }
    }

    //used to apply damage to enemy characters
    [ClientRpc]
    void RpcAttackOptions(int enemy, bool set, bool attack1, bool attack2, bool attack3, float defending, int manaAdd, int playerNum)
    {
        ManaAdder(manaAdd);
        characterNumber = playerNum;

        AttackButtonsOnOff(set);

        if (attack1 == false && attack2 == false && attack3 == false)
        {
            myOpponent.TakeDamage(enemy, defending, manaAdd);
        }
        else
        {
            if (attack1 == true)
            {
                myOpponent.TakeDamage(1, defending, manaAdd);
            }

            if (attack2 == true)
            {
                myOpponent.TakeDamage(2, defending, manaAdd);
            }

            if (attack3 == true)
            {
                myOpponent.TakeDamage(3, defending, manaAdd);

            }
        }
    }

    
    //used to check if an enemy character is defending or not
    [Command]
    void CmdDefendChecker(int target)
    {
        int playerNum = characterNumber;
        int playerNum2 = characterNumber + 1;

        bool defend1 = myOpponent.isDefending;
        bool defend2 = myOpponent.isDefending2;
        bool defend3 = myOpponent.isDefending3;

        if (target == 1)
        {
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

            RpcAttackOptions(1, set, attack1, attack2, attack3, theDefending, playerNum, playerNum2);
        }

        if (target == 2)
        {
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

            RpcAttackOptions(2, set, attack1, attack2, attack3, theDefending, playerNum, playerNum2);
        }

        if (target == 3)
        {
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

            RpcAttackOptions(3, set, attack1, attack2, attack3, theDefending, playerNum, playerNum2);
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

    //Special move option
    [Command]
    public void CmdSpecial()
    {
        SpecialButtonsOnOff(false);
        int number = characterNumber;
        RpcSpecial(number);
    }

    [ClientRpc]
    void RpcSpecial(int number)
    {
        switch (number)
        {
            case 1:
                CharacterSpecialMove(characterName);
                this.mana = 0f;
                this.characterNumber += 1;
                break;
            case 2:
                CharacterSpecialMove(characterName2);
                this.mana2 = 0f;
                this.characterNumber += 1;
                break;
            case 3:
                CharacterSpecialMove(characterName3);
                this.mana3 = 0f;
                this.characterNumber += 1;
                break;
        }
    }

    void CharacterSpecialMove(string charaName)
    {
        isSpecial = true;
        string theName = charaName;
        switch (theName)
        {
            case "fishman":
                percent = 10f;
                AttackButtonsOnOff(true);
                break;
            case "werewolf":
                percent = 50f;
                AttackButtonsOnOff(true);
                break;
            case "bukkake Slime":
                break;
            case "dragonoid":
                break;
            case "golem":
                break;
            case "catperson":
                percent = 25f;
                AttackButtonsOnOff(true);
                break;
            case "angel":
                percent = 100f;
                AttackButtonsOnOff(true);
                break;
            case "devil":
                percent = 75f;
                AttackButtonsOnOff(true);
                break;
            case "orge":
                break;
            case "gargoyle":
                break;
            case "garuda":
                break;
            case "loxodon":
                break;
            case "minotaur":
                break;
            case "spiderperson":
                break;
            case "hobnoblin":
                percent = 25f;
                AttackButtonsOnOff(true);
                break;
        }
    }

    [Command]
    void CmdSpecialAttack(float percent, int enemy)
    {
        isSpecial = false;
        float baseDamage = 0f;
        switch (characterNumber)
        {
            case 1:
                baseDamage = attackRating;
                break;
            case 2:
                baseDamage = attackRating2;
                break;
            case 3:
                baseDamage = attackRating3;
                break;
        }

        float increase = baseDamage / 100f;
        float increase2 = increase * percent;
        float setDamage = increase2 + baseDamage;

        switch (enemy)
        {
            case 1:
                myOpponent.health -= setDamage;
                break;
            case 2:
                myOpponent.health2 -= setDamage;
                break;
            case 3:
                myOpponent.health3 -= setDamage;
                break;
        }
    }

    [Command]
    void CmdSpecialDefence(float percent)
    {
        float baseDefence = 0f;
        switch (characterNumber)
        {
            case 1:
                baseDefence = defenceRating;
                break;
            case 2:
                baseDefence = defenceRating2;
                break;
            case 3:
                baseDefence = defenceRating3;
                break;
        }

        float increase = (baseDefence / 100f) * percent;
        float setDefence = increase + baseDefence;
    }

    //decreases character health
    void TakeDamage(int enemy, float defending, int character)
    {
        sourceDamage = 0f;
        switch (character)
        {
            case 1:
                sourceDamage = myOpponent.attackRating;
                break;
            case 2:
                sourceDamage = myOpponent.attackRating2;
                break;
            case 3:
                sourceDamage = myOpponent.attackRating3;
                break;
        }

        if (enemy == 1)
        {
            float myDamage = sourceDamage;
            float myDefence = defenceRating;
            float modifier = myDamage / myDefence;
            ModifierDamage(modifier, myDamage, defending);
            this.health -= sourceDamage;
        }

        if (enemy == 2)
        {
            float myDamage = sourceDamage;
            float myDefence = defenceRating2;
            float modifier = myDamage / myDefence;
            ModifierDamage(modifier, myDamage, defending);
            this.health2 -= sourceDamage;
        }

        if (enemy == 3)
        {
            float myDamage = sourceDamage;
            float myDefence = defenceRating3;
            float modifier = myDamage / myDefence;
            ModifierDamage(modifier, myDamage, defending);
            this.health3 -= sourceDamage;
        }
    }

    //changes attack damage depending on the defending character defenceRating
    void ModifierDamage(float modify, float theDamage, float defenders)
    {
        if (modify < 1.0f)
        {
            finalDamage = modify * theDamage;
        }
        else
        {
            finalDamage = theDamage;
        }

        if (defenders > 0f)
        {
            finalDamage /= defenders;
        }

        sourceDamage = finalDamage;
    }

    //Button Stuff
    void AttackButtonsOnOff(bool set)
    {
        enemyButton1.SetActive(set);
        enemyButton2.SetActive(set);
        enemyButton3.SetActive(set);
        enemyButton1.transform.localPosition = new Vector3(0f, 150f, 0f);
        enemyButton2.transform.localPosition = new Vector3(0f, 0f, 0f);
        enemyButton3.transform.localPosition = new Vector3(0f, -150f, 0f);
    }

    //More Button Stuff
    void SpecialButtonsOnOff(bool set)
    {
        specialButton.SetActive(set);
    }

    //added values to special bars
    void ManaAdder(int character)
    {
        switch (character)
        {
            case 1:
                this.mana += 25;
                break;
            case 2:
                this.mana2 += 25;
                break;
            case 3:
                this.mana3 += 25;
                break;
        }
    }
}
