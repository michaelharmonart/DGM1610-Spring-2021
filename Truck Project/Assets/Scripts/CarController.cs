using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backWheel;
    public Rigidbody2D frontWheel;
    private float movement;
    public float torque;

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
        backWheel.AddTorque(-movement * torque);
        frontWheel.AddTorque(-movement * torque);
    }
}
