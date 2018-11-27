using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSlingShot : MonoBehaviour {
	
	public delegate void OnDragMouseReleaseDelegate();
	public event OnDragMouseReleaseDelegate OnDragMouseReleaseEvent;
	
	private Vector3 offSet;
	private Vector3 defaultPos;
	private Vector3 currentPos;
	
	void Start ()
	{
		defaultPos = new Vector3(-11, 12.5f, -2);
		transform.position = defaultPos;
	}

	private void OnMouseDown()
	{
		offSet = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
		Cursor.visible = false;
	}

	private void OnMouseDrag()
	{
		var currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		currentPos = transform.position;
	}

	private void OnMouseUp()
	{
		Cursor.visible = true;
		
		if (OnDragMouseReleaseEvent != null)
		{
			OnDragMouseReleaseEvent.Invoke();
		}

		transform.position = defaultPos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
