using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	private GameObject wombat;
	public static WombatController currentWombat;
	public static int numberOfPoopsAllowed = 30;
	public static int numberOfTimesPooped = 0;
	public float xcoordinate;
	public float ycoordinate;
	public float zcoordinate;
	
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
		wombat.transform.position = new Vector3(xcoordinate, ycoordinate, zcoordinate);
		wombat.transform.parent = gameObject.transform;

		currentWombat = wombat.GetComponent<WombatController>();
		currentWombat.currentLevelController = this;
	}

	public bool CanStillPoop()
	{
		if (numberOfTimesPooped < numberOfPoopsAllowed)
			return true;

		return false;

		//return (numberOfTimesPooped < numberOfPoopsAllowed);
	}

	public void JustPooped()
	{
		numberOfTimesPooped += 1;
	}

	public int NumberOfPoopsRemaining()
	{
		return numberOfPoopsAllowed - numberOfTimesPooped;
	}
}

