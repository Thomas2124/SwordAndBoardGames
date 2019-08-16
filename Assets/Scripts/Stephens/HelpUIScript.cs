using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUIScript : MonoBehaviour
{

	public GameObject stageOne;
	public GameObject stageTwo;
	public GameObject stageThree;
	public GameObject stageFour;
	public GameObject stageFive;
	
	
	public void TutorialSTART()
	{
		stageOne.SetActive (true);
	}
	public void TutorialTwo()
	{
		stageOne.SetActive (false);
		stageTwo.SetActive (true);
	}
	public void TutorialThree()
	{
		stageTwo.SetActive (false);
		stageThree.SetActive (true);
	}
	public void TutorialFour()
	{
		stageThree.SetActive (false);
		stageFour.SetActive (true);
	}
	public void TutorialFive()
	{
		stageFour.SetActive (false);
		stageFive.SetActive (true);
	}
	public void EndTutorial()
	{
		stageOne.SetActive (false);
		stageTwo.SetActive (false);
		stageThree.SetActive (false);
		stageFour.SetActive (false);
		stageFive.SetActive (false);
	}

}
