using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
	
	public AudioClip buttonSound;
	private Button button {get { return GetComponent<Button>(); }}
	public AudioSource source;
	// Use this for initialization
	void Start () 
	{	
		//finding audio source and applying clip
		gameObject.AddComponent <AudioSource>();
		source.clip = buttonSound;
		source.playOnAwake = false;

		button.onClick.AddListener(() => PlaySound());
	}
	//play sound once
	void PlaySound()
	{
	
		source.PlayOneShot(buttonSound);	

	}
}
