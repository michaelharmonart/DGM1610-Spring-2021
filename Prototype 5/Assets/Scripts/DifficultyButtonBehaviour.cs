using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonBehaviour : MonoBehaviour
{
    private Button difficultyButton;
    private GameManager gameManager;

    public int difficulty;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        GameObject.Find("Title Screen").SetActive(false);
        gameManager.StartGame(difficulty);
        Debug.Log(gameObject.name);
    }
}
