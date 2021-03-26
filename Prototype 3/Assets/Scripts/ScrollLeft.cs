using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeft : MonoBehaviour
{
    public IntData scrollSpeed;
    public BoolData gameOver;
    public float despawnX = -15;

    void Start()
    {
        
    }

    void Update()
    {
        if (!gameOver.data)
        {
            transform.Translate(Vector3.left * scrollSpeed.data * Time.deltaTime);
        }
        
        if (transform.position.x <= despawnX)
        {
            Destroy(gameObject);
        }
    }
}
