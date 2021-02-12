using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDroidController : MonoBehaviour
{
	public Rigidbody2D body;
	public Rigidbody2D head;
	public float headAngleSoftLimit;
	public float headForce;
	public float speed;
	public float torque;
	public float proportional;

	private float movement;
	private float headAngle;
	private float headOffset;

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
		headOffset = head.transform.position.x - body.transform.position.x;
		if(
				(
					Mathf.Abs(body.angularVelocity) < speed ||
					Mathf.Abs(body.angularVelocity - headOffset) < Mathf.Abs(body.angularVelocity)
				)
				&& Mathf.Abs(Mathf.DeltaAngle(0, headAngle)) < headAngleSoftLimit
			)
		{
			head.AddForce(new Vector2(movement * headForce,0));
			body.AddTorque(-headOffset * torque * proportional * Time.fixedDeltaTime * 100);
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
