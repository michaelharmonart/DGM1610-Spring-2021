using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlaneController : MonoBehaviour
{
    public GameObject planeBody,planeProp;
    public float speed, turningSpeed;

    private float axisHorizontal,axisVertical;
    private Vector3 directionVector;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        axisHorizontal = Input.GetAxis("Horizontal");
        axisVertical = Input.GetAxis("Vertical");
        directionVector = planeBody.transform.rotation * Vector3.forward;
        planeBody.transform.Translate(directionVector);
    }
}
