using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerSpriteSetter : NetworkBehaviour
{
    /// <summary>
    /// This Script is not being used.
    /// </summary>

    public GameObject player1;
    public GameObject player2;

    public List<PlayerController> players;

    public List<string> theCharacterNames;
    public List<GameObject> theCharacterSprites;

    public List<string> theCharacterNames2;
    public List<GameObject> theCharacterSprites2;

    public int connectID;

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

    public bool set1 = false;
    public bool set2 = false;
    // Start is called before the first frame update
    void Start()
    {
        connectID = NetworkServer.connections.Count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        players = ClientScene.localPlayers;
        //player1 = players[0].gameObject;
        //player2 = players[1].gameObject;
        //player1 = NetworkManager.singleton.client.connection.playerControllers[0].gameObject;
        //player2 = NetworkManager.singleton.client.connection.playerControllers[1].gameObject;

        CmdFindThePlayers();
    }

    [Command]
    void CmdFindThePlayers()
    {
        player1 = players[0].gameObject;
        //player2 = players[1].gameObject;
        if (players[0].gameObject != null)
        {
            theCharacterNames = players[0].gameObject.GetComponent<PlayerScript>().theCharacterNames;
            theCharacterSprites = players[0].gameObject.GetComponent<PlayerScript>().theCharacterSprites;

            foreach (string item in theCharacterNames)
            {
                RpcCharacterSprites(item);
            }
        }
    }

    /*[ClientRpc]
    void RpcFindThePlayers()
    {
        if (players[0].gameObject != null)
        {
            theCharacterNames = players[0].gameObject.GetComponent<PlayerScript>().theCharacterNames;
            theCharacterSprites = players[0].gameObject.GetComponent<PlayerScript>().theCharacterSprites;

            foreach (string item in collection)
            {

            }
            RpcCharacterSprites();
        }

        else
        {
            foreach (PlayerController item in players)
            {
                if (item != players[0])
                {
                    theCharacterNames2 = item.gameObject.GetComponent<PlayerScript>().theCharacterNames;
                    theCharacterSprites2 = item.gameObject.GetComponent<PlayerScript>().theCharacterSprites;
                }
            }
        }
    }*/

    [ClientRpc]
    void RpcCharacterSprites(string name)
    {
        switch (name)
        {
            case "fishman":
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
    }
}
