using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private void OnEnable()
    {
        ScoreManager.OnScoreUpdated += UpdateHighScore;
        UpdateHighScore(PlayerPrefs.GetInt("HighScore", 0));
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreUpdated -= UpdateHighScore;
    }

    private void UpdateHighScore(int newHighScore)
    {
        highScoreText.text = "High Score: " + newHighScore.ToString();
    }
}