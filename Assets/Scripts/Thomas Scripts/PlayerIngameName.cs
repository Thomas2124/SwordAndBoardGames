using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIngameName : MonoBehaviour
{
    public Text username;

    // Update is called once per frame
    void Update()
    {
        username.text = PlayerPrefs.GetString("PlayerName");
    }
}
