using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class CookiePowerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        coll.GetComponent<BallScript>().setAmountOfBoost(coll.GetComponent<BallScript>().getAmountOfBoost() + 1);
        Destroy(gameObject);

        Social.ReportProgress("CgkIrNyjyeIVEAIQBg", 100.0f, (bool success) => {
        });
    }
}
