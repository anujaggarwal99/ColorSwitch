using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI endScoreText;
    public static int score;
    public static int highScore;
    void Update()
    {
        scoreText.text = "X" + score.ToString();
        if (Player.isAlive == false)
        {
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("highScore", highScore);
            }
            endScoreText.text = "SCORE : " + score.ToString();
            highScoreText.text = "HIGH SCORE : " + highScore;
        }
    }
}
