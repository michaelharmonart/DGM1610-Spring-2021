using UnityEngine;

public class BallDroidController : MonoBehaviour
{
	public Rigidbody2D body;
	public Rigidbody2D head;

	public float headAngleSoftLimit;
	public float torque;
	public float jumpForce,recoveryForce;
	public float P,I,D;
	public float maxOutput,minOutput;

	private float movement;
	private float jump;
	private float setPoint;
	private float headAngle;
	private Vector2 headForceVector;
	private float bodySpeed;

	//Create PID controller objects
 	PidController balancePid = new PidController();
	PidController headAirPid = new PidController();

	// Start is called before the first frame update
	void Start()
	{
		balancePid.Reset();
		headAirPid.Reset();
	}

	// Update is called once per frame
	void Update()
	{
		movement = Input.GetAxis("Horizontal");
		jump = Input.GetAxis("Jump");
		setPoint = Mathf.Lerp(-headAngleSoftLimit,headAngleSoftLimit,(Input.GetAxis("Horizontal")*0.5f)+0.5f); //Get the setPoint for the PID controller, from the keyboard or controller input
	}
	private void FixedUpdate()
	{
		headAngle = Vector3.SignedAngle((head.transform.position - body.transform.position),Vector3.up,Vector3.forward); //Find angle of head compared to the body position
		headForceVector = -Vector2.Perpendicular(new Vector2(head.transform.position.x,head.transform.position.y) - new Vector2(body.transform.position.x,body.transform.position.y)); //Janky line of code that finds a vector perpendicular to the body offset

		//Calculate the speed in every case
		if(body.velocity.x > 0)
		{
			bodySpeed = Vector3.Magnitude(new Vector3(body.velocity.x,body.velocity.y,0f));
		}
		if(body.velocity.x < 0)
		{
			bodySpeed = -Vector3.Magnitude(new Vector3(body.velocity.x,body.velocity.y,0f));
		}
		if(body.velocity.x == 0)
		{
			bodySpeed = 0f;
		}

		//Update the PID controllers
		balancePid.Update(setPoint,headAngle,P,I,D,Time.fixedDeltaTime,maxOutput,minOutput);
		headAirPid.Update(setPoint,headAngle,0.05f,0f,0.015f,Time.fixedDeltaTime,maxOutput,minOutput);

		//Debug.Log(-balancePid.Output()+"  "+headAngle+"  "+bodySpeed);
		if(body.IsTouchingLayers(-1) == true && Mathf.Abs(headAngle) <80) //If the body is touching anything, and is somewhat upright
		{
			body.AddForce(new Vector2(0f,jump*jumpForce*10)); //Add the jumpForce
			body.AddTorque(-balancePid.Output() * torque * Time.fixedDeltaTime * 10); //Add torque to the body according to PID outputs
		}
		if(body.IsTouchingLayers(-1) == true && Mathf.Abs(headAngle) > 80) //If the body is touching anything, and the head is not upright
		{
			head.AddForce(new Vector2(0f,jump*recoveryForce)); //If the jump button is pressed, add a recoveryForce to the head to return it to an upright position
		}
		if(body.IsTouchingLayers(-1) == false && Mathf.Abs(headAngle) < 80) //If the body isn't touching anything and the head is upright
		{
			head.AddForce(headForceVector*-headAirPid.Output()); //Add force to the head according to PID output
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(body.transform.position,head.transform.position);
	}
}
