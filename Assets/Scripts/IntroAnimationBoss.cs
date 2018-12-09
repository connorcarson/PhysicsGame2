using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroAnimationBoss : MonoBehaviour
{

	public Text Line1;
	public Text Line2;
	public Text Line3;
	public Text Line4;
	public Text Line5;

	void Start () {
		Line1.color = Color.clear;
		Line2.color = Color.clear;
		Line3.color = Color.clear;
		Line4.color = Color.clear;
		Line5.color = Color.clear;
		PlayIntroAnimation();
	}

	void PlayIntroAnimation()
	{
		Line1.DOColor(Color.white, 1f);
		Line2.DOColor(Color.white, 1f).SetDelay(3f);
		Line3.DOColor(Color.white, 1f).SetDelay(6f);
		Line1.DOColor(Color.clear, 1f).SetDelay(9f);
		Line2.DOColor(Color.clear, 1f).SetDelay(9f);
		Line3.DOColor(Color.clear, 1f).SetDelay(9f);
		Line4.DOColor(Color.white, 1f).SetDelay(10.5f);
		Line4.DOColor(Color.clear, 1f).SetDelay(13.5f);
		Line5.DOColor(Color.white, 1f).SetDelay(15f);

	}

}
