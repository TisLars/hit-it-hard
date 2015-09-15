using UnityEngine;

public class BallScript : MonoBehaviour {

    private LevelScript level;
    private GameManagerScript manager;
    private CameraShakeScript camShake;
    private Camera cam;
    private Color current;
    private Color bgColor;
    
    private int amountOfHits;

    private GameObject LosingScreen;

    void Awake () {
        level = GameObject.Find("Level").GetComponent<LevelScript>();
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        camShake = GameObject.Find("GameManager").GetComponent<CameraShakeScript>();
        cam = Camera.main;

        amountOfHits = 0;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.Contains("Wall"))
        {
            if(amountOfHits >= level.maximumHitRule && level.maximumHitRule != 0)
            {
                KillIt();
            }
            else
            {
                if (coll.relativeVelocity.magnitude > 13)
                {
                    camShake.Shake();
                }
                HitWall();
            }
        }
    }

    void KillIt()
    {
        Destroy(gameObject);
        level.LevelFailed();
    }

    private void ChangeBackgroundColor()
    {
        current = new Color(Random.value, Random.value, Random.value);
        bgColor = new Color(Random.value, Random.value, Random.value);
        cam.backgroundColor = Color.Lerp(current, bgColor, 5.0f);
    }

    public int getAmountOfHits()
    {
        return amountOfHits;
    }

    void HitWall()
    {
        //ChangeBackgroundColor();
        if (GameObject.Find("GameManager"))
        {
            manager.IncreaseScoreOnHit();
        }
        amountOfHits++;
    }
}
