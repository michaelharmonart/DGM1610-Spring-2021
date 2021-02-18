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
		headAngle = Vector3.SignedAngle((head.transform.position - body.transform.position),Vector3.up,Vector3.forward); //Find angle of head compared to the body position
		balancePid.Update(setPoint,headAngle,P,I,D,Time.fixedDeltaTime,maxOutput,minOutput);
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
