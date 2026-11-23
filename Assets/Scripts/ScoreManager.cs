
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score = 0;

    void Start()
    {
        scoreText.text = "SCORE: " + score;
    }

    public void AddScore(int points)
    {
        score += points;

        scoreText.text = "SCORE: " + score;
    }
}
