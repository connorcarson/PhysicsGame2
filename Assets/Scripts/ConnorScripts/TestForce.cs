using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour
{

	public int forceMultiplier = 1000;
	public Vector3 direction;
	private Rigidbody rb;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.AddForce(direction * forceMultiplier);
		}

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

		if (gameObject.transform.position.z > 10 || gameObject.transform.position.x > 10 || gameObject.transform.position.z < -10)
		{
			Destroy(gameObject);
		}

		//intersection of a ray from the camera to the platform that the sphere is on?
		//What is the distance between that point and the sphere
	}
}
