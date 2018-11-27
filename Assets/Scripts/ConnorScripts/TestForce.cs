using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour
{

	public int forceMultiplier = 1000;
	public Vector3 direction;
	private Rigidbody rb;
	private Vector3 startPos; //where baby Wombat starts on x axis before dragging
	private float startZ; //where baby Wombat starts on z axis before dragging
	public float k; //spring constant
	private bool mouseEnabled; 

	// Use this for initialization
	void Start()
	{
		mouseEnabled = true;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
/*		if (Input.GetMouseButtonDown(0))
		{
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.AddForce(direction * forceMultiplier);
		}*/

		if (Input.GetKeyDown(KeyCode.D))
		{
			direction.x += 0.25f;
			direction.z -= 0.25f;
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			direction.x -= 0.25f;
			direction.z += 0.5f;
		}

		/*if (gameObject.transform.position.z > 10 || gameObject.transform.position.x > 10 || gameObject.transform.position.z < -10)
		{
			Destroy(gameObject);
		}
*/

		//intersection of a ray from the camera to the platform that the sphere is on?
		//What is the distance between that point and the sphere
	}

	private void OnMouseDown()
	{
		if (mouseEnabled)
		{
			startPos = transform.position; //start init position
		}
	}

	private void OnMouseDrag()
	{
		if (mouseEnabled)
		{
			var mainCamera = FindCamera();
			var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			Vector3 mouseRelPos =
				new Vector3(ray.GetPoint(rb.position.x).x, rb.position.y, ray.GetPoint(rb.position.z).x);
		}
	}

	private void OnMouseUp()
	{
		if (mouseEnabled)
		{
			var mainCamera = FindCamera(); //get camera pos
			var ray = mainCamera.ScreenPointToRay(Input.mousePosition); //shoot laser at the object relative to the camera
			Vector3 mouseRelPos = new Vector3(ray.GetPoint(transform.position.x).x, transform.position.y,
				ray.GetPoint(transform.position.z).x);
			direction = mouseRelPos;
			WombatSlingshot(mouseRelPos);
		}
	}

	private void WombatSlingshot(Vector3 mousePos)
	{
		Vector3 x = startPos - mousePos; //find our x distance
		float f = x.magnitude * k; //force equals negative distance times spring constant
		rb.AddForce(direction * f); //apply our force
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
