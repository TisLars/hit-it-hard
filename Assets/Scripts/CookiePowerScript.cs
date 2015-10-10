using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class CookiePowerScript : MonoBehaviour {

    private Object tapIndicator;

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.GetComponent<BallScript>().setAmountOfBoost(coll.GetComponent<BallScript>().getAmountOfBoost() + 1);
        Destroy(gameObject);
        tapIndicator = Instantiate((GameObject)Resources.Load("TapIndicator"), new Vector3(transform.position.x + 8, 0f), Quaternion.identity);
        Social.ReportProgress("CgkIrNyjyeIVEAIQBg", 100.0f, (bool success) => {
        });
    }
}
