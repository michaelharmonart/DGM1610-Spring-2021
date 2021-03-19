using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraTarget;
    public float cameraMoveSpeed;
		private Vector3 cameraOffset,tempOffset;
    // Start is called before the first frame update
    void Start()
    {
				cameraOffset = transform.position - cameraTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempOffset = transform.position - (cameraTarget.transform.position + cameraOffset);
				transform.position = transform.position - (tempOffset * cameraMoveSpeed * Time.deltaTime);
    }
}
