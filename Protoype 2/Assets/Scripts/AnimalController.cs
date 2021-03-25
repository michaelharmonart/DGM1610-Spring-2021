using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float speed;
    public float bottomScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < -bottomScreen)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
