using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopController : MonoBehaviour
{
	float rotationSpeed = 600;
	private bool canRotate = true;
	private Rigidbody rb;
	public GameObject rotationGraphic;
	
	// Use this for initialization
	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canRotate)
		{
			RotatePoop();
			
			if (Input.GetMouseButtonUp(0))
			{
				MeshRenderer rotationRenderer = rotationGraphic.GetComponent<MeshRenderer>();
				rotationRenderer.enabled = false;
				canRotate = false;
				rb.isKinematic = true; //make poop static
			}
		}
	}

	void RotatePoop()
	{
		Input.GetAxis("Mouse X");
		Collider poopCollider = GetComponent<Collider>();
		Vector3 poopCenter = poopCollider.bounds.center;
		gameObject.transform.RotateAround(poopCenter, Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime);
	}
}
