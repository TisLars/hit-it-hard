using UnityEngine;
using System.Collections;

public class EyeFollowScript : MonoBehaviour {

    private GameObject ball;

    private Vector3 startPos;

    private float maxLeft;
    private float maxRight;


	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
        startPos = transform.position;
        
        maxLeft = startPos.x - 0.1f;
        maxRight = startPos.x + 0.1f;
    }
	
	// Update is called once per frame
	void Update () {

        if (ball.GetComponent<ShootLogicV3>().isShot)
        {
            transform.position = Vector3.MoveTowards(startPos, ball.transform.position, 10f * Time.deltaTime);
        }

	}
}
