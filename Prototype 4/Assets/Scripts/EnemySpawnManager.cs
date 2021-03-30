using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public float enemySpawnRange;
    public float initialDelay, minDelay,maxDelay;
    private float spawnTimer;
    private Vector3 spawnLocation;
    private Quaternion spawnRotation;
    
    void Start()
    {
        spawnTimer = initialDelay;
        spawnRotation.Set(0f,0f,0f,0f);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            spawnTimer = Random.Range(minDelay,maxDelay);
            spawnLocation.Set(Random.Range(-enemySpawnRange,enemySpawnRange),0f,Random.Range(-enemySpawnRange,enemySpawnRange));
            SpawnEnemy(enemies[Random.Range(0,enemies.Length)], spawnLocation, spawnRotation);
        }
    }

    void SpawnEnemy(GameObject enemy, Vector3 position, Quaternion rotation)
    {
        Instantiate(enemy, position, rotation);
    }
}
