using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneColorController : MonoBehaviour
{
    public Vector3 colorOne;
    public Vector3 colorTwo;
    public Vector3 colorThree;
    public GameObject screenObject;
    public GameObject[] sceneObjects;
    public string objectTag;
	public static bool screenObjectIsVisable;
    public GameObject[] sceneObjects2;
    public GameObject colorReference2;
    public GameObject[] sceneObjects3;
    public GameObject colorReference3;
    public string objectTag2;
    public string objectTag3;
    void Awake()
    {
        sceneObjects = GameObject.FindGameObjectsWithTag(objectTag);
        sceneObjects = GameObject.FindGameObjectsWithTag(objectTag2);
        sceneObjects = GameObject.FindGameObjectsWithTag(objectTag3);
    }
    void FixedUpdate()
    {
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

        foreach (GameObject item in sceneObjects)
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

	public void ScreenSwitch(){
		if (screenObjectIsVisable)
		{
			CloseScreen();
		}
		else
		{
			ScreenVisable();
		}
	}
	void CloseScreen(){
		screenObject.SetActive (false);
		screenObjectIsVisable = false;
	}
	
	void ScreenVisable(){
		screenObject.SetActive (true);
		screenObjectIsVisable = true;
	}		
}


	

