using UnityEngine;
using System.Collections;

public enum SmackItDirections
{
    LEFT, RIGHT, UP, DOWN
}

public class Smackit : MonoBehaviour {

    public SmackItDirections direction;
    public float force;

    public int secondsToWaitForLaunch;


    IEnumerator launchBall()
    {
        yield return new WaitForSeconds(secondsToWaitForLaunch);
    
        GetComponent<Rigidbody2D>().isKinematic = false;

        if (direction.ToString() == "LEFT")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0), ForceMode2D.Impulse);
        }
        if (direction.ToString() == "RIGHT")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        }
        if (direction.ToString() == "UP")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
        if (direction.ToString() == "DOWN")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force), ForceMode2D.Impulse);
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(launchBall());
    }
	
}
