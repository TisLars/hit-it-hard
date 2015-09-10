using UnityEngine;
using System.Collections;
using System;

public class SessionScoreScript : MonoBehaviour {

    public static SessionScoreScript session;

    public BallScript ball;
    int totalHits;

    void Awake()
    {
        if (!session)
        {
            session = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScoreOnHit()
    {
        totalHits = ball.getAmountOfHits();
    }

    public int getScore()
    {
        return totalHits;
    }
}
