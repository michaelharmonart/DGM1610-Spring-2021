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
	public float P,I,D,Tau;
	public float maxOutput,minOutput;

	private float movement;
	private float headAngle;
	private float headOffset;

	PidController PID = new PidController();

	// Start is called before the first frame update
	void Start()
	{

		PID.Reset();
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
		PID.Update(0,headOffset,P,I,D,Time.fixedDeltaTime,Tau,maxOutput,minOutput);
		body.AddTorque(-PID.Output() * torque * Time.fixedDeltaTime * 100);
		head.AddForce(new Vector2(movement * headForce,0));
		Debug.Log(PID.Output());
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(body.transform.position,head.transform.position);
	}
}
