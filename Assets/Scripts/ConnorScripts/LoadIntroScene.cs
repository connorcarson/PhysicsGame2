using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntroScene : MonoBehaviour
{
	public GameObject music;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad(music);
	}
	
	public void LevelLoader()
	{
		SceneManager.LoadScene("Text Intro");
	}
}
