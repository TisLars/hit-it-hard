using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    GameObject ball;
    GameObject cam;

    private float distance = 10;

    void Start()
    {
        ball = GameObject.Find("Ball");
        cam = GameObject.Find("Render");
    }

    void Update()
    {
        cam.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z - distance);
    }
}
