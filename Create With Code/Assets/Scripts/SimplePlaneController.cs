using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlaneController : MonoBehaviour
{
    public GameObject planeBody,planeProp;
    public float speed, turningSpeed;

    private float axisHorizontal,axisVertical;
    private Vector3 directionVector;
    private Rigidbody planeRigidBody;
    void Start()
    {
        planeRigidBody = planeBody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        axisHorizontal = Input.GetAxis("Horizontal");
        axisVertical = Input.GetAxis("Vertical");
        directionVector = planeBody.transform.rotation * Vector3.forward;
        planeRigidBody.AddTorque(Vector3.right * axisVertical * turningSpeed);
        //planeRigidBody.AddTorque(Vector3.back * axisHorizontal * turningSpeed);
        planeRigidBody.velocity = directionVector * speed;
        planeProp.transform.Rotate(Vector3.forward, 1000 * Time.deltaTime);
    }
}
