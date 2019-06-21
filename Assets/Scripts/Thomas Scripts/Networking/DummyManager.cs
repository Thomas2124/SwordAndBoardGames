using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DummyManager : NetworkBehaviour
{
    [SyncVar]
    public bool player1Joined = false;
    public bool player2Joined = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
