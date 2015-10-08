using System;
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
            if (manager.getScore() < 15)
                Social.ReportProgress("CgkIrNyjyeIVEAIQBA", 100.0f, (bool success) => { });

            Social.ReportScore(manager.getScore(), "CgkIrNyjyeIVEAIQBw", (bool success) => { });
            manager.setScore(0);
        }
    }

    void SetTimerText()
    {
        // ACHIEVEMENT: time between 1:30 - 2:00
        if (timeAttackSessionScript.getTime() < 120)
            Social.ReportProgress("CgkIrNyjyeIVEAIQAQ", 100.0f, (bool success) => { });
        // ACHIEVEMENT: time below 1:30
        if (timeAttackSessionScript.getTime() < 90)
            Social.ReportProgress("CgkIrNyjyeIVEAIQAw", 100.0f, (bool success) => { });

        Debug.Log(Convert.ToInt64(timeAttackSessionScript.getTime()));

        Social.ReportScore(Convert.ToInt64(timeAttackSessionScript.getTime()), "CgkIrNyjyeIVEAIQAg", (bool success) => {
            // handle success or failure
        });

        float timeCalculated = timeAttackSessionScript.getTime() / 1000;
        timerText.text = "Time: " + System.String.Format("{0:0}:{1:00.000}", Mathf.Floor(timeCalculated / 60), timeCalculated % 60);
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
