<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
=======
﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
>>>>>>> ffc42cc482bce18126dc3c42933678c01c287950

//public class SceneColorController : MonoBehaviour
//{
//	public GameObject colorReference;
//	public GameObject screenObject;
//	public static bool screenObjectIsVisable;
	
<<<<<<< HEAD
	public void White()
	{
		colorReference.GetComponent<Image>().color = new Color(0, 0, 0);
	}
	public void Black()
	{
		colorReference.GetComponent<Image>().color = new Color(255, 255, 255);
	}
	public void Red()
	{
		colorReference.GetComponent<Image>().color = new Color(255, 0, 0);
	}
	public void Blue()
	{
		colorReference.GetComponent<Image>().color = new Color(0, 0, 255);
	}
	public void Green()
	{
		colorReference.GetComponent<Image>().color = new Color(0, 255, 0);
	}
	public void Purple()
	{
		colorReference.GetComponent<Image>().color = new Color(255, 0, 255);
	}
	public void Yellow()
	{
		colorReference.GetComponent<Image>().color = new Color(0, 255, 255);
	}
	public void Orange()
	{
		colorReference.GetComponent<Image>().color = new Color(255, 255, 0);
	}
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
=======
//	public void White()
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
//	public void ScreenSwitch(){
//		if (menuIsVisable)
//		{
//			CloseScreen();
//		}
//		else
//		{
//			ScreenVisable();
//		}
//	}
>>>>>>> ffc42cc482bce18126dc3c42933678c01c287950
	
//	void CloseScreen(){
//		screenObject.SetActive (false);
//		screenObjectIsVisable = false;
//	}
	
//	void ScreenVisable(){
//		screenObject.SetActive (true);
//		screenObjectIsVisable = true;
//	}		
//}
