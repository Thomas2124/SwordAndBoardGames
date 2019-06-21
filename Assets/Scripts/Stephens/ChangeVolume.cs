using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
	public Slider musicPower;
	public AudioSource musicPlayer;

	public Slider soundPower;
	public AudioSource soundPlayer;

    // Update is called once per frame
    void Update()
    {
        musicPlayer.volume = musicPower.value;
		soundPlayer.volume = soundPower.value;
    }
}
