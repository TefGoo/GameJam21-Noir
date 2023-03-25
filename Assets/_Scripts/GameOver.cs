using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore");
        int highScore = PlayerPrefs.GetInt("HighScore");
        lastScoreText.text = "Last Score: " + lastScore.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
