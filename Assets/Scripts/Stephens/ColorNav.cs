using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorNav : MonoBehaviour
{
	public static bool panelOneIsOn;
	public static bool panelTwoIsOn;
	public static bool panelThreeIsOn;
	
	public GameObject panelOne;
	public GameObject panelTwo;
	public GameObject panelThree;	
	
	public void PanelTwoOpen()
	{
		if (panelTwoIsOn)
		{
			ClosepanelTwo();
		}
		else
		{
			PanelTwoVisable();
		}
	}
	
	void ClosepanelTwo(){
		panelTwo.SetActive (false);
		panelTwoIsOn = false;
	}
	
	void PanelTwoVisable(){
		panelTwo.SetActive (true);
		panelTwoIsOn = true;
	}




	public void PanelThreeOpen()
	{
		if (panelThreeIsOn)
		{
			ClosepanelThree();
		}
		else
		{
			PanelThreeVisable();
		}
	}
	
	void ClosepanelThree(){
		panelThree.SetActive (false);
		panelThreeIsOn = false;
	}
	
	void PanelThreeVisable(){
		panelThree.SetActive (true);
		panelThreeIsOn = true;
	}
	



	public void PanelOneOpen()
	{
		if (panelOneIsOn)
		{
			ClosepanelOne();
		}
		else
		{
			PanelOneVisable();
		}
	}
	
	void ClosepanelOne(){
		panelOne.SetActive (false);
		panelOneIsOn = false;
	}
	
	void PanelOneVisable(){
		panelOne.SetActive (true);
		panelOneIsOn = true;
	}

}
