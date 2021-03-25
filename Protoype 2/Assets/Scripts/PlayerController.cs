using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed,xRange;

    private float inputHorizontal, inputVertical;

    void Start()
    {
        
    }

    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
        player.transform.Translate(inputHorizontal * speed * Time.deltaTime,0,0);
        if (player.transform.position.x > xRange)
        {
            player.transform.Translate(xRange - player.transform.position.x,0,0);
        }
        if (player.transform.position.x < -xRange)
        {
            player.transform.Translate(-xRange - player.transform.position.x,0,0);
        }
    }
}
