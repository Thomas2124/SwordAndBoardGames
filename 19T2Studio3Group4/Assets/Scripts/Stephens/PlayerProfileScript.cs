using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileScript : MonoBehaviour
{
    // Start is called before the first frame update
	public Sprite profileImage;
	public GameObject displayImage;
	public GameObject selectedImage;
	public GameObject theButton;
	public Text characterInfo;
	public string characterString;

    // Update is called once per frame
	public void SetProfilePicture()
	{
		displayImage.GetComponent<Image>().sprite = profileImage;
		selectedImage.transform.position = theButton.transform.position;
		characterInfo.text = characterString;
	
	}
}
