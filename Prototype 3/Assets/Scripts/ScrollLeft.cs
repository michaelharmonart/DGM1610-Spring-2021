using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeft : MonoBehaviour
{
    public IntData scrollSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed.data * Time.deltaTime);
    }
}
