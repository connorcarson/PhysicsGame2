using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionController : MonoBehaviour
{
	public GameObject Flames;
	public GameObject WinText;
	private AudioSource WinSoundPlayer;
	private AudioClip WinSound;

	// Use this for initialization
	void Start () {
		WinSoundPlayer = GetComponent<AudioSource>();
		WinSound = (AudioClip)Resources.Load("level clear sound");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter(Collider other)
	{
		Flames.SetActive(true);
		WinText.SetActive(true);
		WinSoundPlayer.clip = WinSound;
		WinSoundPlayer.Play();


	}
}
