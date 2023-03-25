using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    public delegate void ScoreUpdatedDelegate(int newScore);
    public static event ScoreUpdatedDelegate OnScoreUpdated;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
        if (OnScoreUpdated != null)
        {
            OnScoreUpdated(score);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

