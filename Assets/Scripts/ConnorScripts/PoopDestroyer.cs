using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDestroyer : MonoBehaviour
{

	public GameObject poopCube;
	private int numCollisions;
	
	// Use this for initialization
	void Start ()
	{
		numCollisions = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (numCollisions++ < 1)
			return;
		
		Destroy(poopCube);
		var poopSplosion = Instantiate(Resources.Load("Prefabs/ExplodingPoopParticles") as GameObject);
		poopSplosion.transform.position = transform.position;
	}
}
