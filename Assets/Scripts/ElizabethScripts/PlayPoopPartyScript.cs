using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayPoopPartyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void PlayPoopParty()
	{
		SceneManager.LoadScene("Poop Party");
	}
}
