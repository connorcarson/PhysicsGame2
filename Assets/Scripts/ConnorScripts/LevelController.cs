using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	private GameObject wombat;
	public static WombatController currentWombat;
	public static int numberOfPoopsAllowed = 3;
	public static int numberOfTimesPooped = 0;
	public float xcoordinate;
	public float ycoordinate;
	public float zcoordinate;
	public bool MakeWombatOnLoad = true;
	public WombatController wombatController; //referencing so as to get Jack generation sound clip
	public AudioSource AudioSource;
	
	// Use this for initialization
	void Start ()
	{
		wombatController = FindObjectOfType<WombatController>();

		if (MakeWombatOnLoad) MakeWombat();
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
			//code for Jack sound should go here

		}
	}
	
	public GameObject MakeWombat()
	{
		wombat = Instantiate(Resources.Load<GameObject>("Prefabs/WombatSphere"));
		wombat.transform.position = new Vector3(xcoordinate, ycoordinate, zcoordinate);
		wombat.transform.parent = gameObject.transform;

		currentWombat = wombat.GetComponent<WombatController>();
		currentWombat.currentLevelController = this;
		return wombat;
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

	public int NumberOfPoopsMade()
	{
		return numberOfTimesPooped;
	}

	public void PoopDestroyed()
	{
		if (numberOfTimesPooped > 0) 
			numberOfTimesPooped--;
	}
	
}

