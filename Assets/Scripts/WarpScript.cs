using UnityEngine;
using System.Collections;

public class WarpScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject.Find("GameManager").GetComponent<GameManagerScript>().setWarpActivated(true);
        Application.LoadLevel(13);
    }
}
