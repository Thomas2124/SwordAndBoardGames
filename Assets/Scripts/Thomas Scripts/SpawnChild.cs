using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject[] spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        mainObject = GameObject.Find("CharacterSelectp1.image");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        if (spawnObjects.Length <= 0 || spawnObjects == null)
        {
            Debug.Log("No objects!");
        }
        else
        {
            GameObject theObject = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], Vector2.zero, Quaternion.identity);
            theObject.transform.SetParent(mainObject.transform);
        }
    }
}
