using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PoopDisplayManager : MonoBehaviour
{
	public TextMeshProUGUI poopText;
	public LevelController currentLevelController;

	void Start()
	{
		poopText = gameObject.GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (LevelController.currentWombat != null)
			poopText.text = "" + currentLevelController.NumberOfPoopsRemaining();
	}
}
