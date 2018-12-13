using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWombatMaker : MonoBehaviour {
	
	private GameObject babyWombat;
	public float xcoordinatebaby;
	public float ycoordinatebaby;
	public float zcoordinatebaby;
	public bool MakeBabyOnLoad = true;
	
	// Use this for initialization
	void Start()
	{
		if (MakeBabyOnLoad) 
		{
			MakeBabyWombat();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (MakeBabyOnLoad)
		{
			CheckforWombat();
		}
	}
	
	public void MakeBabyWombat()
	{
		Debug.Log("Baby made.");
		
		babyWombat = Instantiate(Resources.Load<GameObject>("prefabs/FinalBabyWombat"));
		babyWombat.transform.position = new Vector3(xcoordinatebaby, ycoordinatebaby, zcoordinatebaby);
		babyWombat.transform.parent = gameObject.transform;
		MakeBabyOnLoad = true;
	}

	void CheckforWombat()
	{
		GameObject babyWombatInScene = GameObject.Find("FinalBabyWombat(Clone)");
		if (babyWombatInScene == null)
		{
			MakeBabyWombat();
			print("I got you a new baby!");
		}
	}

	public GameObject GetBaby()
	{
		return babyWombat;
	}
}
