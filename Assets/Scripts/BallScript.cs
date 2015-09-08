using UnityEngine;

public class BallScript : MonoBehaviour {

    LevelScript level;
    private Camera cam;
    Color current;
    Color bgColor;

    int amountOfHits;

    GameObject LosingScreen;

    void Awake () {
        level = GameObject.Find("Level").GetComponent<LevelScript>();
        cam = Camera.main;
        amountOfHits = 0;
    }

    private void HitBall()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 20f), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name.Contains("Wall"))
        {
            if (amountOfHits < level.maximumHitRule)
            {
                ChangeBackgroundColor();
                amountOfHits++;
            } else
            {
                Destroy(gameObject);
                Debug.Log("You lose! > LevelFailed()");
                LevelFailed();
            }
        }
    }

    private void LevelFailed()
    {
        
    }

    private void ChangeBackgroundColor()
    {
        current = new Color(Random.value, Random.value, Random.value);
        bgColor = new Color(Random.value, Random.value, Random.value);
        cam.backgroundColor = Color.Lerp(current, bgColor, 5.0f);
    }
}
