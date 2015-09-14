using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    private GameObject exit;
    private GameObject ball;

    void Awake()
    {
        exit = GameObject.Find("TeleportExit");
        ball = GameObject.Find("Ball");
    }

    void OnTriggerEnter2D()
    {
        ball.transform.position = exit.transform.position;
    }


	
}
