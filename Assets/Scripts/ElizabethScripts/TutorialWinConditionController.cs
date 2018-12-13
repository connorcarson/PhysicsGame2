using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWinConditionController : MonoBehaviour {
	
	public GameObject WinText;
	private AudioSource WinSoundPlayer;
	private AudioClip WinSound;
	public GameObject button;

	// Use this for initialization
	void Start () {
		WinSoundPlayer = GetComponent<AudioSource>();
		WinSound = (AudioClip)Resources.Load("level clear sound");
		button.SetActive(false);
		WinText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter(Collider other)
	{
		WinText.SetActive(true);
		WinSoundPlayer.clip = WinSound;
		WinSoundPlayer.Play();
		button.SetActive(true);


	}
}
