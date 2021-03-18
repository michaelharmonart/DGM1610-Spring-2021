using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject carBody;
    public float Torque; 
    private float axisHorizontal, axisVertical;
    private Rigidbody carBodyRB;
    private Vector3 forceVector;

    void Start()
    {
      carBodyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        axisHorizontal = Input.GetAxis("Horizontal");
        axisVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        forceVector = carBodyRB.transform.rotation * Vector3.forward * Torque * axisVertical * 10f;
        carBodyRB.AddForce(forceVector);
    }
}
