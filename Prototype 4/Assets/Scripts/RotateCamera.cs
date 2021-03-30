using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    private float horizontalInput,verticalInput;
    private Vector3 rotationEulers;

    void Start()
    {

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rotationEulers.Set(0f,horizontalInput * rotationSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotationEulers);
    }
}
