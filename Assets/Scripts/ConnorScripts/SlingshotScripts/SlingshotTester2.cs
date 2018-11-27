using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotTester2 : MonoBehaviour {
	
	public float multiplier;
	private Vector3 initPos;
	public Rigidbody rb;
 
	//get the initial positon of the holder before the drag starts
	void OnMouseDown()
	{
		initPos = gameObject.transform.position;
	}
 
	//move the holder according to the drag
	void OnMouseDrag()
	{
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = mouseWorldPos;
	}
 
	//add force to the disc in the direction of the line between
	//the current position of the holder and its initial position
	void OnMouseUp()
	{
		rb.AddForce((initPos - transform.position) * Vector3.Distance(transform.position, initPos) * multiplier);
	}
}
