using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float scrollWidth = 45;
    
    void Start()
    {
        startPos = transform.position;
        scrollWidth = GetComponent<BoxCollider>().size.x/2;
    }

    void Update()
    {
        if (transform.position.x <= startPos.x - scrollWidth)
        {
            transform.position = startPos;
        }
    }
}
