using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPageController : MonoBehaviour
{
	
	public GameObject generalHelp;
	public GameObject battleHelp;
	public GameObject upgradeHelp;
	public GameObject rankHelp;
	public GameObject eventHelp;

	public void GeneralHelp()
	{
		generalHelp.SetActive (true); //set to false while unused
		battleHelp.SetActive (false);
		upgradeHelp.SetActive (false);
		rankHelp.SetActive (false);
	}
	public void BattleHelp()
	{
		battleHelp.SetActive (true); //set to false while unused
		generalHelp.SetActive (false);
		upgradeHelp.SetActive (false);
		rankHelp.SetActive (false);
	}
	public void UpgradeHelp()
	{
		upgradeHelp.SetActive (true); //set to false while unused
		battleHelp.SetActive (false);
		generalHelp.SetActive (false);
		rankHelp.SetActive (false);
	}
	public void RankHelp()
	{
		rankHelp.SetActive (true); //set to false while unused
		battleHelp.SetActive (false);
		upgradeHelp.SetActive (false);
		generalHelp.SetActive (false);
	}
}