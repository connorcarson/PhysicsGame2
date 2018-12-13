using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	private bool MenuIsActive;
	public GameObject RestartLevel;
	public GameObject PoopParty;
	public GameObject Tutorial;
	public GameObject Quit;
	

	// Use this for initialization
	void Start () {
		RestartLevel.SetActive(false);
		PoopParty.SetActive(false);
		Tutorial.SetActive(false);
		Quit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			
			
			
		}

		
	}

	public void ShowMenu()
	{
		if (MenuIsActive)
		{
			MenuIsActive = false;
			RestartLevel.SetActive(false);
			PoopParty.SetActive(false);
			Tutorial.SetActive(false);
			Quit.SetActive(false);
		}
		else if (!MenuIsActive)
		{
			MenuIsActive = true;
			RestartLevel.SetActive(true);
			PoopParty.SetActive(true);
			Tutorial.SetActive(true);
			Quit.SetActive(true);
		}
	}
	
}
