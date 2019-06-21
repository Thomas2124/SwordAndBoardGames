using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveRewardbuttonScript : MonoBehaviour
{
	public static bool recieveRewardIsAvaliable = false;
	
	public GameObject recieveReward;
	public GameObject recieveRewardTwo;
    // Start is called before the first frame update
	public void ButtonPower()
	{
		if(recieveReward.transform.childCount > 0)
		{
			Transform childObject = recieveReward.transform.GetChild(0);
			recieveRewardIsAvaliable = true;	
			if(recieveRewardIsAvaliable = true)
			{
				childObject.transform.SetParent(recieveRewardTwo.transform);
				//this.transform.SetParent(gridFieldTwo.transform);
				recieveRewardIsAvaliable = false;
			}
			if(recieveReward.transform.childCount <= 0)
		{
			recieveRewardIsAvaliable = false;
		}
		}
	}
}
