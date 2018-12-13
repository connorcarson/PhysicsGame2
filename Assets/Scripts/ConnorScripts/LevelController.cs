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
	public AudioSource audioSource;
	private AudioClip JackCreatedSound;
	
	// Use this for initialization
	void Start (){
	audioSource = GetComponent<AudioSource>();
	JackCreatedSound = (AudioClip)Resources.Load("jack sound");
	
		if (MakeWombatOnLoad) MakeWombat();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	public GameObject MakeWombat()
	{
		wombat = Instantiate(Resources.Load<GameObject>("Prefabs/FinalWombatSphere"));
		wombat.transform.position = new Vector3(xcoordinate, ycoordinate, zcoordinate);
		wombat.transform.parent = gameObject.transform;

		audioSource.clip = JackCreatedSound;
		audioSource.Play();
		//code for Jack sound should go here
		
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

