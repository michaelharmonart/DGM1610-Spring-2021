using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject focalPoint, powerupIndicator;
    public bool hasPowerup = false;
    public float powerupStrength = 10f;
    public float powerupDuration = 5f;

    private Rigidbody playerRigidbody;
    private float horizontalInput, verticalInput;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerupDuration);
        powerupIndicator.SetActive(false);
        hasPowerup = false;
    }

}
