using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : NetworkBehaviour
{
    public List<string> theCharacterNames;
    public List<GameObject> theCharacterSprites;
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
    public int level;
    public float myExp;
    public float startingDefence;

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
    public int level2;
    public float myExp2;
    public float startingDefence2;

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
    public int level3;
    public float myExp3;
    public float startingDefence3;

    public bool skip = false;
    public bool skip2 = false;
    public bool skip3 = false;

    public GameObject timerText;

    /*[SyncVar]
    public int nextTime;

    [SyncVar]
    public int turnTime;*/

    //public Sprite thisCharacterSprite1;
    //public Sprite thisCharacterSprite2;
    //public Sprite thisCharacterSprite3;

    //public Sprite enemyCharacterSprite1;
    //public Sprite enemyCharacterSprite2;
    //public Sprite enemyCharacterSprite3;

    [SyncVar]
    public int thisCharacterSprite1;
    [SyncVar]
    public int thisCharacterSprite2;
    [SyncVar]
    public int thisCharacterSprite3;

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

    public GameObject character4;
    public GameObject character5;
    public GameObject character6;

    [Header("Player Turn Buttons")]
    public GameObject playerButton;
    public GameObject defendButton;
    public GameObject specialButton;
    public GameObject enemyButton1;
    public GameObject enemyButton2;
    public GameObject enemyButton3;
    public PlayerScript myOpponent;
    //public GameObject menuButton;
    [Header("Player Bars/Images")]
    public GameObject characterArrow;
    public Image healthBar;
    public Image healthBar2;
    public Image healthBar3;
    public Image specialBar;
    public Image specialBar2;
    public Image specialBar3;

    public GameObject victoryText;
    public float percent;

    [Header("Turn Stuff")]
    [SyncVar]
    public int characterNumber;
    [SyncVar]
    public bool isMyTurn;
    [SyncVar]
    public int connectID;

    public bool isFishman;
    public bool isDragnoid;
    public bool isGaruda;
    public bool isSpider;

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

    [Header("Character exp loaded")]
    public float fishman_exp;
    public float werewolf_exp;
    public float bukkakeSlime_exp;
    public float dragonoid_exp;
    public float golem_exp;
    public float catperson_exp;
    public float angel_exp;
    public float devil_exp;
    public float orge_exp;
    public float gargoyle_exp;
    public float garuda_exp;
    public float loxodon_exp;
    public float minotaur_exp;
    public float spiderperson_exp;
    public float hobnoblin_exp;

    [Header("Character sprites")]
    public Sprite fishman_Sprite;
    public Sprite werewolf_Sprite;
    public Sprite bukkakeSlime_Sprite;
    public Sprite dragonoid_Sprite;
    public Sprite golem_Sprite;
    public Sprite catperson_Sprite;
    public Sprite angel_Sprite;
    public Sprite devil_Sprite;
    public Sprite orge_Sprite;
    public Sprite gargoyle_Sprite;
    public Sprite garuda_Sprite;
    public Sprite loxodon_Sprite;
    public Sprite minotaur_Sprite;
    public Sprite spiderperson_Sprite;
    public Sprite hobnoblin_Sprite;



    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            //turnTime = 60;
            isWinner = false;
            isDead = false;
            isDead2 = false;
            isDead3 = false;

            if (SaveSystem.LoadPlayer() != null)
            {
                CmdLoadData();
            }
            else
            {
                CmdStatSetter();
            }

            if (ExpSaveSystem.LoadPlayer() != null)
            {
                ExpSaver expData = ExpSaveSystem.LoadPlayer();
                fishman_exp = expData.fishman_exp;
                werewolf_exp = expData.werewolf_exp;
                bukkakeSlime_exp = expData.bukkakeSlime_exp;
                dragonoid_exp = expData.dragonoid_exp;
                golem_exp = expData.golem_exp;
                catperson_exp = expData.catperson_exp;
                angel_exp = expData.angel_exp;
                devil_exp = expData.devil_exp;
                orge_exp = expData.orge_exp;
                gargoyle_exp = expData.gargoyle_exp;
                garuda_exp = expData.garuda_exp;
                loxodon_exp = expData.loxodon_exp;
                minotaur_exp = expData.minotaur_exp;
                spiderperson_exp = expData.spiderperson_exp;
                hobnoblin_exp = expData.hobnoblin_exp;
            }

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
            timerText.SetActive(true);
            victoryText.SetActive(false);
            character1.SetActive(true);
            character2.SetActive(true);
            character3.SetActive(true);
            character4.SetActive(true);
            character5.SetActive(true);
            character6.SetActive(true);
            //menuButton.SetActive(false);

            timerText.transform.localPosition = new Vector3(0f, 250f, 0f);
            victoryText.transform.localPosition = new Vector3(0f, 0f, 0f);
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
            timerText.SetActive(false);
            victoryText.SetActive(false);
            character1.SetActive(false);
            character2.SetActive(false);
            character3.SetActive(false);
            character4.SetActive(false);
            character5.SetActive(false);
            character6.SetActive(false);
            //menuButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            CmdFindPLayers();

            if (myOpponent != null && myOpponent.isWinner == false && this.isWinner == false)
            {
                if (once == false)
                {
                    CmdBaseHealthSetter(baseHealth1, baseHealth2, baseHealth3);
                    CmdCharacterSprites();
                }

                CmdHealthBar(health, health2, health3);

                CmdSpecialBar(mana, mana2, mana3);

                CmdNameSetter(tempName, tempPosition);

                CmdCharacterPosition();

                playerButton.SetActive(isMyTurn);

                defendButton.SetActive(isMyTurn);

                timerText.SetActive(isMyTurn);

                CmdDeathChecker(health, health2, health3);

                CmdGetSprites();

                ButtonChecker();

                CmdCharacterLoop();

                SpecialButtonActive(characterNumber);

                CmdArrow(isMyTurn);

                CmdTheWin();
            }

            /*if (myOpponent != null)
            {
                if (System.DateTime.Now.Second >= nextTime && isMyTurn == true)
                {
                    nextTime = System.DateTime.Now.Second + 1;
                    turnTime -= 1;
                    CmdTimerStuff(turnTime);
                }

                if (turnTime <= 0)
                {
                    characterNumber = 4;
                }
            }*/
        }
    }

    [Command]
    void CmdGetSprites()
    {
        int num1 = myOpponent.thisCharacterSprite1;
        int num2 = myOpponent.thisCharacterSprite2;
        int num3 = myOpponent.thisCharacterSprite3;

        RpcGetSprites(num1);
        RpcGetSprites(num2);
        RpcGetSprites(num3);
    }

    [ClientRpc]
    void RpcGetSprites(int num)
    {
        Sprite spriteToUse = fishman_Sprite;
        switch (num)
        {
            case 1:
                spriteToUse = fishman_Sprite;

                break;
            case 2:
                spriteToUse = werewolf_Sprite;

                break;
            case 3:
                spriteToUse = bukkakeSlime_Sprite;

                break;
            case 4:
                spriteToUse = dragonoid_Sprite;

                break;
            case 5:
                spriteToUse = golem_Sprite;

                break;
            case 6:
                spriteToUse = catperson_Sprite;

                break;
            case 7:
                spriteToUse = angel_Sprite;

                break;
            case 8:
                spriteToUse = devil_Sprite;

                break;
            case 9:
                spriteToUse = orge_Sprite;

                break;
            case 10:
                spriteToUse = gargoyle_Sprite;

                break;
            case 11:
                spriteToUse = garuda_Sprite;

                break;
            case 12:
                spriteToUse = loxodon_Sprite;

                break;
            case 13:
                spriteToUse = minotaur_Sprite;

                break;
            case 14:
                spriteToUse = spiderperson_Sprite;

                break;
            case 15:
                spriteToUse = hobnoblin_Sprite;

                break;
        }

        if (num == myOpponent.thisCharacterSprite1)
        {
            this.character4.GetComponent<Image>().sprite = spriteToUse;
        }

        if (num == myOpponent.thisCharacterSprite2)
        {
            this.character5.GetComponent<Image>().sprite = spriteToUse;
        }

        if (num == myOpponent.thisCharacterSprite3)
        {
            this.character6.GetComponent<Image>().sprite = spriteToUse;
        }
    }

    [Command]
    void CmdCharacterSprites()
    {
        foreach (string item in theCharacterNames)
        {
            RpcCharacterSprites(item);
        }
    }

    [ClientRpc]
    void RpcCharacterSprites(string name)
    {
        int number = 0;
        switch (name)
        {
            case "fishman":
                number = 1;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = fishman_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = fishman_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = fishman_Sprite;
                }
                break;
            case "werewolf":
                number = 2;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = werewolf_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = werewolf_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = werewolf_Sprite;
                }
                break;
            case "bukkake Slime":
                number = 3;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = bukkakeSlime_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = bukkakeSlime_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = bukkakeSlime_Sprite;
                }

                break;
            case "dragonoid":
                number = 4;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = dragonoid_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = dragonoid_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = dragonoid_Sprite;
                }

                break;
            case "golem":
                number = 5;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = golem_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = golem_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = golem_Sprite;
                }

                break;
            case "catperson":
                number = 6;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = catperson_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = catperson_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = catperson_Sprite;
                }

                break;
            case "angel":
                number = 7;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = angel_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = angel_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = angel_Sprite;
                }

                break;
            case "devil":
                number = 8;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = devil_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = devil_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = devil_Sprite;
                }

                break;
            case "orge":
                number = 9;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = orge_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = orge_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = orge_Sprite;
                }

                break;
            case "gargoyle":
                number = 10;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = gargoyle_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = gargoyle_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = gargoyle_Sprite;
                }

                break;
            case "garuda":
                number = 11;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = garuda_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = garuda_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = garuda_Sprite;
                }

                break;
            case "loxodon":
                number = 12;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = loxodon_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = loxodon_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = loxodon_Sprite;
                }

                break;
            case "minotaur":
                number = 13;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = minotaur_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = minotaur_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = minotaur_Sprite;
                }

                break;
            case "spiderperson":
                number = 14;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = spiderperson_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = spiderperson_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = spiderperson_Sprite;
                }

                break;
            case "hobnoblin":
                number = 15;
                if (name == this.theCharacterNames[0])
                {
                    this.theCharacterSprites[0].GetComponent<Image>().sprite = hobnoblin_Sprite;
                }
                else if (name == this.theCharacterNames[1])
                {
                    this.theCharacterSprites[1].GetComponent<Image>().sprite = hobnoblin_Sprite;
                }
                else if (name == this.theCharacterNames[2])
                {
                    this.theCharacterSprites[2].GetComponent<Image>().sprite = hobnoblin_Sprite;
                }

                break;
        }

        if (name == this.theCharacterNames[0])
        {
            this.thisCharacterSprite1 = number;
        }

        if (name == this.theCharacterNames[1])
        {
            this.thisCharacterSprite2 = number;
        }

        if (name == this.theCharacterNames[2])
        {
            this.thisCharacterSprite3 = number;
        }
    }



    [Command]
    void CmdTheWin()
    {
        bool one = isDead;
        bool two = isDead2;
        bool three = isDead3;
        bool four = myOpponent.isDead;
        bool five = myOpponent.isDead2;
        bool six = myOpponent.isDead3;
        bool win1 = isWinner;
        bool win2 = myOpponent.isWinner;

        RpcTheWin(one, two, three, four, five, six, win1, win2);
    }

    [ClientRpc]
    void RpcTheWin(bool one, bool two, bool three, bool four, bool five, bool six, bool win1, bool win2)
    {
        if (one == true && two == true && three == true || four == true && five == true && six == true)
        {
            this.victoryText.SetActive(true);
            myOpponent.victoryText.SetActive(true);

            if (win1 == true)
            {
                this.victoryText.transform.localPosition = new Vector3(450f, 0f, 0f);
                this.victoryText.GetComponent<Text>().text = "Winner";

                foreach (string item in theCharacterNames)
                {
                    string theName = item;
                    switch (theName)
                    {
                        case "fishman":
                            this.fishman_exp += 50f;
                            break;
                        case "werewolf":
                            this.werewolf_exp += 50f;
                            break;
                        case "bukkake Slime":
                            this.bukkakeSlime_exp += 50f;
                            break;
                        case "dragonoid":
                            this.dragonoid_exp += 50f;
                            break;
                        case "golem":
                            this.golem_exp += 50f;
                            break;
                        case "catperson":
                            this.catperson_exp += 50f;
                            break;
                        case "angel":
                            this.angel_exp += 50f;
                            break;
                        case "devil":
                            this.devil_exp += 50f;
                            break;
                        case "orge":
                            this.orge_exp += 50f;
                            break;
                        case "gargoyle":
                            this.gargoyle_exp += 50f;
                            break;
                        case "garuda":
                            this.garuda_exp += 50f;
                            break;
                        case "loxodon":
                            this.loxodon_exp += 50f;
                            break;
                        case "minotaur":
                            this.minotaur_exp += 50f;
                            break;
                        case "spiderperson":
                            this.spiderperson_exp += 50f;
                            break;
                        case "hobnoblin":
                            this.hobnoblin_exp += 50f;
                            break;
                    }
                }

                ExpSaveSystem.SavePlayer(this);
            }
            else
            {
                this.victoryText.transform.localPosition = new Vector3(450f, 0f, 0f);
                this.victoryText.GetComponent<Text>().text = "Loser";
            }

            if (win2 == true)
            {
                myOpponent.victoryText.transform.localPosition = new Vector3(-450f, 0f, 0f);
                myOpponent.victoryText.GetComponent<Text>().text = "Winner";

                foreach (string item in theCharacterNames)
                {
                    string theName = item;
                    switch (theName)
                    {
                        case "fishman":
                            myOpponent.fishman_exp += 50f;
                            break;
                        case "werewolf":
                            myOpponent.werewolf_exp += 50f;
                            break;
                        case "bukkake Slime":
                            myOpponent.bukkakeSlime_exp += 50f;
                            break;
                        case "dragonoid":
                            myOpponent.dragonoid_exp += 50f;
                            break;
                        case "golem":
                            myOpponent.golem_exp += 50f;
                            break;
                        case "catperson":
                            myOpponent.catperson_exp += 50f;
                            break;
                        case "angel":
                            myOpponent.angel_exp += 50f;
                            break;
                        case "devil":
                            myOpponent.devil_exp += 50f;
                            break;
                        case "orge":
                            myOpponent.orge_exp += 50f;
                            break;
                        case "gargoyle":
                            myOpponent.gargoyle_exp += 50f;
                            break;
                        case "garuda":
                            myOpponent.garuda_exp += 50f;
                            break;
                        case "loxodon":
                            myOpponent.loxodon_exp += 50f;
                            break;
                        case "minotaur":
                            myOpponent.minotaur_exp += 50f;
                            break;
                        case "spiderperson":
                            myOpponent.spiderperson_exp += 50f;
                            break;
                        case "hobnoblin":
                            myOpponent.hobnoblin_exp += 50f;
                            break;
                    }
                }

                ExpSaveSystem.SavePlayer(myOpponent);
            }
            else
            {
                myOpponent.victoryText.transform.localPosition = new Vector3(-450f, 0f, 0f);
                myOpponent.victoryText.GetComponent<Text>().text = "Loser";
            }

            //this.menuButton.SetActive(true);
            //myOpponent.menuButton.SetActive(true);
            this.characterArrow.SetActive(false);
            myOpponent.characterArrow.SetActive(false);
        }
    }

    /*public void BackToCharacterScreen()
    {
        SceneManager.LoadScene("TL_TestLocalMultiplayer");
        //NetworkManager manager = GetComponent<NetworkManager>();
        //manager.StopServer();
    }*/

    /*[Command]
    void CmdTimerStuff(int turnTime)
    {
        RpcTimerStuff(turnTime);
    }

    [ClientRpc]
    void RpcTimerStuff(int turnTime)
    {
        timerText.GetComponent<Text>().text = turnTime.ToString();
    }*/

    [Command]
    void CmdStatSetter()
    {
        float levelGain = myExp / 100f;

        if (levelGain < 1f)
        {
            level = 1;
        }
        else
        {
            level = Mathf.RoundToInt(levelGain);
            float addHealth = level * 20;
            float addAttack = level * 5;
            float addDefence = level * 10;

            health += addHealth;
            attackRating += addAttack;
            defenceRating += addDefence;
        }

        float levelGain2 = myExp2 / 100f;

        if (levelGain2 < 1f)
        {
            level2 = 1;
        }
        else
        {
            level2 = Mathf.RoundToInt(levelGain2);
            float addHealth = level * 20;
            float addAttack = level * 5;
            float addDefence = level * 10;

            health2 += addHealth;
            attackRating2 += addAttack;
            defenceRating2 += addDefence;
        }

        float levelGain3 = myExp3 / 100f;

        if (levelGain3 < 1f)
        {
            level3 = 1;
        }
        else
        {
            level3 = Mathf.RoundToInt(levelGain3);
            float addHealth = level * 20;
            float addAttack = level * 5;
            float addDefence = level * 10;

            health3 += addHealth;
            attackRating3 += addAttack;
            defenceRating3 += addDefence;
        }


        startingDefence = defenceRating;
        startingDefence2 = defenceRating2;
        startingDefence3 = defenceRating3;
    }

    [Command]
    void CmdLoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //Character 1
        string name1 = data.characterName;
        float health1 = data.health;
        float attack1 = data.attackRating;
        float defence1 = data.defenceRating;
        float theExp1 = data.exp;

        //Character 2
        string name2 = data.characterName2;
        float health2 = data.health2;
        float attack2 = data.attackRating2;
        float defence2 = data.defenceRating2;
        float theExp2 = data.exp2;

        //Character 3
        string name3 = data.characterName3;
        float health3 = data.health3;
        float attack3 = data.attackRating3;
        float defence3 = data.defenceRating3;
        float theExp3 = data.exp3;

        RpcLoadData(name1, name2, name3, theExp1, theExp2, theExp3, health1, health2, health3, attack1, attack2, attack3, defence1, defence2, defence3);
    }

    [ClientRpc]
    void RpcLoadData(string name1, string name2, string name3, float theExp1, float theExp2, float theExp3, float health, float health2, float health3, float attack, float attack2, float attack3, float defence, float defence2, float defence3)
    {
        //Character 1
        this.characterName = name1;
        this.attackRating = attack;
        this.defenceRating = defence;
        this.health = health;
        this.myExp = theExp1;
        this.theCharacterNames.Add(this.characterName);
        this.theCharacterSprites.Add(this.character1);

        //Character 2
        this.characterName2 = name2;
        this.attackRating2 = attack2;
        this.defenceRating2 = defence2;
        this.health2 = health2;
        this.myExp2 = theExp2;
        this.theCharacterNames.Add(this.characterName2);
        this.theCharacterSprites.Add(this.character2);

        //Character 3
        this.characterName3 = name3;
        this.attackRating3 = attack3;
        this.defenceRating3 = defence3;
        this.health3 = health3;
        this.myExp3 = theExp3;
        this.theCharacterNames.Add(this.characterName3);
        this.theCharacterSprites.Add(this.character3);

        this.CmdStatSetter();
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
                if (isDead == false && skip == false)
                {
                    ArrowSetter(1);
                    characterArrow.transform.localPosition = arrowPosition;
                }
                else
                {
                    skip = false;
                    characterNumber += 1;
                }
            }
            else if (characterNumber == 2)
            {
                if (isDead2 == false && skip2 == false)
                {
                    ArrowSetter(2);
                    characterArrow.transform.localPosition = arrowPosition;
                }
                else
                {
                    skip2 = false;
                    characterNumber += 1;
                }
            }
            else if (characterNumber == 3)
            {
                if (isDead3 == false && skip3 == false)
                {
                    ArrowSetter(3);
                    characterArrow.transform.localPosition = arrowPosition;
                }
                else
                {
                    skip3 = false;
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
    void CmdDeathChecker(float heal1, float heal2, float heal3)
    {
        RpcDeathChecker(heal1, heal2, heal3, false, true);
    }

    [ClientRpc]
    void RpcDeathChecker(float heal1, float heal2, float heal3, bool off, bool on)
    {
        if (heal1 <= 0f)
        {
            this.health = 0f;
            this.isDead = on;
            this.character1.SetActive(off);
        }

        if (heal2 <= 0f)
        {
            this.health2 = 0f;
            this.isDead2 = on;
            this.character2.SetActive(off);
        }

        if (heal3 <= 0f)
        {
            this.health3 = 0f;
            this.isDead3 = on;
            this.character3.SetActive(off);
        }

        if (heal1 <= 0f && heal2 <= 0f && heal3 <= 0f)
        {
            myOpponent.isWinner = on;
        }

        if (this.isWinner == on || myOpponent.isWinner == on)
        {
            this.AttackButtonsOnOff(off);
            this.playerButton.SetActive(off);
            this.defendButton.SetActive(off);
            this.specialButton.SetActive(off);
            this.character1.SetActive(off);
            this.character2.SetActive(off);
            this.character3.SetActive(off);
            this.healthBar.enabled = off;
            this.healthBar2.enabled = off;
            this.healthBar3.enabled = off;
            this.specialBar.enabled = off;
            this.specialBar2.enabled = off;
            this.specialBar3.enabled = off;
            this.characterArrow.SetActive(off);

            myOpponent.AttackButtonsOnOff(off);
            myOpponent.playerButton.SetActive(off);
            myOpponent.defendButton.SetActive(off);
            myOpponent.specialButton.SetActive(off);
            myOpponent.character1.SetActive(off);
            myOpponent.character2.SetActive(off);
            myOpponent.character3.SetActive(off);
            myOpponent.healthBar.enabled = off;
            myOpponent.healthBar2.enabled = off;
            myOpponent.healthBar3.enabled = off;
            myOpponent.specialBar.enabled = off;
            myOpponent.specialBar2.enabled = off;
            myOpponent.specialBar3.enabled = off;
            myOpponent.characterArrow.SetActive(off);
            //this.gameObject.SetActive(false);
            //myOpponent.gameObject.SetActive(false);
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
        if (isMyTurn == true)
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
    }

    //position of character images
    [Command]
    void CmdCharacterPosition()
    {
        Vector3 chara1 = Vector3.zero;
        Vector3 chara2 = Vector3.zero;
        Vector3 chara3 = Vector3.zero;
        Vector3 chara4 = Vector3.zero;
        Vector3 chara5 = Vector3.zero;
        Vector3 chara6 = Vector3.zero;

        if (connectID == 1)
        {
            chara1 = new Vector3(-300f, 150f, 0f);
            chara2 = new Vector3(-300f, 0f, 0f);
            chara3 = new Vector3(-300f, -150f, 0f);
            chara4 = new Vector3(300f, 150f, 0f);
            chara5 = new Vector3(300f, 0f, 0f);
            chara6 = new Vector3(300f, -150f, 0f);
        }
        else
        {
            chara1 = new Vector3(300f, 150f, 0f);
            chara2 = new Vector3(300f, 0f, 0f);
            chara3 = new Vector3(300f, -150f, 0f);
            chara4 = new Vector3(-300f, 150f, 0f);
            chara5 = new Vector3(-300f, 0f, 0f);
            chara6 = new Vector3(-300f, -150f, 0f);
        }

        RpcCharacterPosition(chara1, chara2, chara3, chara4, chara5, chara6);
    }

    [ClientRpc]
    void RpcCharacterPosition(Vector3 chara1, Vector3 chara2, Vector3 chara3,Vector3 chara4, Vector3 chara5, Vector3 chara6)
    {
        character1.transform.localPosition = chara1;
        character2.transform.localPosition = chara2;
        character3.transform.localPosition = chara3;
        character4.transform.localPosition = chara4;
        character5.transform.localPosition = chara5;
        character6.transform.localPosition = chara6;

        //this.character4.GetComponent<Image>().sprite = myOpponent.character1.GetComponent<Image>().sprite;

        //this.character5.GetComponent<Image>().sprite = myOpponent.character2.GetComponent<Image>().sprite;

        //this.character6.GetComponent<Image>().sprite = myOpponent.character3.GetComponent<Image>().sprite;
    }

    //sets turn values for the player
    [Command]
    void CmdTurnSetter(bool myBool, bool enemyBool)
    {
        myBool = false;
        enemyBool = true;
        int myNum = 1;
        AttackButtonsOnOff(false);
        playerButton.SetActive(false);
        defendButton.SetActive(false);
        specialButton.SetActive(false);
        RpcTurnSetter(myBool, enemyBool, myNum);
    }

    [ClientRpc]
    void RpcTurnSetter(bool myBool, bool enemyBool, int num)
    {
        this.isMyTurn = myBool;
        myOpponent.isMyTurn = enemyBool;
        this.characterNumber = num;
        myOpponent.characterNumber = num;
        myOpponent.TurnStart();
    }

    void TurnStart()
    {
        CmdTurnStart(false, startingDefence, startingDefence2, startingDefence3);
    }

    [Command]
    void CmdTurnStart(bool mybool, float def1, float def2, float def3)
    {
        RpcTurnStart(mybool, def1, def2, def3);
    }

    [ClientRpc]
    void RpcTurnStart(bool mybool, float def1, float def2, float def3)
    {
        this.isDefending = mybool;
        this.isDefending2 = mybool;
        this.isDefending3 = mybool;
        this.defenceRating = def1;
        this.defenceRating2 = def2;
        this.defenceRating3 = def3;
        this.isGaruda = mybool;
        this.isSpecial = mybool;
        //this.turnTime = 60;
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
        AttackButtonsOnOff(false);
        if (isSpecial == true)
        {
            if (isFishman == true)
            {
                CmdFishSpecial(percent, 1);
            }
            else if(isDragnoid == true)
            {
                CmdDragonoidSpecial(1);
            }
            else if (isSpider == true)
            {
                CmdSpiderSpecial(1);
            }
            else
            {
                CmdSpecialAttack(percent, 1);
            }
        }
        else
        {
            CmdDefendChecker(1);
        }
    }

    public void Attack2()
    {
        AttackButtonsOnOff(false);
        if (isSpecial == true)
        {
            if (isFishman == true)
            {
                CmdFishSpecial(percent, 2);
            }
            else if (isDragnoid == true)
            {
                CmdDragonoidSpecial(2);
            }
            else if (isSpider == true)
            {
                CmdSpiderSpecial(2);
            }
            else
            {
                CmdSpecialAttack(percent, 2);
            }
        }
        else
        {
            CmdDefendChecker(2);
        }
    }

    public void Attack3()
    {
        AttackButtonsOnOff(false);
        if (isSpecial == true)
        {
            if (isFishman == true)
            {
                CmdFishSpecial(percent, 3);
            }
            else if (isDragnoid == true)
            {
                CmdDragonoidSpecial(3);
            }
            else if (isSpider == true)
            {
                CmdSpiderSpecial(3);
            }
            else
            {
                CmdSpecialAttack(percent, 3);
            }
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
        AttackButtonsOnOff(false);

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
        AttackButtonsOnOff(false);
    }

    //Special move option
    public void Special()
    {
        SpecialButtonsOnOff(false);
        int number = characterNumber;
        addSpecial(number);
    }

    void addSpecial(int number)
    {
        switch (number)
        {
            case 1:
                this.CharacterSpecialMove(characterName);
                this.mana = 0f;
                break;
            case 2:
                this.CharacterSpecialMove(characterName2);
                this.mana2 = 0f;
                break;
            case 3:
                this.CharacterSpecialMove(characterName3);
                this.mana3 = 0f;
                break;
        }
    }

    void CharacterSpecialMove(string charaName)
    {
        percent = 0f;
        isSpecial = true;
        string theName = charaName;
        switch (theName)
        {
            case "fishman":
                percent = 20f;
                isFishman = true;
                AttackButtonsOnOff(true);
                break;
            case "werewolf":
                percent = 50f;
                AttackButtonsOnOff(true);
                break;
            case "bukkake Slime":
                CmdSlimeSpecial();
                break;
            case "dragonoid":
                isDragnoid = true;
                AttackButtonsOnOff(true);
                break;
            case "golem":
                percent = 100f;
                CmdSpecialDefence(percent);
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
                percent = 25f;
                CmdSpecialDefence(percent);
                break;
            case "gargoyle":
                percent = 50f;
                CmdSpecialDefence(percent);
                break;
            case "garuda":
                isGaruda = true;
                characterNumber += 1;
                AttackButtonsOnOff(false);
                break;
            case "loxodon":
                percent = 75f;
                CmdSpecialDefence(percent);
                break;
            case "minotaur":
                percent = 50f;
                CmdSpecialDefence(percent);
                break;
            case "spiderperson":
                isSpider = true;
                AttackButtonsOnOff(true);
                break;
            case "hobnoblin":
                percent = 25f;
                AttackButtonsOnOff(true);
                break;
        }
    }

    //code for special attack
    [Command]
    void CmdSpecialAttack(float percent, int enemy)
    {
        sourceDamage = 0f;
        switch (characterNumber)
        {
            case 1:
                sourceDamage = attackRating;
                break;
            case 2:
                sourceDamage = attackRating2;
                break;
            case 3:
                sourceDamage = attackRating3;
                break;
        }

        float increase = sourceDamage / 100f;
        float increase2 = increase * percent;
        sourceDamage += increase2;

        isSpecial = false;
        AttackButtonsOnOff(false);

        characterNumber += 1;
        RpcSpecialAttack(sourceDamage, enemy);
    }



    [ClientRpc]
    void RpcSpecialAttack(float damage, float enemy)
    {
        myOpponent.TakeSpecialDamage(enemy, damage);
    }

    //code for special defence move
    [Command]
    void CmdSpecialDefence(float percent)
    {
        float baseDefence = 0f;
        switch (characterNumber)
        {
            case 1:
                isDefending = true;
                baseDefence = defenceRating;
                break;
            case 2:
                isDefending2 = true;
                baseDefence = defenceRating2;
                break;
            case 3:
                isDefending3 = true;
                baseDefence = defenceRating3;
                break;
        }

        float increase = baseDefence / 100f;
        float increase2 = increase * percent;
        baseDefence += increase2;
        isSpecial = false;
        characterNumber += 1;
        AttackButtonsOnOff(false);
        RpcSpecialDefence(baseDefence, characterNumber);
    }

    [ClientRpc]
    void RpcSpecialDefence(float increase, int playerNum)
    {
        switch (characterNumber)
        {
            case 1:
                this.defenceRating = increase;
                break;
            case 2:
                this.defenceRating2 = increase;
                break;
            case 3:
                this.defenceRating3 = increase;
                break;
        }
    }

    //special move for fishman
    [Command]
    void CmdFishSpecial(float number, int enemy)
    {
        float baseAttack = 0f;
        float baseDefence = 0f;

        switch (characterNumber)
        {
            case 1:
                isDefending = true;
                baseDefence = defenceRating;
                baseAttack = attackRating;
                break;
            case 2:
                isDefending2 = true;
                baseDefence = defenceRating2;
                baseAttack = attackRating2;
                break;
            case 3:
                isDefending3 = true;
                baseDefence = defenceRating3;
                baseAttack = attackRating3;
                break;
        }

        float increase = baseAttack / 100f;
        float increase2 = increase * number;
        baseAttack += increase2;

        float increase3 = baseDefence / 100f;
        float increase4 = increase * number;
        baseDefence += increase4;

        RpcFishSpecial(baseDefence, baseAttack, enemy, characterNumber);
    }

    [ClientRpc]
    void RpcFishSpecial(float defence, float attack, int enemy, float character)
    {
        AttackButtonsOnOff(false);
        switch (character)
        {
            case 1:
                defenceRating = defence;
                break;
            case 2:
                defenceRating2 = defence;
                break;
            case 3:
                defenceRating3 = defence;
                break;
        }

        switch (enemy)
        {
            case 1:
                myOpponent.health -= attack;
                break;
            case 2:
                myOpponent.health2 -= attack;
                break;
            case 3:
                myOpponent.health3 -= attack;
                break;
        }

        isSpecial = false;
        isFishman = false;
        characterNumber += 1;
        AttackButtonsOnOff(false);
    }

    [Command]
    void CmdSlimeSpecial()
    {
        int randomNum = Random.Range(1, 50);

        if (randomNum >= 20 && randomNum < 30)
        {
            int counter = 0;
            if (myOpponent.isDead == false)
            {
                counter += 1;
            }

            if (myOpponent.isDead2 == false)
            {
                counter += 1;
            }

            if (myOpponent.isDead3 == false)
            {
                counter += 1;
            }

            int enemyPick = Random.Range(1, counter);
            RpcSlimeSpecial(enemyPick);
        }
        else
        {
            switch (characterNumber)
            {
                case 1:
                    float value = health / 100f;
                    health -= value * 20f;
                    break;
                case 2:
                    float value2 = health2 / 100f;
                    health2 -= value2 * 20f;
                    break;
                case 3:
                    float value3 = health3 / 100f;
                    health3 -= value3 * 20f;
                    break;
            }
        }

        characterNumber += 1;
        AttackButtonsOnOff(false);
    }

    [ClientRpc]
    void RpcSlimeSpecial(int num)
    {
        switch (num)
        {
            case 1:
                if (myOpponent.isDead == false)
                {
                    myOpponent.health = 0f;
                }
                else if (myOpponent.isDead2 == false)
                {
                    myOpponent.health2 = 0f;
                }
                else
                {
                    myOpponent.health3 = 0f;
                }
                break;
            case 2:
                if (myOpponent.isDead2 == false)
                {
                    myOpponent.health2 = 0f;
                }
                else if (myOpponent.isDead == false)
                {
                    myOpponent.health = 0f;
                }
                else
                {
                    myOpponent.health3 = 0f;
                }
                break;
            case 3:
                if (myOpponent.isDead3 == false)
                {
                    myOpponent.health3 = 0f;
                }
                else if (myOpponent.isDead2 == false)
                {
                    myOpponent.health2 = 0f;
                }
                else
                {
                    myOpponent.health = 0f;
                }
                break;
        }
    }

    [Command]
    void CmdDragonoidSpecial(int num)
    {
        characterNumber += 1;
        RpcDragonoidSpecial(num);
    }

    [ClientRpc]
    void RpcDragonoidSpecial(int num)
    {
        AttackButtonsOnOff(false);
        isDragnoid = false;
        isSpecial = false;
        switch (num)
        {
            case 1:
                myOpponent.skip = true;
                break;
            case 2:
                myOpponent.skip2 = true;
                break;
            case 3:
                myOpponent.skip3 = true;
                break;
        }
    }

    [Command]
    void CmdSpiderSpecial(int num)
    {
        characterNumber += 1;

        RpcSpiderSpecial(num, myOpponent.mana, myOpponent.mana2, myOpponent.mana3);
    }

    [ClientRpc]
    void RpcSpiderSpecial(int num, float mVal, float mVal2, float mVal3)
    {
        AttackButtonsOnOff(false);
        isSpider = false;
        isSpecial = false;
        switch (num)
        {
            case 1:
                float value = mVal / 100f;
                myOpponent.mana -= value * 25f;
                break;
            case 2:
                float value2 = mVal2 / 100f;
                myOpponent.mana2 -= value2 * 25f;
                break;
            case 3:
                float value3 = mVal3 / 100f;
                myOpponent.mana3 -= value3 * 25f;
                break;
        }
    }

    //take damage for special attacks only
    void TakeSpecialDamage(float enemy, float damage)
    {
        switch (enemy)
        {
            case 1:
                if (myOpponent.characterName == "garuda" && myOpponent.isGaruda == true)
                {

                }
                else
                {
                    health -= damage;
                }
                break;
            case 2:
                if (myOpponent.characterName2 == "garuda" && myOpponent.isGaruda == true)
                {

                }
                else
                {
                    health2 -= damage;
                }
                break;
            case 3:
                if (myOpponent.characterName3 == "garuda" && myOpponent.isGaruda == true)
                {

                }
                else
                {
                    health3 -= damage;
                }
                break;
        }
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

        if (enemy == 1 && myOpponent.characterName != "garuda" && myOpponent.isGaruda == false)
        {
            float myDamage = sourceDamage;
            float myDefence = defenceRating;
            float modifier = myDamage / myDefence;
            ModifierDamage(modifier, myDamage, defending);
            this.health -= sourceDamage;
        }

        if (enemy == 2 && myOpponent.characterName2 != "garuda" && myOpponent.isGaruda == false)
        {
            float myDamage = sourceDamage;
            float myDefence = defenceRating2;
            float modifier = myDamage / myDefence;
            ModifierDamage(modifier, myDamage, defending);
            this.health2 -= sourceDamage;
        }

        if (enemy == 3 && myOpponent.characterName3 != "garuda" && myOpponent.isGaruda == false)
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
