﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    private float maxForce = 14;
    private float minForce = 8;
    private float maxTorque = 3;
    private float xRange = 6;
    private float ySpawn = 0;
    private GameManager gameManager; 


    public int pointValue;
    public ParticleSystem explosionParticle;


    private Rigidbody targetRigidbody;
    private Vector3 randomForce, randomPosition, randomTorque;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRigidbody = GetComponent<Rigidbody>();
        randomForce.Set(0f,Random.Range(minForce,maxForce),0f);
        randomTorque.Set(Random.Range(-maxTorque,maxTorque),Random.Range(-maxTorque,maxTorque),Random.Range(-maxTorque,maxTorque));
        randomPosition.Set(Random.Range(-xRange,xRange),ySpawn,0f);
        targetRigidbody.AddTorque(randomTorque, ForceMode.Impulse);
        targetRigidbody.AddForce(randomForce, ForceMode.Impulse);
        transform.position = randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if(!gameManager.gameOver)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            if (pointValue > 0 && gameManager.strikes > 0)
            {
                gameManager.strikes -= 1;
                Debug.Log(gameManager.strikes);
            }
            if (pointValue < 0)
            {
                gameManager.strikes += 1;
                Debug.Log(gameManager.strikes);
            }
            if (gameManager.score <= 0)
            {
                gameManager.GameOver();
            }
            Instantiate(explosionParticle,transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        Destroy(gameObject);
        if(!gameManager.gameOver)
        {
            if (pointValue > 0)
            {
                gameManager.UpdateScore(-10);
                gameManager.strikes += 1;
                Debug.Log(gameManager.strikes);
            }
            if (gameManager.strikes >= (4-gameManager.difficulty))
            {
                gameManager.GameOver();
            }
            if (gameManager.score <= 0)
            {
                gameManager.GameOver();
            }
        }
    }
}
