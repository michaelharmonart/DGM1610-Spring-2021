using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    private float maxForce = 14;
    private float minForce = 8;
    private float maxTorque = 3;
    private float xRange = 6;
    private float ySpawn = 0;


    private Rigidbody targetRigidbody;
    private Vector3 randomForce, randomPosition, randomTorque;

    // Start is called before the first frame update
    void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
        randomForce.Set(0f,Random.Range(minForce,maxForce),0f);
        randomTorque.Set(Random.Range(-maxTorque,maxTorque),Random.Range(-maxTorque,maxTorque),Random.Range(-maxTorque,maxTorque));
        randomPosition.Set(Random.Range(-xRange,xRange),ySpawn,0f);
        targetRigidbody.AddTorque(randomTorque, ForceMode.Impulse);
        targetRigidbody.AddForce(randomForce, ForceMode.Impulse);
        transform.position = randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter (Collider other)
    {
        Destroy(gameObject);
    }
}
