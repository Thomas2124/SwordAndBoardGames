using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FCPScriptReference : MonoBehaviour
{
	public FlexibleColorPicker fCPOne;
	public GameObject laReference;
	public FlexibleColorPicker fCPTwo;
	public GameObject laReference2;
	public FlexibleColorPicker fCPThree;
	public GameObject laReference3;

    // Update is called once per frame
    void Update()
    {
        if (laReference.activeInHierarchy == true)
        {
            laReference.GetComponent<Image>().color = fCPOne.color;
        }

        if (laReference2.activeInHierarchy == true)
        {
            laReference2.GetComponent<Image>().color = fCPTwo.color;
        }

        if (laReference3.activeInHierarchy == true)
        {
            laReference3.GetComponent<Image>().color = fCPThree.color;
        }
    }
}
