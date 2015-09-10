using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuScript : MonoBehaviour
{
    private SessionScoreScript score;

    public Button returnButton;
    private Text scoreText;

    void Start()
    {
        returnButton = returnButton.GetComponent<Button>();
        scoreText = scoreText.GetComponent<Text>();
    }

    void SetScoreText()
    {
        scoreText.text = score.getScore().ToString();
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
