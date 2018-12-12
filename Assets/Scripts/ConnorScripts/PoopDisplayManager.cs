using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopDisplayManager : MonoBehaviour
{
	public Text poopText;
	public LevelController currentLevelController;

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (LevelController.currentWombat != null)
			poopText.text = "" + currentLevelController.NumberOfPoopsRemaining();
	}
}
