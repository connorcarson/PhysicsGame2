using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSphereMaker : MonoBehaviour
{
	private GameObject testSphere;
	
	// Use this for initialization
	void Start()
	{
		MakeWombat();
	}

	// Update is called once per frame
	void Update()
	{
		CheckforWombat();
	}
	
	void MakeWombat()
	{
		testSphere = Instantiate(Resources.Load<GameObject>("prefabs/TestSphere"));
		testSphere.transform.position = new Vector3();
		testSphere.transform.parent = gameObject.transform;
	}

	void CheckforWombat()
	{
		GameObject testSpheresInScene = GameObject.Find("TestSphere(Clone)");
		if (testSpheresInScene == null)
		{
			MakeWombat();
			print("I got you a new TestSphere!");
		}
	}
}
