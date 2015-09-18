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
        float zposBall = ball.transform.position.z;
        ball.transform.position = new Vector3(exit.transform.position.x, exit.transform.position.y, zposBall);
    }
    
}
