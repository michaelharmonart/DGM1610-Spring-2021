using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject carBody;
    public Rigidbody FR,FL,BR,BL;
    public float Torque,maxSpeed; 
    private float axisHorizontal, axisVertical;
    private Rigidbody carBodyRB;
    private Vector3 forceVector;

    void Start()
    {
      carBodyRB = GetComponent<Rigidbody>();
      FR.maxAngularVelocity = maxSpeed;
      BR.maxAngularVelocity = maxSpeed;
      FL.maxAngularVelocity = maxSpeed;
      BL.maxAngularVelocity = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        axisHorizontal = Input.GetAxis("Horizontal");
        axisVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        //forceVector = carBodyRB.transform.rotation * Vector3.forward * Torque * axisVertical * 10f;
        //carBodyRB.AddForce(forceVector);
        FR.AddTorque(Torque * axisVertical * Time.fixedDeltaTime,0f,0f);
        BR.AddTorque(Torque * axisVertical * Time.fixedDeltaTime,0f,0f);
        FL.AddTorque(Torque * axisVertical * Time.fixedDeltaTime,0f,0f);
        BL.AddTorque(Torque * axisVertical * Time.fixedDeltaTime,0f,0f);

    }
}
