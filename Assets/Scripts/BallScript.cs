using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private int amountOfBoost;
    private bool isBoosted;

    private GameObject LosingScreen;
    private ShootLogicV3 shootLogic;

    private Animator anim;
    private string animationdirection = "";
    private int animationAngle;


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

        anim = GetComponent<Animator>();
    }

    void Update()   
    {
        if (Input.GetButtonDown("Fire1") && shootLogic.isShot == true && isBoosted == false && amountOfBoost > 0)
        {
            isBoosted = true;
            StartCoroutine(ActivateBoost());
        }
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
                    HitWall(coll,true);
                }
                else
                {
                    HitWall(coll);
                }
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


    void HitWall(Collision2D coll, bool showimpact = false)
    {
        if(showimpact)
        {
            // Get the angle
            float angle = transform.eulerAngles.z;
            List<int> rotationAngles = new List<int> { 0, 90, 180, 270, 360 };
            int rotation = rotationAngles.Aggregate((x, y) => Math.Abs(x - angle) < Math.Abs(y - angle) ? x : y);

            if (coll.gameObject.name.Contains("Right"))
            {
                HitRight(rotation);
            }
            else if (coll.gameObject.name.Contains("Left"))
            {
                HitLeft(rotation);
            }
            else if (coll.gameObject.name.Contains("Top"))
            {
                HitTop(rotation);
            }
            else if (coll.gameObject.name.Contains("Bottom"))
            {
                HitBottom(rotation);
            }

            anim.speed = 1.75f;

            //animationAngle = hitAngle.Aggregate((x, y) => Math.Abs(x - angle) < Math.Abs(y - angle) ? x : y);
            animationAngle = 45;

            anim.Play(animationdirection + "_45");
        }
        
        
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
    
    void HitTop(int rotation)
    {
        switch (rotation)
        {
            case 90:
                // Right
                animationdirection = "left_right";
                break;
            case 180:
                // Bot
                animationdirection = "top_bot";
                break;
            case 270:
                // Left
                animationdirection = "right_left";
                break;
            case 0:
            case 360:
            default:
                // Top
                animationdirection = "bot_top";
                break;
        }

    }

    void HitBottom(int rotation)
    {
        switch (rotation)
        {
            case 90:
                // Right
                animationdirection = "right_left";
                break;
            case 180:
                // Bot
                animationdirection = "bot_top";
                break;
            case 270:
                // Left
                animationdirection = "left_right";
                break;
            case 0:
            case 360:
            default:
                // Top
                animationdirection = "top_bot";
                break;
        }


    }

    void HitRight(int rotation)
    {
        switch (rotation)
        {
            case 90:
                // Right
                animationdirection = "top_bot";
                break;
            case 180:
                // Bot
                animationdirection = "right_left";
                break;
            case 270:
                // Left
                animationdirection = "bot_top";
                break;
            case 0:
            case 360:
            default:
                // Top
                animationdirection = "left_right";
                break;
        }

    }

    void HitLeft(int rotation)
    {
        switch (rotation)
        {
            case 90:
                // Right
                animationdirection = "bot_top";
                break;
            case 180:
                // Bot
                animationdirection = "left_right";
                break;
            case 270:
                // Left
                animationdirection = "top_bot";
                break;
            case 0:
            case 360:
            default:
                // Top
                animationdirection = "right_left";
                break;
        }
    }
}
