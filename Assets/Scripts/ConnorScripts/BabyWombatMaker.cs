using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWombatMaker : MonoBehaviour {
	
	private GameObject babyWombat;
	
	// Use this for initialization
	void Start()
	{
		MakeWombat();
	}

	// Update is called once per frame
	void Update()
	{
		CheckforWombat();
	}
	
	void MakeWombat()
	{
		babyWombat = Instantiate(Resources.Load<GameObject>("prefabs/BabyWombat"));
		babyWombat.transform.position = new Vector3(-12, 12.5f, -2.5f);
		babyWombat.transform.parent = gameObject.transform;
	}

	void CheckforWombat()
	{
		GameObject babyWombatInScene = GameObject.Find("BabyWombat(Clone)");
		if (babyWombatInScene == null)
		{
			MakeWombat();
			print("I got you a new Baby!");
		}
	}
}
