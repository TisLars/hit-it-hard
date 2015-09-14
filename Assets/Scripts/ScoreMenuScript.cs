using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuScript : MonoBehaviour
{
    private SessionScoreScript score = null;
    private TimeAttackSessionScript timeAttackSessionScript = null;
    private GameObject timeAttackSession;

    public Button returnButton;
    private Text scoreText;
    private Text timerText;

    void Start()
    {
        returnButton = returnButton.GetComponent<Button>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();

        if (GameObject.Find("SessionScore"))
        {
            score = GameObject.Find("SessionScore").GetComponent<SessionScoreScript>();
            SetScoreText();
        }
        if (GameObject.Find("TimeAttackSession(Clone)"))
        {
            timeAttackSession = GameObject.Find("TimeAttackSession(Clone)");
            timeAttackSessionScript = GameObject.Find("TimeAttackSession(Clone)").GetComponent<TimeAttackSessionScript>();
            SetTimerText();
            Destroy(timeAttackSession);
        }

    }

    void SetScoreText()
    {
        if(score)
        {
            scoreText.text = "Total wallhits: " + score.getScore();
            score.setScore(0);
        }
    }

    void SetTimerText()
    {
        if (timeAttackSessionScript.getTime() < 60)
            timerText.text = "Completed in " + System.String.Format("{0:0.000}", timeAttackSessionScript.getTime()) + " seconds";
        else if (timeAttackSessionScript.getTime() < 120)
            timerText.text = "Completed in " + System.String.Format("{0:0.000}", timeAttackSessionScript.getTime()) + " minute";
        else if (timeAttackSessionScript.getTime() >= 120)
            timerText.text = "Completed in " + System.String.Format("{0:0.000}", timeAttackSessionScript.getTime()) + " minutes";
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
