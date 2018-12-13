using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroAnimationBoss : MonoBehaviour
{
	public TextMeshProUGUI Line1;
	public TextMeshProUGUI Line2;
	public TextMeshProUGUI Line3;
	public TextMeshProUGUI Line4;
	public TextMeshProUGUI Line5;
	public TextMeshProUGUI Line6;
	public GameObject button;
	public Image WomPoop1;
	public Image JackWombat;
	public Image CheerioWombat;

	void Start () {
		Line1.color = Color.clear;
		Line2.color = Color.clear;
		Line3.color = Color.clear;
		Line4.color = Color.clear;
		Line5.color = Color.clear;
		Line6.color = Color.clear;
		WomPoop1.color = Color.clear;
		JackWombat.color = Color.clear;
		CheerioWombat.color = Color.clear;
		PlayIntroAnimation();
		button.SetActive(false);
	}

	void PlayIntroAnimation()
	{
		Line1.DOColor(Color.white, 1f);
		JackWombat.DOColor(Color.white, 1f).SetDelay(1f);
		Line2.DOColor(Color.white, 1f).SetDelay(3f);
		CheerioWombat.DOColor(Color.white, 1f).SetDelay(4f);
		Line3.DOColor(Color.white, 1f).SetDelay(6f);
		WomPoop1.DOColor(Color.white, 1f).SetDelay(7f);
		Line1.DOColor(Color.clear, 1f).SetDelay(9f);
		Line2.DOColor(Color.clear, 1f).SetDelay(9f);
		Line3.DOColor(Color.clear, 1f).SetDelay(9f);
		WomPoop1.DOColor(Color.clear, 1f).SetDelay(9f);
		JackWombat.DOColor(Color.clear, 1f).SetDelay(9f);
		CheerioWombat.DOColor(Color.clear, 1f).SetDelay(9f);
		Line4.DOColor(Color.white, 1f).SetDelay(10.5f);
		Line4.DOColor(Color.clear, 1f).SetDelay(13.5f);
		Line5.DOColor(Color.white, 1f).SetDelay(15f);
		Line5.DOColor(Color.clear, 1f).SetDelay(20f);
		Line6.DOColor(Color.white, 1f).SetDelay(21.5f);
		Invoke("SetButtonActive", 22f);
		

	}

	void SetButtonActive()
	{
		button.SetActive(true);
	}

}
