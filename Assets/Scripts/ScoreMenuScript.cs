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

        if(GameObject.Find("SessionScore"))
        {
            score = GameObject.Find("SessionScore").GetComponent<SessionScoreScript>();    
        }

        SetScoreText();
    }

    void SetScoreText()
    {
        if(score)
        {
            scoreText.text = "Total wallhits: " + score.getScore();
            score.setScore(0);
        }
        scoreText.text += "\nThanks for playing!\n More Content Coming Soon!";
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
