using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private int highScore;

    public delegate void ScoreUpdatedDelegate(int newScore);
    public static event ScoreUpdatedDelegate OnScoreUpdated;

    private const string HIGH_SCORE_KEY = "HighScore";

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
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

    private void SaveScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        }
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.Save();

        Debug.Log("High Score: " + highScore);
        Debug.Log("Last Score: " + score);
    }


    public void GameOver()
    {
        SaveScore();
    }
}
