using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public GameObject carBody;
    public float speed, turningSpeed;

    private float axisHorizontal,axisVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        axisHorizontal = Input.GetAxis("Horizontal");
        axisVertical = Input.GetAxis("Vertical");
        carBody.transform.Translate(0f,0f,axisVertical * speed * Time.deltaTime);
    }
}
