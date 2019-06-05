using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	//UI object Arrays and scene strings
	//public static bool UIelementIsVisable = false;
	//public GameObject[] UIelements;
    // Start is called before the first frame update
	
	//Non array GUI setup
	public static bool tosIsVisable = false;
	public static bool titleMenuIsVisable = false;
	public static bool menuIsVisable = false;
	
	public GameObject titlescreen;
	public GameObject tos;
	public GameObject update;
	public GameObject background;
	public GameObject titleMenu;
	public GameObject shope;
	public GameObject battle;
	public GameObject upgrade;
	public GameObject team;
	public GameObject quest;
	public GameObject characterInfo;
	public GameObject ranking;
	public GameObject communication;
	public GameObject profile;
	public GameObject settings;
	public GameObject menu;
	
	//How Do I make the navigation script into an array of script
	
	//Key - for array if used
	//	0 = Titlescreen.panel
	//  1 = ToS.Panel
	//  2 = UpdateScreen.Panel
	//  3 = Background.Panel
	//  4 = TitleMenu.panel
	//  5 = ShopePanel
	//  6 = Battle.Panel
	//  7 = Upgrade.panel
	//  8 = Team.Panel
	//  9 = Quest.Panel
	//  10= CharacterInfo.panel
	//  11= Ranking.panel
	//  12= Communication.panel
	//  13= Profile.panel
	//  14= Settings.panel
	//  15= menu.panel
	//
	//
	//
	
	//public void StartGame()
	//{
	//	GameObject.setactive GameObject[0].UIelements = false;
	//	GameObject.setactive GameObject[1].UIelements = true;
	//}

	//open game Ui
	public void GameOpen(){
		update.SetActive (false); //set to false while unused
		titlescreen.SetActive (false);
		background.SetActive (true);
		titleMenuIsVisable = true;
	}
	//Open game ToS and set its state	
	public void ToSOpen(){
		if (tosIsVisable)		{
			CloseToS();
		}
		else
		{
			ToSVisable();
		}
	}
	
	void CloseToS(){
		tos.SetActive (false);
		tosIsVisable = false;
	}
	
	void ToSVisable(){
		tos.SetActive (true);
		tosIsVisable = true;
	}
	//Open game menu and set its state
	public void OpenMenu(){
		if (menuIsVisable)
		{
			CloseMenu();
		}
		else
		{
			MenuVisable();
		}
	}
	
	void CloseMenu(){
		menu.SetActive (false);
		menuIsVisable = false;
	}
	
	void MenuVisable(){
		menu.SetActive (true);
		menuIsVisable = true;
	}	
	
	//open UI elements
	public void ShopeOpen()
	{
		menu.SetActive (false);
		shope.SetActive (true);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void BattleOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (true);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void UpgradeOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (true);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void TeamOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (true);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void QuestOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (true);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void CommunicationOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (true);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void RankingOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (true);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void CharacterInfoOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (true);
		settings.SetActive (false);
		profile.SetActive (false);
	}

	public void SettingsOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (true);
		profile.SetActive (false);
	}

	public void ProfileOpen()
	{
		menu.SetActive (false);
		shope.SetActive (false);
		battle.SetActive (false);
		upgrade.SetActive (false);
		team.SetActive (false);
		quest.SetActive (false);
		communication.SetActive (false);
		ranking.SetActive (false);
		characterInfo.SetActive (false);
		settings.SetActive (false);
		profile.SetActive (true);
	}
	//These can be simplified using arrays
	
	public void Quit()
	{
		Application.Quit();
	}
		
}
