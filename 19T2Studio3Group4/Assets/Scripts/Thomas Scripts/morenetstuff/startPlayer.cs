using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class startPlayer : NetworkBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            GameObject go = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (!isServer)
        {
            GameObject go = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
    }
}
