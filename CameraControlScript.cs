using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour 
{
	public Transform FollowTarget;

	public bool FirstAndThird;
	public bool CanZoom;
	public bool CanMove;

	public float MaxZoom;
	public float MinZoom;
	public float XSpeed;
	public float rotateSpeed = 5;

	public GameObject target;

	Vector3 offset;
	
	void Start() {
		offset = target.transform.position - transform.position;
	}
	
	void LateUpdate() {
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0);
		
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);
	}
}

