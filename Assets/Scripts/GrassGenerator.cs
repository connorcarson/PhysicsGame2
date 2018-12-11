using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour {
	private ParticleSystem grass;
	private Rigidbody rb;
	public WombatController wombatController;
	
	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
		grass = this.transform.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rb.velocity.magnitude > 1.25f && wombatController.grounded == true)
		{
			grass.transform.rotation = Quaternion.identity;
			grass.transform.position = transform.position + Vector3.down;
			grass.transform.position -= rb.velocity.normalized * 1.0f;
			grass.Emit(1);
			
			//Debug.Log("This right here is an arbitrary change to test committing.");
		}
	}
}
