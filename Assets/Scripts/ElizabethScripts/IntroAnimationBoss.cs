using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

	void Start () {
		Line1.color = Color.clear;
		Line2.color = Color.clear;
		Line3.color = Color.clear;
		Line4.color = Color.clear;
		Line5.color = Color.clear;
		Line6.color = Color.clear;
		PlayIntroAnimation();
		button.SetActive(false);
		WomPoop1.enabled = true;
	}

	void PlayIntroAnimation()
	{
		Line1.DOColor(Color.white, 1f);
		Line2.DOColor(Color.white, 1f).SetDelay(3f);
		Line3.DOColor(Color.white, 1f).SetDelay(6f);
		Invoke("MakePoopToon", 6f);
		Line1.DOColor(Color.clear, 1f).SetDelay(9f);
		Line2.DOColor(Color.clear, 1f).SetDelay(9f);
		Line3.DOColor(Color.clear, 1f).SetDelay(9f);
		Line4.DOColor(Color.white, 1f).SetDelay(10.5f);
		Line4.DOColor(Color.clear, 1f).SetDelay(13.5f);
		Line5.DOColor(Color.white, 1f).SetDelay(15f);
		Line5.DOColor(Color.clear, 1f).SetDelay(19f);
		Line6.DOColor(Color.white, 1f).SetDelay(19.5f);
		Invoke("SetButtonActive", 19.5f);
		

	}

	void SetButtonActive()
	{
		button.SetActive(true);
	}

	void MakePoopToon()
	{
		WomPoop1.enabled = true;
	}

}
