using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private Rigidbody enemyRigidbody;
    private Vector3 movementDirection;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDirection = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(movementDirection * speed);
    }
}

