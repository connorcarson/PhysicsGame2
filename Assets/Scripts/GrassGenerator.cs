using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour {
	private ParticleSystem grass;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
		grass = this.transform.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rb.velocity.magnitude > 0.5)
		{
			grass.Emit(1);
			Debug.Log("This right here is an arbitrary change to test committing.");
		}
	}


	
}
