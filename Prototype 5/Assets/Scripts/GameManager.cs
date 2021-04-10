using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private float spawnRate = 1;
    public int score;
    public float strikes;
    public bool gameOver;
    public int difficulty;

    void Start()
    {
        
    }

    public void StartGame(int passedDifficulty)
    {
        restartButton.gameObject.SetActive(false);
        difficulty = passedDifficulty;
        gameOver = false;
        strikes = 0;
        gameOverText.gameObject.SetActive(false);
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
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate/(1+(difficulty/3)));
            Instantiate(targets[Random.Range(0,targets.Length)]);
        }
    }

    public void UpdateScore (int intToAdd)
    {
        score += intToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameOver = true;
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        gameOver = false;
        restartButton.gameObject.SetActive(false);
        strikes = 0;
        gameOverText.gameObject.SetActive(false);
        score = 0;
        StartCoroutine("SpawnTarget");
        scoreText.text = "Score: " + score;
    }
}
