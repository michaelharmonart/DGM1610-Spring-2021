using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDroidController : MonoBehaviour
{
	public Rigidbody2D body;
	public Rigidbody2D head;
	public float headAngleSoftLimit;
	public float speed;
	private float movement;
	public float torque;
	private float headAngle;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		movement = Input.GetAxis("Horizontal");
	}
	private void FixedUpdate()
	{
		headAngle = Vector3.Angle(new Vector3(0f,1f,0f),(head.transform.position - body.transform.position));
		if(
				(
					Mathf.Abs(body.angularVelocity) < speed ||
					Mathf.Abs(body.angularVelocity - movement) < Mathf.Abs(body.angularVelocity)
				)
				&& Mathf.Abs(Mathf.DeltaAngle(0, headAngle)) < headAngleSoftLimit
			)
		{
			body.AddTorque(-movement * torque * Time.fixedDeltaTime * 100);
		}

		Debug.Log(Mathf.Abs(Mathf.DeltaAngle(0, headAngle)));
		Debug.Log("Body Angular Velocity : " + body.angularVelocity.ToString());
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(body.transform.position,head.transform.position);
	}
}
