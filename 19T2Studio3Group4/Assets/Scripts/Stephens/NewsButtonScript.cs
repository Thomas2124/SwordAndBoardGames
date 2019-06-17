using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsButtonScript : MonoBehaviour
{
	public GameObject shooop;
	public GameObject shopOptionOne;
	public GameObject shopOption;
	
	public void OpenShopAdd()
	{	
		shooop.SetActive (true);
		shopOptionOne.SetActive (true);
		shopOption.SetActive (true);
	}
}
