﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WombatController : MonoBehaviour {
	
	public float moveSpeed = 4;
	private Vector3 forward, right;
	public Rigidbody rb;
	public GameObject poopCube;
	private GameObject[] poopList;
	private Vector3 poopOffset = new Vector3(-0.5f, 0, 0.3f);
	public bool canPoop = true;
	private int maxNumPoops = 5;
	public AudioClip[] clips;
	// Use this for initialization
	void Start ()
	{
		clips =  new AudioClip[]{
			(AudioClip)Resources.Load("pop sound"), 
			(AudioClip)Resources.Load("pop sound 2"), 
			(AudioClip)Resources.Load("pop sound 3"),
			(AudioClip)Resources.Load("pop sound 4"),
		};
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; //establishes right as 90 degrees from forward
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (Input.anyKey)
			Move();
		
		if (gameObject.transform.position.y < -10)
		{
			Destroy(gameObject);
			print("You've dropped your wombat!");
		}
		
		MakePoop();
	}

	void Move()
	{
		Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 forwardMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
		
		Vector3 heading = Vector3.Normalize(rightMovement + forwardMovement);

		//transform.forward = heading; //makes rotation happen
		//transform.position += rightMovement; //makes right movement happen
		//transform.position += forwardMovement; //makes forward movement happen

		rb.AddForce(forwardMovement * moveSpeed);
		rb.AddForce(rightMovement * moveSpeed);
	}
	
	void MakePoop()
	{
/*		poopList = GameObject.FindGameObjectsWithTag("isPoop");
		
		if (poopList[maxNumPoops])
		{
			canPoop = false;
		}*/

		if (Input.GetKeyDown(KeyCode.P) && canPoop)
		{
			AudioSource poopSound = GetComponent<AudioSource>();
			poopSound.PlayOneShot(clips[Random.Range(0, clips.Length)]);
			rb.MovePosition(new Vector3(rb.position.x, rb.position.y + 1.1f, rb.position.z));
			GameObject poopProjectile = Instantiate(poopCube, gameObject.transform.position + poopOffset, gameObject.transform.rotation);
		}
	}
}
