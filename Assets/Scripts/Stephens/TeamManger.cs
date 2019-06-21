using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManger : MonoBehaviour
{
	public GameObject teamOne;
	public GameObject teamTwo;
	public GameObject teamThree;
	
	public void TeamOne()
	{
		teamOne.SetActive (true);
		teamTwo.SetActive (false);
		teamThree.SetActive (false);
	}
		public void TeamTwo()
	{
		teamTwo.SetActive (true);
		teamOne.SetActive (false);
		teamThree.SetActive (false);
	}
		public void TeamThree()
	{
		teamThree.SetActive (true);
		teamTwo.SetActive (false);
		teamOne.SetActive (false);
	}
}
