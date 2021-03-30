using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject focalPoint;

    private Rigidbody playerRigidbody;
    private float horizontalInput, verticalInput;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
    }
}
