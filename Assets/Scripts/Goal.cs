using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    private LevelScript level;
    private BallScript ball;

    void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<BallScript>();
        level = GameObject.Find("Level").GetComponent<LevelScript>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (ball.getAmountOfHits() >= level.getMinHitRule())
        {
            PlayerPrefs.SetInt("Level", Application.loadedLevel);
            level.LevelComplete();
        }
        else
        {
            level.LevelFailed();
        }
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
