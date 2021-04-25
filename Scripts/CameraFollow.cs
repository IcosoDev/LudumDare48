using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;
	public float smooth = 0.125f;
	public Vector3 offset;
	void Update()
	{
		Vector3 pos = target.position + offset;
		Vector3 smoothedPos = Vector3.Lerp(transform.position, pos, smooth);
		transform.position = smoothedPos;

		transform.LookAt(target);
	}
}