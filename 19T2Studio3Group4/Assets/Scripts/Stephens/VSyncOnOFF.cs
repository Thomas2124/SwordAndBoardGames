using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSyncOnOFF : MonoBehaviour
{
	public static bool vSyncison = false;
	//public GameObject vSyncButton;

	
	//void Update()
	//{
	//	PlayerPrefs.SetFloat()
	//}
	
	
	public void VsyncOnOFF()
	{
		if(vSyncison)
		{
			VSyncOff();
		}
		else
		{
			VSyncOn();
		}
	}
	
	//Set object to inactive or active
	void VSyncOff(){
		QualitySettings.vSyncCount = 0;
		vSyncison = false;
		//vSyncButton.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
		print("VSyncOff");
	}
	void VSyncOn(){
		QualitySettings.vSyncCount = 1;
		vSyncison = true;
		//vSyncButton.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
		print("VSyncOn");
	}
	

}
