using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float xRange,spawnZ;
    public float startDelay,spawnInterval;
    
    private Quaternion animalRotation;
    private Vector3 animalPosition;
    
    void Start()
    {
        animalRotation.Set(0,-180,0,0);
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        animalPosition.Set(Random.Range(-xRange,xRange),0,spawnZ);
        Instantiate(animalPrefabs[Random.Range(0,animalPrefabs.Length)], animalPosition, animalRotation);
    }
}
