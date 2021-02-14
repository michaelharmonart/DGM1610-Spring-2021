using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDroidController : MonoBehaviour
{
	public Rigidbody2D body;
	public Rigidbody2D head;
	public float headAngleSoftLimit;
	//public float headForce;
	public float torque;
	public float jumpForce,recoveryForce;
	public float P,I,D;
	public float maxOutput,minOutput;

	private float movement;
	private float jump;
	private float setPoint;
	private float headAngle;
	private float headOffset;

 	PidController balancePid = new PidController();

	// Start is called before the first frame update
	void Start()
	{

		balancePid.Reset();
	}

	// Update is called once per frame
	void Update()
	{
		movement = Input.GetAxis("Horizontal");
		jump = Input.GetAxis("Jump");
		setPoint = Mathf.Lerp(-headAngleSoftLimit,headAngleSoftLimit,(Input.GetAxis("Horizontal")*0.5f)+0.5f);
	}
	private void FixedUpdate()
	{
		headAngle = Vector3.SignedAngle((head.transform.position - body.transform.position),new Vector3(0f,1f,0f),new Vector3(0f,0f,1f));
		//headAngle = Vector3.Angle(new Vector3(0f,1f,0f),(head.transform.position - body.transform.position));
		headOffset = head.transform.position.x - body.transform.position.x;
		balancePid.Update(setPoint,headAngle,P,I,D,Time.fixedDeltaTime,maxOutput,minOutput);
		//head.AddForce(new Vector2(movement * headForce,0));
		Debug.Log(-balancePid.Output()+"  "+headAngle+"  "+jump);
		if(body.IsTouchingLayers(-1) == true && Mathf.Abs(headAngle) <80)
		{
			body.AddForce(new Vector2(0f,jump*jumpForce*10));
			body.AddTorque(-balancePid.Output() * torque * Time.fixedDeltaTime * 10);
		}
		if(body.IsTouchingLayers(-1) == true && Mathf.Abs(headAngle) > 80)
		{
			head.AddForce(new Vector2(0f,jump*recoveryForce));
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(body.transform.position,head.transform.position);
	}
}
