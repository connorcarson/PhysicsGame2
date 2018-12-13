using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopParty_WombatController : MonoBehaviour {
	public float moveSpeed = 4;
	public float jumpSpeed = 6;
	public float fallMultiplier = 2.5f;
	public Vector3 resetWombatPosition;
	private Vector3 forward, right;
	public Rigidbody rb;
	public GameObject poopCube;
	public Vector3 poopOffset;
	public AudioClip[] clips;
	public bool grounded;
	public bool touchingPoop = false;

	// Use this for initialization
	void Start ()
	{	
		clips =  new AudioClip[]{
			(AudioClip)Resources.Load("pop sound"), 
			(AudioClip)Resources.Load("pop sound 2"), 
			(AudioClip)Resources.Load("pop sound 3"),
			(AudioClip)Resources.Load("pop sound 4"),
			(AudioClip)Resources.Load("pop sound ugh"),
			(AudioClip)Resources.Load("jump sound"),
			//load poop sounds into an array of clips
		};
		
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward); //establishes forward relative to the camera
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; //establishes right as 90 degrees from forward
	}
	
	// Update is called once per frame
	void Update ()
	{	
		GetMovementInputs();

		if (Input.GetKeyDown(KeyCode.P))
		{
			MakePoop();
		}
		
		if (Input.GetKeyDown(KeyCode.Space) && (grounded || touchingPoop))
		{
			Jump();
		}

		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
	}

	void GetMovementInputs()
	{
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 forwardMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

		rb.AddForce(forwardMovement * moveSpeed);
		rb.AddForce(rightMovement * moveSpeed);
	}
	
	void Jump()
	{
		rb.velocity = Vector3.up * jumpSpeed;
		grounded = false;
		touchingPoop = false;
		AudioSource poopSound = GetComponent<AudioSource>();
		poopSound.PlayOneShot(clips[5]);
	}
	
	public void MakePoop()
	{
		AudioSource poopSound = GetComponent<AudioSource>();
		poopSound.PlayOneShot(clips[Random.Range(0, clips.Length)]);//play random poop sound

		Instantiate(poopCube, gameObject.transform.position + poopOffset, new Quaternion(0, -180, 0, 0)); //make poop under wombat
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z); //offset wombat on y axis to make space for poop
	}
	
	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.gameObject.CompareTag("isFloor"))
		{
			grounded = true;
		}
		else if (other.collider.gameObject.CompareTag("isPoop"))
		{
			touchingPoop = true;
		}
	}

	private void OnBecameInvisible()
	{
		transform.position = resetWombatPosition;
	}
}
