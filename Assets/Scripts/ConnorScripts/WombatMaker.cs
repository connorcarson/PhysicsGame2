using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombatMaker : MonoBehaviour
{
	private GameObject wombat;
	
	// Use this for initialization
	void Start ()
	{
		MakeWombat();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckforWombat();
	}

	void CheckforWombat()
	{
		GameObject wombats = GameObject.Find("WombatSphere(Clone)");
		if (wombats == null)
		{
			MakeWombat();
			print("I got you a new wombat!");
		}
	}
	
	void MakeWombat()
	{
		wombat = Instantiate(Resources.Load<GameObject>("Prefabs/WombatSphere"));
		wombat.transform.position = new Vector3(-10.5f, 12.5f, -2);
		wombat.transform.parent = gameObject.transform;
	}
}

