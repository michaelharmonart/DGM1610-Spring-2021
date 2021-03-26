using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector3 spawnLocation;
    public float startDelay,repeatRate;
    public Quaternion objectRotation;
    public BoolData gameOver;
    
    void Start()
    {
        objectRotation.Set(0f,0f,0f,0f);
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!gameOver.data){
            Instantiate(obstacles[Random.Range(0,obstacles.Length)], spawnLocation, objectRotation);
        }
    }
}
