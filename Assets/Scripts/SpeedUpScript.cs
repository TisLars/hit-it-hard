using UnityEngine;
using System.Collections;

public enum SpeedUpDirections
{
    LEFT, RIGHT, UP, DOWN
}

public class SpeedUpScript : MonoBehaviour {

    public SmackItDirections direction;
    public float force;

    private GameObject ball;

    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    void OnTriggerEnter2D()
    {
        
        if (direction.ToString() == "LEFT")
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0), ForceMode2D.Impulse);
        }
        if (direction.ToString() == "RIGHT")
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        }
        if (direction.ToString() == "UP")
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
        if (direction.ToString() == "DOWN")
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force), ForceMode2D.Impulse);
        }
    }
	
}
