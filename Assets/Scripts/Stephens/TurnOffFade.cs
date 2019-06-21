using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffFade : MonoBehaviour
{
	public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        //Time.deltaTime(5);
		StartCoroutine(Example());
		
    }
	IEnumerator Example()
	{
		yield return new WaitForSeconds(5);
		fade.SetActive (false);
	}
}
