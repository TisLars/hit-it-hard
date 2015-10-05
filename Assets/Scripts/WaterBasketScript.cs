using UnityEngine;
using System.Collections;

public class WaterBasketScript : MonoBehaviour {

    ParticleSystem ps;

    void Awake()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

	void OnTriggerEnter2D(Collider2D coll)
    {
        ps.Play();
        coll.GetComponent<Rigidbody2D>().velocity = new Vector2(coll.GetComponent<Rigidbody2D>().velocity.x / 2, 0f);
    }
}
