using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    private LevelScript level;
    private BallScript ball;
    //private SessionScoreScript score;

    void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<BallScript>();
        level = GameObject.Find("Level").GetComponent<LevelScript>();
        //score = GameObject.Find("SessionScore").GetComponent<SessionScoreScript>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (ball.getAmountOfHits() >= level.getMinHitRule())
        {
            //score.IncreaseScoreOnHit();
            level.LevelComplete();
        }
        else
        {
            level.LevelFailed();
        }
        
    }
}
