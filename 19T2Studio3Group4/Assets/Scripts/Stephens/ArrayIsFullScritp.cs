using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayIsFullScritp : MonoBehaviour
{
	public static bool gridOneIsFull = false;
	public static bool gridTwoIsFull = false;
	public static bool gridThreeIsFull = false;
	public static bool gridFourIsFull = false;
	public static bool gridFiveIsFull = false;
	public static bool gridUpgradeIsFull = false;		
	
	//public GameObject[] upgradeGrid;
	public GameObject gridFieldOne;
	public GameObject gridFieldTwo;
	public GameObject gridFieldThree;
	public GameObject gridFieldFour;
	public GameObject gridFieldFive;
	public GameObject gridFieldReward;
	public GameObject gridFieldUpgrade;
	
	public GameObject[] childrenHunter;
    // Update is called once per frame
    void Update()
    {
		//GameObject go = GameObject.Find("CharacterSelectp1.image");
        if(gridFieldOne.transform.childCount <= 10)
		{
			gridOneIsFull = false;
		}
		if(gridFieldOne.transform.childCount > 10)
		{
			Transform childObject = gridFieldOne.transform.GetChild(10);
			gridOneIsFull = true;	
			if(gridOneIsFull = true)
			{
				childObject.transform.SetParent(gridFieldTwo.transform);
				//this.transform.SetParent(gridFieldTwo.transform);
				gridOneIsFull = false;
			}
		}
		    if(gridFieldOne.transform.childCount <= 10)
		{
			gridOneIsFull = false;
		}
		
		if(gridFieldTwo.transform.childCount > 10)
		{
			Transform childObject = gridFieldTwo.transform.GetChild(10);
			gridTwoIsFull = true;	
			if(gridTwoIsFull = true)
			{
				childObject.transform.SetParent(gridFieldThree.transform);
				//this.transform.SetParent(gridFieldTwo.transform);
				gridTwoIsFull = false;
			}
		}
		    if(gridFieldTwo.transform.childCount <= 10)
		{
			gridTwoIsFull = false;
		}
		
		if(gridFieldThree.transform.childCount > 10)
		{
			Transform childObject = gridFieldThree.transform.GetChild(10);
			gridThreeIsFull = true;	
			if(gridThreeIsFull = true)
			{
				childObject.transform.SetParent(gridFieldFour.transform);
				//this.transform.SetParent(gridFieldTwo.transform);
				gridThreeIsFull = false;
			}
		}
		    if(gridFieldThree.transform.childCount <= 10)
		{
			gridThreeIsFull = false;
		}
		
		if(gridFieldFour.transform.childCount > 10)
		{
			Transform childObject = gridFieldFour.transform.GetChild(10);
			gridFourIsFull = true;	
			if(gridFourIsFull = true)
			{
				childObject.transform.SetParent(gridFieldFive.transform);
				//this.transform.SetParent(gridFieldTwo.transform);
				gridFourIsFull = false;
			}
		}
		    if(gridFieldFour.transform.childCount <= 10)
		{
			gridFourIsFull = false;
		}
		
		if(gridFieldFive.transform.childCount > 10)
		{
			Transform childObject = gridFieldFive.transform.GetChild(10);
			gridFiveIsFull = true;	
			if(gridFiveIsFull = true)
			{
				childObject.transform.SetParent(gridFieldReward.transform);
				//this.transform.SetParent(gridFieldTwo.transform);
				gridFiveIsFull = false;
			}
			if(gridFieldFive.transform.childCount <= 10)
		{
			gridFiveIsFull = false;
		}
		
		}
		if(gridFieldUpgrade.transform.childCount > 1)
		{
			Transform childObject = gridFieldUpgrade.transform.GetChild(1);
			gridUpgradeIsFull = true;	
			if(gridUpgradeIsFull = true)
			{
				childObject.transform.SetParent(gridFieldOne.transform);
				//this.transform.SetParent(gridFieldTwo.transform);
				gridUpgradeIsFull = false;
			}
			if(gridFieldUpgrade.transform.childCount <= 1)
		{
			gridUpgradeIsFull = false;
		}
		}
    }
}
