using UnityEngine;
using System.Collections;

public class WaterBasketScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        coll.GetComponent<Rigidbody2D>().velocity = new Vector2(coll.GetComponent<Rigidbody2D>().velocity.x, 0f);
    }
}
