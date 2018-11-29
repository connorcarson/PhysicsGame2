using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWombatController : MonoBehaviour {
	private Vector3 direction;
	private Rigidbody rb;
	private Vector3 startPos; //where baby Wombat starts on x axis before dragging
	public float k; //spring constant
	public float maxStretch;
	public float minStretch;
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
		if (gameObject.transform.position.y < -30)
		{
			Destroy(gameObject);
		}
	}

	private void OnMouseDown()
	{
		if (mouseEnabled)
		{
			startPos = transform.position; //start init position
		}
	}

	private void OnMouseUp()
	{
		if (mouseEnabled)
		{
			var mainCamera = FindCamera(); //get camera pos
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				Vector3 mouseRelPos = hit.point;
				direction = mouseRelPos;
				WombatSlingshot(mouseRelPos);
				Debug.Log("Directions: " + direction);
			}
		}
	}

	private void WombatSlingshot(Vector3 mousePos)
	{
		Vector3 distance = startPos - mousePos; //find our distance
		float f = Mathf.Clamp((distance.magnitude * k), minStretch, maxStretch); //force equals negative distance times spring constant
		Debug.Log("distance: " + f);
		rb.AddForce(-direction * f); //apply our force
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
