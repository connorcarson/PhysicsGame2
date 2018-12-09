using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class TutorialController : MonoBehaviour
{
	public Text Text1;
	public Text Text2;
	public Text Text3;
	public Text Text4;
	public Text Text5;
	public Color clearwhite = new Color(1, 1, 1, 0);

	// Use this for initialization
	void Start()
	{
		Text1.color = clearwhite;
		Text2.color = clearwhite;
		Text3.color = clearwhite;
		Text4.color = clearwhite;
		Text5.color = clearwhite;

		PlayWhiteText();
	}

	void PlayWhiteText()
	{
		Text1.DOColor(Color.white, 1f);
		Text1.DOColor(clearwhite, 1f).SetDelay(4f);
		Text2.DOColor(Color.white, 1f).SetDelay(4.5f);
		Text2.DOColor(clearwhite, 1f).SetDelay(8.5f);
		Text3.DOColor(Color.white, 1f).SetDelay(9f);
		Text3.DOColor(clearwhite, 1f).SetDelay(12f);
		Text4.DOColor(Color.white, 1f).SetDelay(12.5f);
		Text4.DOColor(clearwhite, 1f).SetDelay(19f);
		Text5.DOColor(Color.white, 1f).SetDelay(19.5f);
	}

// Update is called once per frame
	void Update () {
		
	}
}
