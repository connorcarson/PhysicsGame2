using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
	public Color clearwhite = new Color(1, 1, 1, 0);
	public LevelController levelController;
	public BabyWombatMaker babyWombatMaker;

	// Use this for initialization
	void Start()
	{
		TextMesh1.color = clearwhite;
		TextMesh2.color = clearwhite;
		TextMesh3.color = clearwhite;
		TextMesh4.color = clearwhite;
		TextMesh5.color = clearwhite;

		PlayWhiteText();
	}

	void PlayWhiteText()
	{
		levelController.MakeWombat();
		TextMesh1.DOColor(Color.white, 1f);
		TextMesh1.DOColor(clearwhite, 1f).SetDelay(4f);
		TextMesh2.DOColor(Color.white, 1f).SetDelay(4.5f);
		TextMesh2.DOColor(clearwhite, 1f).SetDelay(8.5f);
		TextMesh3.DOColor(Color.white, 1f).SetDelay(9f);
		TextMesh3.DOColor(clearwhite, 1f).SetDelay(12f);
		TextMesh4.DOColor(Color.white, 1f).SetDelay(12.5f);
		TextMesh4.DOColor(clearwhite, 1f).SetDelay(19f);
		TextMesh5.DOColor(Color.white, 1f).SetDelay(19.5f);
		Invoke("MakeBabyWombat", 20.5f);
	}

	private void MakeBabyWombat()
	{
		babyWombatMaker.MakeBabyWombat();
	}

// Update is called once per frame
	void Update () {
		
	}
}
