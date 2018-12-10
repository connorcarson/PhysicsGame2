using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDestroyer : MonoBehaviour
{

	public GameObject poopCube;
	private int numCollisions;
	private LevelController CurrentLevelController;
    	
	// Use this for initialization
	void Start ()
	{
		numCollisions = 0;
		GameObject wombatContainer = GameObject.FindWithTag("wombatContainer");
		CurrentLevelController = wombatContainer.GetComponent<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (numCollisions++ < 1)
			return;
		
		Destroy(poopCube);
		CurrentLevelController.numberOfTimesPooped -= 1 ;
	}
}
