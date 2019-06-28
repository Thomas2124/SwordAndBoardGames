using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMenuController : MonoBehaviour
{
	//public GameObject[] displayedGameObjecct;
	public GameObject shopDisplay0;
	public GameObject shopDisplay1;
	public GameObject shopDisplay2;
	public GameObject shopDisplay3;

	public Slider shopDisplaysScroll;

	//public float[] sliderValue ;
	//public float displayOne;
	//public float displayTwo;
	public float displayThree;
	//public float displayZero;
	
	void Update()
	{
		ShopDisplay();
		
	}
	
	//Activate 1 of 4 options while ensuring all other options are turned off.
	public void ShopDisplay()
	{
		if(shopDisplaysScroll.value < 1.50 && shopDisplaysScroll.value >= 0.5) 
		{
			shopDisplay0.SetActive (true);
			shopDisplay1.SetActive (false);
			shopDisplay2.SetActive (false);
			shopDisplay3.SetActive (false);
		}
		if(shopDisplaysScroll.value > 1.50 && shopDisplaysScroll.value < 2.50)
		{
			shopDisplay1.SetActive (true);
			shopDisplay0.SetActive (false);
			shopDisplay2.SetActive (false);
			shopDisplay3.SetActive (false);
		}
		if(shopDisplaysScroll.value > 2.50 && shopDisplaysScroll.value <= 3.50)
		{
			shopDisplay2.SetActive (true);
			shopDisplay0.SetActive (false);
			shopDisplay1.SetActive (false);
			shopDisplay3.SetActive (false);
		}
		if(shopDisplaysScroll.value == displayThree)
		{
			shopDisplay3.SetActive (true);
			shopDisplay0.SetActive (false);
			shopDisplay2.SetActive (false);
			shopDisplay1.SetActive (false);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//print(shopDisplaysScroll.value);
			if(shopDisplaysScroll.value < 1.50 && shopDisplaysScroll.value >= 0.5)
			{
				//Debug.Log("here");
				shopDisplaysScroll.value = 1;
			}
			if(shopDisplaysScroll.value > 1.50 && shopDisplaysScroll.value < 2.50)
			{
				shopDisplaysScroll.value = 2;
			}
			if(shopDisplaysScroll.value > 2.50 && shopDisplaysScroll.value <= 3.50)
			{
				shopDisplaysScroll.value = 3;
			}
		} 
	}
	

}
