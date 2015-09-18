using UnityEngine;
using System.Collections;
using System;

public class ChangeDirection : MonoBehaviour {

    private GameObject ball;
    
    void Awake()
    {
        ball = GameObject.Find("Ball");
    }
	
    void OnTriggerEnter2D()
    {
        ball.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,10);
        Destroy(ball.GetComponent<ShootLogicV3>());
        ball.AddComponent<ShootLogicV3>();
    }
    
}
