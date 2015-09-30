using UnityEngine;
using System.Collections;

public class CookiePowerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        coll.GetComponent<BallScript>().setAmountOfBoost(coll.GetComponent<BallScript>().getAmountOfBoost() + 1);
        Destroy(gameObject);
    }
}
