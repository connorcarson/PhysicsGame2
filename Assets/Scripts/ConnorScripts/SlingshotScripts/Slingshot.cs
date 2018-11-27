using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Slingshot : MonoBehaviour
{	
	public LineRenderer[] HandlesLineRendering;
	public Transform[] HandlesAnchorTransforms;
	public DragSlingShot dragSlingShot;
	public Transform ReleasePointTransform;
	public Transform ProjectileSpawnTransform;
	public Transform AimTransform;
	public GameObject ProjectilePrefab;
	public float StartPower = 0;
	
	private float[] LineLengths;

	private void Start()
	{
		LineLengths = new float[2];
		AimTransform.position = new Vector3(1, 1, 0);

		for (var i = 0; i < HandlesLineRendering.Length; i++)
		{
			HandlesLineRendering[i].SetPosition(0, HandlesAnchorTransforms[i].position);
			HandlesLineRendering[i].SetPosition(1, dragSlingShot.transform.position);
			HandlesLineRendering[i].startWidth = 0.15f;
			HandlesLineRendering[i].endWidth = 0.05f;
		}
	}
	public float GetVelocity()
	{
		return Vector3.Distance(dragSlingShot.transform.position, ReleasePointTransform.transform.position) * 2.5f;
	}
	
	public float GetDistance(float Vinit)
	{
		var g = Physics.gravity.y;
		var Vvert = Vinit * (Mathf.Sin(GetAngle() * Mathf.Deg2Rad));
		var Vhor = Vinit * (Mathf.Cos(GetAngle() * Mathf.Deg2Rad));
		var Tvert = (0 - Vvert) / g;
		var Thor = 2 * Tvert;
		var distance = Vhor * Thor;
		return distance;
	}

	public float GetHeight(float Vinit, int amountPoints, int pointIndex)
	{
		var g = Physics.gravity.y;
		var Vvert = Vinit * (Mathf.Sin(GetAngle() * Mathf.Deg2Rad));
		var Vhor = Vinit * (Mathf.Cos(GetAngle() * Mathf.Deg2Rad));
		var Tvert = (0 - Vvert) / g;
		var Thor = 2 * Tvert;
		var Dtot = Vhor * Thor;
		var Dp = (Dtot / (amountPoints)) * pointIndex;
		var T2 = Dp / Vhor;
		var height = ((Vvert * Dp) / Vhor) + 0.5f * g * Mathf.Pow(T2, 2);
		return height;
	}

	public void MakeShot()
	{
		var _projectile = Instantiate(ProjectilePrefab, ProjectileSpawnTransform.position, Quaternion.identity) as GameObject;
		_projectile.GetComponent<Rigidbody>().AddForce(GetShotDirection() * StartPower * 2.5f, ForceMode.Impulse);

		Destroy(_projectile, 4.0f);
	}

	public float GetAngle()
	{
		var angle = Vector3.Angle((ReleasePointTransform.transform.position - dragSlingShot.transform.position).normalized, Vector3.right);

		if (dragSlingShot.transform.position.y > AimTransform.position.y)
		{
			angle = angle * -1;
		}

		return angle;
	}
	
	private void OnEnable()
	{
		dragSlingShot.OnDragMouseReleaseEvent += DragHandle_OnDragHandleReleaseEvent;
	}

	private void OnDisable()
	{
		dragSlingShot.OnDragMouseReleaseEvent -= DragHandle_OnDragHandleReleaseEvent;
	}

	private void OnDestroy()
	{
		dragSlingShot.OnDragMouseReleaseEvent -= DragHandle_OnDragHandleReleaseEvent;
	}

	private void DragHandle_OnDragHandleReleaseEvent()
	{
		MakeShot();
	}

	private void Update()
	{
		UpdateLines();
		UpdateAim();
		GetHeight(GetVelocity(), 3, 1);
		StartPower = Vector3.Distance(dragSlingShot.transform.position, ReleasePointTransform.transform.position);
	}

	private void UpdateLines()
	{
		for (var i = 0; i < HandlesLineRendering.Length; i++)
		{
			HandlesLineRendering[i].SetPosition(1, dragSlingShot.transform.position);
			HandlesLineRendering[i].SetPosition(0, HandlesAnchorTransforms[i].position);

			HandlesLineRendering[i].GetComponent<LineRenderer>().startWidth = 0.15f / LineLengths[i];
			HandlesLineRendering[i].GetComponent<LineRenderer>().endWidth = 0.05f / LineLengths[i];

			LineLengths[i] = Vector3.Distance(dragSlingShot.transform.position, HandlesAnchorTransforms[i].position);

			if (LineLengths[i] <= 0.65f)
			{
				LineLengths[i] = 0.65f;
			}
		}
	}

	private void UpdateAim()
	{
		var pullDirection = ReleasePointTransform.position - (dragSlingShot.transform.position - ReleasePointTransform.position).normalized;
		AimTransform.position = pullDirection;
	}

	private Vector3 GetShotDirection()
	{
		return (AimTransform.position - ReleasePointTransform.transform.position).normalized;
	}
}
