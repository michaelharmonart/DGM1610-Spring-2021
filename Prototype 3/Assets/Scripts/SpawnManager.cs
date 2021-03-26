using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector3 spawnLocation;
    public float startDelay,minRepeatRate,maxRepeatRate;
    public Quaternion objectRotation;
    public BoolData gameOver;
    private float spawnInterval = 1f,timer;

    void Start()
    {
        timer = startDelay;
        objectRotation.Set(0f,0f,0f,0f);
        //InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    void Update()
    {
        if (timer <= 0)
        {
            SpawnObstacle();
            timer = spawnInterval;
        }
        timer -= Time.deltaTime;
    }

    void SpawnObstacle()
    {
        if (!gameOver.data){
            Instantiate(obstacles[Random.Range(0,obstacles.Length)], spawnLocation, objectRotation);
            spawnInterval = Random.Range(minRepeatRate,maxRepeatRate);
        }
    }
}
