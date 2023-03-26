using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0); // Get the score from PlayerPrefs
        scoreText.text = "Score: " + score.ToString(); // Update the score text
    }
}