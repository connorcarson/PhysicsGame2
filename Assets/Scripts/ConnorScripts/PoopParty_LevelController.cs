using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopParty_LevelController : MonoBehaviour {
	private GameObject wombat;
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
		wombat = Instantiate(Resources.Load<GameObject>("Prefabs/FinalWombatSphere_PoopParty"));
		wombat.transform.position = new Vector3(xcoordinate, ycoordinate, zcoordinate);
		wombat.transform.parent = gameObject.transform;

		audioSource.clip = JackCreatedSound;
		audioSource.Play();
		//code for Jack sound should go here
	
		return wombat;
	}

}
