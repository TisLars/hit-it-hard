using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    private LevelScript level;
    private GameManagerScript manager;
    private CameraShakeScript camShake;
    private ParticleSystem particle;
    private Camera cam;
    private Color current;
    private Color bgColor;

    private System.Random rnd;
    public AudioClip[] audioClip;
    
    private int amountOfHits;
    private int amountOfBoost;
    private bool isBoosted;

    private GameObject LosingScreen;
    private ShootLogicV3 shootLogic;

    void Awake() {
        rnd = new System.Random();
        GetComponent<TrailRenderer>().enabled = false;
        isBoosted = false;
        level = GameObject.Find("Level").GetComponent<LevelScript>();
        shootLogic = GetComponent<ShootLogicV3>();
        if (GameObject.Find("GameManager"))
        {
            manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            camShake = GameObject.Find("GameManager").GetComponent<CameraShakeScript>();
            cam = Camera.main;
        }

        amountOfHits = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && shootLogic.isShot == true && isBoosted == false && amountOfBoost > 0)
        {
            isBoosted = true;
            StartCoroutine(ActivateBoost());
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel(Application.loadedLevel + 1);
    }

    IEnumerator ActivateBoost()
    {
        GetComponent<TrailRenderer>().enabled = true;
        PlaySound(2);
        GetComponent<Rigidbody2D>().velocity *= 2;
        amountOfBoost--;
        yield return new WaitForSeconds(1);
        GetComponent<TrailRenderer>().enabled = false;
        isBoosted = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        PlaySound(rnd.Next(0,2));
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

    void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = audioClip[clip];
        GetComponent<AudioSource>().Play();
    }

    void KillIt()
    {
        Destroy(gameObject);
        level.LevelFailed();
    }

    public int getAmountOfHits()
    {
        return amountOfHits;
    }

    void HitWall()
    {
        if (GameObject.Find("GameManager"))
        {
            manager.IncreaseScoreOnHit();
        }
        amountOfHits++;
    }

    public int getAmountOfBoost()
    {
        return amountOfBoost;
    }
    public void setAmountOfBoost(int value)
    {
        amountOfBoost = value;
    }
}
