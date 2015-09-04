using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	void Awake () {
        Invoke("HitBall", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void HitBall()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(20f, 5f), ForceMode2D.Impulse);
    }
}
