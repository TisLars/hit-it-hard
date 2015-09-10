using UnityEngine;
using System.Collections;
using System;

public class SessionScoreScript : MonoBehaviour {

    public static SessionScoreScript session;

    private BallScript ball = null;

    int totalHits = 0;

    void Awake()
    {
        if(GameObject.Find("Ball"))
        {
            ball = GameObject.Find("Ball").GetComponent<BallScript>();
        } 

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
        totalHits++;
    }

    public int getScore()
    {    
        return totalHits;
    }

    public void setScore(int value)
    {
        totalHits = value;
    }
}
