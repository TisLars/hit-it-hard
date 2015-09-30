using UnityEngine;
using System.Collections;

public class BounceObjectScript : MonoBehaviour {

    private float moveDirection;
    public float bounceForce = 0f;
    public float randomnessValue = 0f;
	
	void OnTriggerEnter2D(Collider2D coll)
    {
        moveDirection = Random.Range(-randomnessValue, randomnessValue);
        coll.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveDirection, bounceForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (bounceForce != 0 || moveDirection != 0)
        {
            moveDirection = Random.Range(-randomnessValue, randomnessValue);
            coll.rigidbody.AddForce(new Vector2(moveDirection, bounceForce), ForceMode2D.Impulse);
        }
    }
}
