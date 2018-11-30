using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WombatController : MonoBehaviour {
	
	public float moveSpeed = 4;
	private Vector3 forward, right;
	public Rigidbody rb;
	public GameObject poopCube;
	//private GameObject[] poopList;
	//private int maxNumPoops = 5;
	public Vector3 poopOffset;
	public bool canPoop = true;
	public AudioClip[] clips;
	//private PoopMover poopMover;
	
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
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 forwardMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

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
			//rb.isKinematic = true;
			AudioSource poopSound = GetComponent<AudioSource>();
			poopSound.PlayOneShot(clips[Random.Range(0, clips.Length)]);
			rb.MovePosition(new Vector3(rb.position.x, rb.position.y + 1.5f, rb.position.z));
			Instantiate(poopCube, gameObject.transform.position + poopOffset, new Quaternion(0, -180, 0, 0));
		}
	}
}
