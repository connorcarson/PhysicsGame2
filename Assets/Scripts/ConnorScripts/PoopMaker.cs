 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopMaker : MonoBehaviour
{

	public GameObject poopContainer;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		GameObject poop = Instantiate(Resources.Load<GameObject>("Prefabs/PoopCube"));
		
		poop.transform.parent = poopContainer.transform;
		
	}
}
