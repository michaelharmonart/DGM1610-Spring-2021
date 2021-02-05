using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backWheel;
    public Rigidbody2D frontWheel;
		public Rigidbody2D body;
		public float speed;
		public float rotationSpeed;
    private float movement;
    public float torque;
		public float bodyTorque;
    public float fourWheelDriveAmmount;

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
				if(Mathf.Abs(backWheel.angularVelocity) < speed || Mathf.Abs(backWheel.angularVelocity - movement) < Mathf.Abs(backWheel.angularVelocity))
				{
				backWheel.AddTorque(-movement * torque * Time.fixedDeltaTime * 100);
				frontWheel.AddTorque(-movement * torque * Time.fixedDeltaTime * fourWheelDriveAmmount * 100);
				}
				if(Mathf.Abs(body.angularVelocity) < rotationSpeed || Mathf.Abs(body.angularVelocity + movement) < Mathf.Abs(body.angularVelocity))
				{
				body.AddTorque(movement * bodyTorque * Time.fixedDeltaTime * 100);
				}
				Debug.Log("Back Wheel Angular Velocity : "+backWheel.angularVelocity.ToString());
    }
}
