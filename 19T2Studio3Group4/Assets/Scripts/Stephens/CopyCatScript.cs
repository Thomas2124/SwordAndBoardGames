using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyCatScript : MonoBehaviour
{
	//public Sprite copyCatS;
	public GameObject copyCatO;

	//public Sprite copiedSprite;
	public GameObject copiedObject;
    // Update is called once per frame
    void Update()
    {
        copyCatO.GetComponent<Image>().sprite = copiedObject.GetComponent<Image>().sprite;
    }
}
