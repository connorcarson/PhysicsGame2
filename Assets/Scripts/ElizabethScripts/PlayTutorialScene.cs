﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTutorialScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void PlayTutorialPlz()
	{
		SceneManager.LoadScene("Tutorial");
	}
}
