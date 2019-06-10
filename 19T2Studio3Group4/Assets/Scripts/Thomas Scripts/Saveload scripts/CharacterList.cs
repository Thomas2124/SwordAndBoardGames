using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public float health = 200f;
    public float attackRating = 40f;
    public float defenceRating = 60f;
    public int level = 3;
    public float exp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Character1Stats()
    {

    }

    public void SaveStats()
    {
        SaveSystem.SavePlayer(this);
    }
}
