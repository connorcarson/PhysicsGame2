using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayPoopPartyScript : MonoBehaviour
{
	private GameObject themeMusic;
	
	// Use this for initialization
	void Start () {
		themeMusic = GameObject.FindWithTag("themeMusic");
	}

	public void PlayPoopParty()
	{
		Destroy(themeMusic);
		SceneManager.LoadScene("Poop Party");
	}
}
