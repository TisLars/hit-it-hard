using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuScript : MonoBehaviour
{
    private GameManagerScript manager = null;
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

        if (GameObject.Find("GameManager"))
        {
            manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
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
        if(manager)
        {
            scoreText.text = "Total wallhits: " + manager.getScore();
            manager.setScore(0);
        }
    }

    void SetTimerText()
    {
        if (timeAttackSessionScript.getTime() < 60)
            timerText.text = "Time: " + System.String.Format("{0:0.000}", timeAttackSessionScript.getTime()) + " seconds";
        else if (timeAttackSessionScript.getTime() < 120)
            timerText.text = "Time: " + System.String.Format("{0:0.000}", timeAttackSessionScript.getTime()) + " minute";
        else if (timeAttackSessionScript.getTime() >= 120)
            timerText.text = "Time: " + System.String.Format("{0:0.000}", timeAttackSessionScript.getTime()) + " minutes";
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
