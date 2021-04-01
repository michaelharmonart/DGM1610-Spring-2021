using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public float enemySpawnRange;
    public float initialDelay, minDelay,maxDelay;
    public int enemyCount = 0;
    
    private int spawnNumber = 1;
    private Vector3 spawnLocation;
    private Quaternion spawnRotation;
    
    void Start()
    {
        spawnRotation.Set(0f,0f,0f,0f);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
                SpawnWave(spawnNumber);
                spawnNumber += Random.Range(1,5);
        }
    }

    void SpawnWave(int number)
    {
        for (int i = 0; i < number; i++)
        {
            spawnLocation.Set(Random.Range(-enemySpawnRange,enemySpawnRange),0f,Random.Range(-enemySpawnRange,enemySpawnRange));
            SpawnEnemy(enemies[Random.Range(0,enemies.Length)], spawnLocation, spawnRotation);
        }
        spawnLocation.Set(Random.Range(-enemySpawnRange,enemySpawnRange),0f,Random.Range(-enemySpawnRange,enemySpawnRange));
        Instantiate(powerup, spawnLocation, spawnRotation);
    }

    void SpawnEnemy(GameObject enemy, Vector3 position, Quaternion rotation)
    {
        Instantiate(enemy, position, rotation);
    }
}
