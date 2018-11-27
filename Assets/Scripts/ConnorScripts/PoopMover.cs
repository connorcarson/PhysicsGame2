using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopMover : MonoBehaviour
{

	public bool isSelected = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected)
		{
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			transform.position = mouseWorldPos;
			
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.isKinematic = true;
		}

		if (Input.GetMouseButtonDown(0))
		{
			isSelected = false;
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.isKinematic = false;
		}
	}
}
