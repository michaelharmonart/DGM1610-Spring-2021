using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets;
    public TextMeshProUGUI scoreText;
    private float spawnRate = 1;
    private int score;

    void Start()
    {
        score = 0;
        StartCoroutine("SpawnTarget");
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(targets[Random.Range(0,targets.Length)]);
        }
    }

    public void updateScore (int intToAdd)
    {
        score += intToAdd;
        scoreText.text = "Score: " + score;
    }
}
