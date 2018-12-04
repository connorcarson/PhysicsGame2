using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWombatController : MonoBehaviour 
{
	private Vector3 direction; //declare new Vector
	private Rigidbody rb; //declare new rigid body
	private Vector3 startPos; //where baby Wombat starts on before dragging
	public float k; //spring constant
	public float maxStretch; //maximum distance mouse can drag and apply force
	public float minStretch; //minimum distance mouse can drag and apply force (may not be necessary)
	private bool mouseEnabled;
	private AudioSource SlingshotSoundPlayer;
	private AudioClip PullSound;
	private AudioClip ShootSound;

	// Use this for initialization
	void Start()
	{
		SlingshotSoundPlayer = GetComponent<AudioSource>();
		PullSound = (AudioClip)Resources.Load("slingshot stretch");
		ShootSound = (AudioClip) Resources.Load("slingshot let go");
		mouseEnabled = true;
		rb = GetComponent<Rigidbody>(); //initialize rb as rigid body of baby wombat
	}

	// Update is called once per frame
	void Update()
	{
		Debug.DrawLine(startPos, direction);
		if (gameObject.transform.position.y < -30) //determines whether or not our baby wombat has fallen too far off screen
		{
			Destroy(gameObject); //if so, destroy that baby wombat
			Debug.Log("You've dropped your baby!");
		}
	}

	private void OnMouseDown()
	{
		if (mouseEnabled)
		{
			SlingshotSoundPlayer.clip = PullSound;
			SlingshotSoundPlayer.Play();
			startPos = transform.position; //determine init pos
		}
	}

	private void OnMouseUp()
	{
		if (mouseEnabled)
		{
			var mainCamera = FindCamera(); //get camera pos
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //cast ray from pos of mouse on screen to collider in scene
			RaycastHit hit; //used to get information back from raycast

			if (Physics.Raycast(ray, out hit)) //if our ray hits an object return the information from our raycast
			{
				direction = startPos - hit.point; 
				//find direction between our init pos and the impact point in the scene where our ray hit the collider
				//AKA find the direction between our baby wombat and the point of mouse release
				WombatSlingshot(); //call our Wombat Slingshot Function
				
				SlingshotSoundPlayer.Stop();
				SlingshotSoundPlayer.clip = ShootSound;
				SlingshotSoundPlayer.Play();
				Debug.Log("Directions: " + direction); //print our direction in the console
			}
		}
	}

	private void WombatSlingshot()
	{
		float f = Mathf.Clamp((direction.magnitude * k), minStretch, maxStretch); //force equals negative distance times spring constant
		Debug.Log("distance: " + f); //print our force in the console
		rb.AddForce(direction * f); //apply our force to the baby wombat
	}

	private Camera FindCamera()
	{
		if (GetComponent<Camera>())
		{
			return GetComponent<Camera>();
		}
		
		return Camera.main;
	}
}
