﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheColorSaver : MonoBehaviour
{
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;

    public Vector3 colorOne;
    public Vector3 colorTwo;
    public Vector3 colorThree;

    // Update is called once per frame
    void Update()
    {
        colorOne = new Vector3(objectOne.GetComponent<Image>().color.r, objectOne.GetComponent<Image>().color.b, objectOne.GetComponent<Image>().color.g);
        colorTwo = new Vector3(objectTwo.GetComponent<Image>().color.r, objectTwo.GetComponent<Image>().color.b, objectTwo.GetComponent<Image>().color.g);
        colorThree = new Vector3(objectThree.GetComponent<Image>().color.r, objectThree.GetComponent<Image>().color.b, objectThree.GetComponent<Image>().color.g);

        if (colorOne != Vector3.one)
        {
            PlayerPrefsX.SetVector3("colorOne", colorOne);
        }

        if (colorTwo != Vector3.one)
        {
            PlayerPrefsX.SetVector3("colorTwo", colorTwo);
        }

        if (colorThree != Vector3.one)
        {
            PlayerPrefsX.SetVector3("colorThree", colorThree);
        }
    }
}
