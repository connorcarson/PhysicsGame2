using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TutorialController : MonoBehaviour
{
	public TextMeshProUGUI TextMesh1;
	public TextMeshProUGUI TextMesh2;
	public TextMeshProUGUI TextMesh3;
	public TextMeshProUGUI TextMesh4;
	public TextMeshProUGUI TextMesh5;
	public TextMeshProUGUI TextMesh6;
	
	public Color clearwhite = new Color(1, 1, 1, 0);
	
	public LevelController levelController;
	public BabyWombatMaker babyWombatMaker;
	private WombatController wombatController;
	
	public Rigidbody wombatRigidbody;
	
	private bool hasMoved = false;
	private bool hasRotated = false;
	private bool dropPoopCommand = false;
	private bool droppedPoop = false;
	private bool showingtutorial = true;
	
	// Use this for initialization
	void Start()
	{	
		GameObject newWombat = levelController.MakeWombat();
		wombatRigidbody = newWombat.GetComponent<Rigidbody>();
		wombatController = newWombat.GetComponent<WombatController>();

		TextMesh1.color = clearwhite;
		TextMesh2.color = clearwhite;
		TextMesh3.color = clearwhite;
		TextMesh4.color = clearwhite;
		TextMesh5.color = clearwhite;
		TextMesh6.color = clearwhite;
		
		TextMesh1.DOColor(Color.white, 1f);
	}

	void PlayWhiteText()
	{
		//Debug.Log("wombat's velocity: " + wombatRigidbody.velocity);
		if (hasMoved == false && wombatRigidbody.velocity != Vector3.zero)
		{
				TextMesh1.DOColor(clearwhite, 1f);
				TextMesh2.DOColor(Color.white, 1f).SetDelay(1f);
				hasMoved = true;
		}

		if (hasMoved && wombatController.isPooping && hasRotated == false)
		{
				TextMesh2.DOColor(clearwhite, 1f);
				TextMesh3.DOColor(Color.white, 1f).SetDelay(1f);
				hasRotated = true;
		}

		if (hasRotated && dropPoopCommand == false)
		{
			TextMesh3.DOColor(clearwhite, 1f).SetDelay(4f);
			TextMesh4.DOColor(Color.white, 1f).SetDelay(5f);
			dropPoopCommand = true;
		}

		if (dropPoopCommand && Input.GetMouseButtonUp(0) && droppedPoop == false)
		{
			TextMesh4.DOColor(clearwhite, 1f);
			TextMesh5.DOColor(Color.white, 1f).SetDelay(1f);
			droppedPoop = true;
		}

		if (droppedPoop && levelController.NumberOfPoopsMade() == 0)
		{
			
			TextMesh5.DOColor(clearwhite, 1f).SetDelay(4f);
			TextMesh6.DOColor(Color.white, 1f).SetDelay(5f);
			TextMesh6.DOColor(clearwhite, 1f).SetDelay(9f);
			Invoke("MakeBabyWombat", 8f);
			showingtutorial = false;
		}
	}

	private void MakeBabyWombat()
	{
		babyWombatMaker.MakeBabyWombat();
	}

// Update is called once per frame
	void Update () {
		if (showingtutorial)
			PlayWhiteText();
	}
}
