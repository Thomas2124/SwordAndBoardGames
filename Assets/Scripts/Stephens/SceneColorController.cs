using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneColorController : MonoBehaviour
{
    public Vector3 colorOne;
    public Vector3 colorTwo;
    public Vector3 colorThree;
    public GameObject screenObjects1;
    public GameObject[] sceneObjects1;
    public string objectTag;
	public static bool screenObjectIsVisable;
    public GameObject[] sceneObjects2;
    public GameObject colorReference2;
    public GameObject[] sceneObjects3;
    public GameObject colorReference3;
    public string objectTagTwo;
    public string objectTagThree;
    void Start()
    {
        sceneObjects1 = GameObject.FindGameObjectsWithTag(objectTag);
        sceneObjects2 = GameObject.FindGameObjectsWithTag(objectTagTwo);
        sceneObjects3 = GameObject.FindGameObjectsWithTag(objectTagThree);
    }
    void FixedUpdate()
    {
		sceneObjects1 = GameObject.FindGameObjectsWithTag(objectTag);
        sceneObjects2 = GameObject.FindGameObjectsWithTag(objectTagTwo);
        sceneObjects3 = GameObject.FindGameObjectsWithTag(objectTagThree);

        if (PlayerPrefsX.GetVector3("colorOne") != null)
        {
            colorOne = PlayerPrefsX.GetVector3("colorOne");
        }

        if (PlayerPrefsX.GetVector3("colorTwo") != null)
        {
            colorTwo = PlayerPrefsX.GetVector3("colorTwo");
        }

        if (PlayerPrefsX.GetVector3("colorThree") != null)
        {
            colorThree = PlayerPrefsX.GetVector3("colorThree");
        }

        foreach (GameObject item in sceneObjects1)
        {
            item.GetComponent<Image>().color = new Color(colorOne.x, colorOne.y, colorOne.z, 1.0f);
        }

		foreach (GameObject item2 in sceneObjects2)
        {
            item2.GetComponent<Image>().color = new Color(colorTwo.x, colorTwo.y, colorTwo.z, 1.0f);
        }

        foreach (GameObject item3 in sceneObjects3)
        {
            item3.GetComponent<Image>().color = new Color(colorThree.x, colorThree.y, colorThree.z, 1.0f);
        }
    }

//   public void White()
//	{
//		colorReference.GetComponent<Image>().color = new Color(0, 0, 0);
//	}
//	public void Black()
//	{
//		colorReference.GetComponent<Image>().color = new Color(255, 255, 255);
//	}
//	public void Red()
//	{
//		colorReference.GetComponent<Image>().color = new Color(255, 0, 0);
//	}
//	public void Blue()
//	{
//		colorReference.GetComponent<Image>().color = new Color(0, 0, 255);
//	}
//	public void Green()
//	{
//		colorReference.GetComponent<Image>().color = new Color(0, 255, 0);
//	}
//	public void Purple()
//	{
//		colorReference.GetComponent<Image>().color = new Color(255, 0, 255);
//	}
//	public void Yellow()
//	{
//		colorReference.GetComponent<Image>().color = new Color(0, 255, 255);
//	}
//	public void Orange()
//	{
//		colorReference.GetComponent<Image>().color = new Color(255, 255, 0);
//	}
	
}


	

