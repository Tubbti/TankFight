using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowTarget : MonoBehaviour {

    public Transform[] tanks;
	private Vector3 offset;
	[SerializeField]
	private Camera Mcamera;

	// Use this for initialization
	void Start () {
	    Vector3 centerPoint = GetCenterPoint();
		offset = transform.position - centerPoint;
	}
	
	private Vector3 GetCenterPoint()
	{
		Vector3 point = new Vector3();
		foreach(Transform tank in tanks)
		{
			point += tank.position;
		}
		point = point / tanks.Length;
		return point;
	}
	void LateUpdate () {
	   Vector3 point = GetCenterPoint();
	   transform.position = point + offset;
	   Mcamera.orthographicSize = GetReqScreenSize();
	}
	private float GetReqScreenSize()
	{
		Vector3 centerPoint = GetCenterPoint();
		Vector3 centerPointCam = transform.InverseTransformPoint(centerPoint);
		float maxSize = 0;
		foreach(Transform tank in tanks)
		{
			Vector3 tankPointAtCamera = transform.InverseTransformPoint(tank.position);
			Vector3 distance = tankPointAtCamera - centerPointCam;
			maxSize = Mathf.Max(maxSize,Mathf.Abs(distance.y));
			maxSize = Mathf.Max(maxSize,Mathf.Abs(distance.x)/Mcamera.aspect);
		}
		return maxSize+5;
	}
	public void SetTanksTransforms(Transform []tanks)
	{
		this.tanks = tanks;
	}
}
