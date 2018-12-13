using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BabyWombatController : MonoBehaviour 
{
	private Vector3 direction; //declare new Vector
	private Rigidbody rb; //declare new rigid body
	private Vector3 startPos; //where baby Wombat starts on before dragging
	public float k; //spring constant
	public float maxStretch; //maximum distance mouse can drag and apply force
	public float minStretch; //minimum distance mouse can drag and apply force (may not be necessary)
	private AudioSource SlingshotSoundPlayer;
	private AudioClip PullSound;
	private AudioClip ShootSound;
	private LineRenderer lineRenderer;
	public Camera LineRendererCamera;
	
	// Use this for initialization
	void Start()
	{
		SlingshotSoundPlayer = GetComponent<AudioSource>();
		PullSound = (AudioClip)Resources.Load("slingshot stretch");
		ShootSound = (AudioClip)Resources.Load("slingshot let go");
		rb = GetComponent<Rigidbody>(); //initialize rb as rigid body of baby wombat
		
		lineRenderer = gameObject.GetComponent<LineRenderer>(); //get line renderer component from baby wombat object
		LineRendererCamera = GameObject.Find("LineRendererCamera").GetComponent<Camera>();
		lineRenderer.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (gameObject.transform.position.y < -20 || Input.GetKeyDown(KeyCode.R)) //determines whether or not our baby wombat has fallen too far off screen
		{
			Destroy(gameObject); //if so, destroy that baby wombat
			Debug.Log("You've dropped your baby!");
		}
		
		RepositionLineRendererOnBaby();
	}

	private void OnMouseDown()
	{
		lineRenderer.enabled = true; //destroy line on mouse release
		SlingshotSoundPlayer.clip = PullSound;
		SlingshotSoundPlayer.Play();
			
		startPos = transform.position; //determine init pos

		var position = LineRendererCamera.ScreenToWorldPoint(Input.mousePosition);
		position.z = -90;
		lineRenderer.SetPosition(0, position); //set point of line to baby wombat pos
		lineRenderer.SetPosition(1, position);
	}

	private void OnMouseDrag()
	{
		var mousePositionInWorldSpace = LineRendererCamera.ScreenToWorldPoint(Input.mousePosition);
		mousePositionInWorldSpace.z = -90;
		lineRenderer.SetPosition(1, mousePositionInWorldSpace); //set end of line to follow mouse
	}

	private void OnMouseUp()
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
			Debug.Log("Directions: " + direction); //print our direction in the console
				
			lineRenderer.enabled = false; //destroy line on mouse release
				
			SlingshotSoundPlayer.Stop();
			SlingshotSoundPlayer.clip = ShootSound;
			SlingshotSoundPlayer.Play();
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

	private void RepositionLineRendererOnBaby()
	{
		var position = LineRendererCamera.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(transform.position));
		position.z = -90;
		lineRenderer.SetPosition(0, position);
	}

	public void resetBabyWombat()
	{
		Destroy(gameObject);
	}
}
