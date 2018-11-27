using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WombatController : MonoBehaviour {
	
	public float moveSpeed = 4;
	private Vector3 forward, right;
	public Rigidbody rb;
	public GameObject poopCube;
	private GameObject[] poopList;
	public Vector3 poopOffset;
	public bool canPoop = true;
	private int maxNumPoops = 5;

	// Use this for initialization
	void Start ()
	{
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; //establishes right as 90 degrees from forward
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (Input.anyKey)
			Move();
		
		if (gameObject.transform.position.y < -10)
		{
			Destroy(gameObject);
			print("You've dropped your wombat!");
		}
		
		MakePoop();
	}

	void Move()
	{
		Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 forwardMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
		
		Vector3 heading = Vector3.Normalize(rightMovement + forwardMovement);

		transform.forward = heading; //makes rotation happen
		//transform.position += rightMovement; //makes right movement happen
		//transform.position += forwardMovement; //makes forward movement happen

		rb.AddForce(forwardMovement * moveSpeed);
		rb.AddForce(rightMovement * moveSpeed);
	}
	
	void MakePoop()
	{
/*		poopList = GameObject.FindGameObjectsWithTag("isPoop");
		
		if (poopList[maxNumPoops])
		{
			canPoop = false;
		}*/

		if (Input.GetKeyDown(KeyCode.P) && canPoop)
		{
			GameObject poopProjectile = Instantiate(poopCube, gameObject.transform.position + poopOffset, gameObject.transform.rotation);
		}
	}
}
