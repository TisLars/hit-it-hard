using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class ScoreMenuScript : MonoBehaviour
{
    private GameManagerScript manager = null;
    private TimeAttackSessionScript timeAttackSessionScript = null;
    private GameObject timeAttackSession;

    public Button returnButton;
    private Text scoreText;
    private Text timerText;

    int userScore;

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
            userScore = manager.getScore();
            scoreText.text = "Total wallhits: " + userScore;
            manager.setScore(0);
        }
    }

    void SetTimerText()
    {
         timerText.text = "Time: " + System.String.Format("{0:0}:{1:00.000}", Mathf.Floor(timeAttackSessionScript.getTime()/60), timeAttackSessionScript.getTime() % 60);
    }

    public void ShareScore()
    {
        if (FB.IsLoggedIn)
        {
            System.Uri pictureUri = new System.Uri("http://i.imgur.com/TOkHft1.png");
            //System.Uri linkUri = new System.Uri("https://play.google.com/store/apps/details?id=com.maildev.slamithard");
            FB.FeedShare(
                    linkName: "Checkout Slamster on Android!",
                    linkCaption: "I completed with " + userScore + " wall hits! Can you beat it?",
                    picture: pictureUri
                    );
        }

    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
