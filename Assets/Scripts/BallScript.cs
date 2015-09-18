using UnityEngine;
using System;

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

    private GameObject LosingScreen;

    void Awake() {
        rnd = new System.Random();
        level = GameObject.Find("Level").GetComponent<LevelScript>();
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        camShake = GameObject.Find("GameManager").GetComponent<CameraShakeScript>();
        cam = Camera.main;

        amountOfHits = 0;
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
}
