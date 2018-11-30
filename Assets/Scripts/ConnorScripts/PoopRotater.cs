using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopRotater : MonoBehaviour
{
	public float rotationSpeed = 1;
	private bool canRotate = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canRotate)
		{
			gameObject.transform.Rotate((Input.mousePosition.x * rotationSpeed * Time.deltaTime), 0, 0, Space.World);
		}

		if (Input.GetMouseButtonUp(0))
		{
			canRotate = false;
		}
		
		//different method
		/*var pos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); */
	}
}
