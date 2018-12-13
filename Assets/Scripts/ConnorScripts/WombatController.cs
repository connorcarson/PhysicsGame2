using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WombatController : MonoBehaviour {
	
	public float moveSpeed = 4;
	public float jumpSpeed = 6;
	public float fallMultiplier = 2.5f;
	private Vector3 forward, right;
	public Rigidbody rb;
	public GameObject poopCube;
	public GameObject rotationGraphic;
	public Vector3 poopOffset;
	public AudioClip[] clips;
	public bool isPooping = false;
	public bool grounded;
	public bool touchingPoop = false;

	public LevelController currentLevelController;

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
		CheckIsStillInsideLevel();
		if (isPooping)
		{
			if (Input.GetMouseButtonUp(0))
			{
				ResetAbilityToPoop();
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && currentLevelController.CanStillPoop() && !isPooping)
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

	void CheckIsStillInsideLevel()
	{
		if (gameObject.transform.position.y < -10)
		{
			Destroy(gameObject); //if the wombat falls below a certain point, destroy it
			print("You've dropped your wombat!");
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
		/*MeshRenderer rotationRenderer = rotationGraphic.GetComponent<MeshRenderer>();
		rotationRenderer.enabled = true;*/
		
		currentLevelController.JustPooped();
		isPooping = true; //wombat is currently setting position of poop
		rb.isKinematic = true; //wombat cannot move while setting position of poop
		rb.velocity = Vector3.zero;
	}

	public void ResetAbilityToPoop()
	{	
		isPooping = false; //if player was pooping and released mouse, player is no longer pooping
		rb.isKinematic = false; //wombat can move again
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
}
