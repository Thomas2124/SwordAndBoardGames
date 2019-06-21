using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInfoButtons : MonoBehaviour
{
 
	public Sprite characterCImage;
	public GameObject displayCImage;
	public GameObject selectedCImage;
	public GameObject theCButton;
	public Text characterCInfo;
	public Text characterStat;
	public string characterInfoString;
	public string characterStatString;

    // Update is called once per frame
	public void SetCharacterInfoPicture()
	{
		displayCImage.GetComponent<Image>().sprite = characterCImage;
		selectedCImage.transform.position = theCButton.transform.position;
		characterCInfo.text = characterInfoString;
		characterStat.text = characterStatString;	
	}
}
