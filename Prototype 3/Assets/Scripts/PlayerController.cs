using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityMultiplier = 2f;
    public bool isOnGroud = true;
    public BoolData gameOver;

    private Rigidbody playerRB;

    void Start()
    {
        gameOver.data = false;   
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGroud = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver.data = true;
            Debug.Log("Game Over!");
        }

    }
}
