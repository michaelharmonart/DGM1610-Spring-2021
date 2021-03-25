using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityMultiplier = 2f;
    public bool isOnGroud = true;

    private Rigidbody playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGroud)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGroud = false;
        }
    }

    void OnCollisionEnter()
    {
        isOnGroud = true;
    }
}
