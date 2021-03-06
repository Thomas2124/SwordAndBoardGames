﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuController2 : MonoBehaviour
{
	//For use in codding buttons to create popups on the scene view
	public GameObject optionOne;
	public GameObject optionTwo;
	public GameObject optionThree;
	public GameObject optionFour;
	
	public GameObject dropChanceOne;
	public GameObject dropChanceTwo;
	public GameObject dropChanceThree;
	public GameObject dropChanceFour;

	public static bool dropChanceOneIsVisable;
	public static bool dropChanceTwoIsVisable;
	public static bool dropChanceThreeIsVisable;
	public static bool dropChanceFourIsVisable;

	public static bool buyCurrencyIsVisable;
	public GameObject buyCurrency;
	public static bool buyCurrencyWindowIsVisable;
	public GameObject buyCurrencyWindow;


	public void OptionOne()
	{
		optionOne.SetActive (true);
		optionTwo.SetActive (false);
		optionThree.SetActive (false);		
		optionFour.SetActive (false);
	}
	public void OptionTwo()
	{
		optionOne.SetActive (true);
		optionTwo.SetActive (true);
		optionThree.SetActive (false);		
		optionFour.SetActive (false);

	}
	public void OptionThree()
	{
		optionOne.SetActive (true);
		optionThree.SetActive (true);		
		optionFour.SetActive (false);
	}
	public void OptionFour()
	{
		optionOne.SetActive (true);
		optionFour.SetActive (true);
	}

	public void CloseShopPopup()
	{
		optionOne.SetActive (false);
		optionTwo.SetActive (false);
		optionThree.SetActive (false);
		optionFour.SetActive (false);
		dropChanceFour.SetActive (false);
		dropChanceFourIsVisable = false;
		dropChanceOne.SetActive (false);
		dropChanceOneIsVisable = false;
		dropChanceTwo.SetActive (false);
		dropChanceTwoIsVisable = false;
		dropChanceThree.SetActive (false);
		dropChanceThreeIsVisable = false;

	}
	
		public void DropChanceOne()
	{
		if(dropChanceOneIsVisable)
		{
			DropChanceOneClose();
		}
		else
		{
			DropChanceOneVisable();
		}
	}
	
	//Set object to inactive or active
	void DropChanceOneClose(){
		dropChanceOne.SetActive (false);
		dropChanceOneIsVisable = false;
	}
	void DropChanceOneVisable(){
		dropChanceOne.SetActive (true);
		dropChanceOneIsVisable = true;
	}
	
	public void DropChanceTwo()
	{
		if(dropChanceTwoIsVisable)
		{
			DropChanceTwoClose();
		}
		else
		{
			DropChanceTwoVisable();
		}
	}
	
	//Set object to inactive or active
	void DropChanceTwoClose(){
		dropChanceTwo.SetActive (false);
		dropChanceTwoIsVisable = false;
	}
	void DropChanceTwoVisable(){
		dropChanceTwo.SetActive (true);
		dropChanceTwoIsVisable = true;
	}
	
	public void DropChanceThree()
	{
		if(dropChanceThreeIsVisable)
		{
			DropChanceThreeClose();
		}
		else
		{
			DropChanceThreeVisable();
		}
	}
	
	//Set object to inactive or active
	void DropChanceThreeClose(){
		dropChanceThree.SetActive (false);
		dropChanceThreeIsVisable = false;
	}
	void DropChanceThreeVisable(){
		dropChanceThree.SetActive (true);
		dropChanceThreeIsVisable = true;
	}
	
	public void DropChanceFour()
	{
		if(dropChanceFourIsVisable)
		{
			DropChanceFourClose();
		}
		else
		{
			DropChanceFourVisable();
		}
	}
	
	//Set object to inactive or active
	void DropChanceFourClose(){
		dropChanceFour.SetActive (false);
		dropChanceFourIsVisable = false;
	}
	void DropChanceFourVisable(){
		dropChanceFour.SetActive (true);
		dropChanceFourIsVisable = true;
	}
	public void BuyCurrency()
	{
		if(buyCurrencyIsVisable)
		{
			BuyCurrencyClose();
		}
		else
		{
			BuyCurrencyVisable();
		}
	}
	
	//Set object to inactive or active
	void BuyCurrencyClose(){
		buyCurrency.SetActive (false);
		buyCurrencyIsVisable = false;
	}
	void BuyCurrencyVisable(){
		buyCurrency.SetActive (true);
		buyCurrencyIsVisable = true;
	}
	public void BuyCurrencyWindow()
	{
		if(buyCurrencyWindowIsVisable)
		{
			BuyCurrencyWindowClose();
		}
		else
		{
			BuyCurrencyWindowVisable();
		}
	}
	
	//Set object to inactive or active
	void BuyCurrencyWindowClose(){
		buyCurrencyWindow.SetActive (false);
		buyCurrencyWindowIsVisable = false;
	}
	void BuyCurrencyWindowVisable(){
		buyCurrencyWindow.SetActive (true);
		buyCurrencyWindowIsVisable = true;
	}
}
