using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    public delegate void ScoreUpdatedDelegate(int newScore);
    public static event ScoreUpdatedDelegate OnScoreUpdated;
    public TextMeshProUGUI scoreTextGo;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }


    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", score); // Save the score to PlayerPrefs
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
        scoreTextGo.text = "Score: " + score.ToString();
    }
}