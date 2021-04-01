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
        player = GameObject.Find("Player");
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDirection = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(movementDirection * speed);
        if(transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
}

