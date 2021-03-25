using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed;
    public float topScreen;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > topScreen)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
