using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float rechargeTime = 0.5f;

    private float recharge;

    // Update is called once per frame
    void Update()
    {
        recharge -= Time.deltaTime; 
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && recharge <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            recharge = rechargeTime;
        }
    }
}
