using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWombatMaker : MonoBehaviour {
	
	private GameObject babyWombat;
	public float xcoordinatebaby;
	public float ycoordinatebaby;
	public float zcoordinatebaby;
	
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
		babyWombat.transform.position = new Vector3(xcoordinatebaby, ycoordinatebaby, zcoordinatebaby);
		babyWombat.transform.parent = gameObject.transform;
	}

	void CheckforWombat()
	{
		GameObject babyWombatInScene = GameObject.Find("BabyWombat(Clone)");
		if (babyWombatInScene == null)
		{
			MakeWombat();
			print("I got you a new baby!");
		}
	}
}
