using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour {

	// Use this for initialization
	void LoadScene()
	{
		SceneManager.LoadScene(1);
	}
}
