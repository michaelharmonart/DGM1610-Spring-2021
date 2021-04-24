using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public IntData score;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+score.value;
    }
}
