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
	//public TextMeshProUGUI TextMesh4;
	public TextMeshProUGUI TextMesh5;
	public TextMeshProUGUI TextMesh6;
	public TextMeshProUGUI TextMesh7;
	public TextMeshProUGUI TextMesh8;
	public TextMeshProUGUI TextMesh9;
	public TextMeshProUGUI TextMesh10;
	public TextMeshProUGUI TextMesh11;
	public TextMeshProUGUI TextMesh12;
	public TextMeshProUGUI TextMesh13;
	
	public Color clearwhite = new Color(1, 1, 1, 0);
	
	public LevelController levelController;
	public BabyWombatMaker babyWombatMaker;
	public BabyWombatController babyWombatController;
	private WombatController wombatController;

	private GameObject babyWombat;
	
	public Rigidbody wombatRigidbody;
	public Rigidbody babyWombatRigidbody;
	
	private bool hasMoved = false;
	private bool hasRotated = false;
	private bool dropPoopCommand = false;
	private bool droppedPoop = false;
	private bool showingJackTutorial = true;
	private bool showingCheerioTutorial = false;
	private bool introducingCheerio = false;
	private bool babyWombatMoving = false;
	private bool babyReset = false;
	private bool cheerioReset = false;
	
	// Use this for initialization
	void Start()
	{	
		GameObject newWombat = levelController.MakeWombat();
		wombatRigidbody = newWombat.GetComponent<Rigidbody>();
		wombatController = newWombat.GetComponent<WombatController>();

		TextMesh1.color = clearwhite;
		TextMesh2.color = clearwhite;
		TextMesh3.color = clearwhite;
		//TextMesh4.color = clearwhite;
		TextMesh5.color = clearwhite;
		TextMesh6.color = clearwhite;
		TextMesh7.color = clearwhite;
		TextMesh8.color = clearwhite;
		TextMesh9.color = clearwhite;
		TextMesh10.color = clearwhite;
		TextMesh11.color = clearwhite;
		TextMesh12.color = clearwhite;
		TextMesh13.color = clearwhite;
		
		TextMesh1.DOColor(Color.white, 1f);
	}

	void PlayJackTutorial()
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

		if (hasRotated && Input.GetMouseButtonUp(0) && droppedPoop == false)
		{
			TextMesh3.DOColor(clearwhite, 1f);
			TextMesh5.DOColor(Color.white, 1f).SetDelay(1f);
			droppedPoop = true;
		}

		if (droppedPoop && levelController.NumberOfPoopsMade() == 0)
		{
			
			TextMesh5.DOColor(clearwhite, 1f);
			TextMesh6.DOColor(Color.white, 1f).SetDelay(1f);
			TextMesh6.DOColor(clearwhite, 1f).SetDelay(3f);
			Invoke("MakeBabyWombat", 3.5f);
			showingJackTutorial = false;
		}
	}

	void PlayCheerioTutorial()
	{
		if (introducingCheerio == false)
		{
			TextMesh7.DOColor(Color.white, 1f).SetDelay(0.5f);
			TextMesh7.DOColor(clearwhite, 1f).SetDelay(2.5f);
			TextMesh8.DOColor(Color.white, 1f).SetDelay(3.5f);
			TextMesh9.DOColor(Color.white, 1f).SetDelay(5.5f);
			TextMesh10.DOColor(Color.white, 1f).SetDelay(6.5f);
			introducingCheerio = true;
		}

		if (babyWombatMoving == false && babyWombatRigidbody.velocity != Vector3.zero)
		{
			TextMesh8.DOColor(clearwhite, 1f);
			TextMesh9.DOColor(clearwhite, 1f);
			TextMesh10.DOColor(clearwhite, 1f);
			TextMesh11.DOColor(Color.white, 1f).SetDelay(1f);
			TextMesh11.DOColor(clearwhite, 1f).SetDelay(3f);
			TextMesh12.DOColor(Color.white, 1f).SetDelay(4f);
			StartCoroutine(resetCheerio());
			TextMesh12.DOColor(clearwhite, 1f).SetDelay(7f);
			TextMesh13.DOColor(Color.white, 1f).SetDelay(8f);
			TextMesh13.DOColor(clearwhite, 1f).SetDelay(14f);
			babyWombatMoving = true;
			{
				
			}
		}
	}

	private IEnumerator resetCheerio()
	{
		yield return new WaitForSeconds(6.5f);
		GameObject currentBaby = GameObject.Find("BabyWombat(Clone)");
		Destroy(currentBaby);
	}
	
	private void MakeBabyWombat()
	{
		babyWombatMaker.MakeBabyWombat();
		babyWombat = babyWombatMaker.GetBaby();
		babyWombatRigidbody = babyWombat.GetComponent<Rigidbody>();
		showingCheerioTutorial = true;
	}
	
// Update is called once per frame
	void Update () {
		if (showingJackTutorial)
			PlayJackTutorial();
		
		if(showingCheerioTutorial)
			PlayCheerioTutorial();
	}
}
