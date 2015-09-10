using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuScript : MonoBehaviour
{
    private SessionScoreScript score = null;

    public Button returnButton;
    private Text scoreText;

    void Start()
    {
        returnButton = returnButton.GetComponent<Button>();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score = GameObject.Find("SessionScore").GetComponent<SessionScoreScript>();
        
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Total wallhits: " + score.getScore();
        scoreText.text += "\nThanks for playing!\n More Content Soon!";
        score.setScore(0);
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
