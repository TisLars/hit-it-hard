using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
    private bool isBoosted;

    private GameObject LosingScreen;
    private ShootLogicV3 shootLogic;

    private Animator anim;
    private bool animating = false;

    private Sprite startSprite;



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
        if(GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
        else
        {
            anim = gameObject.AddComponent<Animator>();
        }



        startSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()   
    {
        if (Input.GetButtonDown("Fire1") && shootLogic.isShot == true && isBoosted == false)
        {
            isBoosted = true;
            StartCoroutine(ActivateBoost());
        }

        if(animating)
        {
            Debug.Log(startSprite);
            if(GetComponent<SpriteRenderer>().sprite.name == "stap3")
            {
                Debug.Log("Jahoor");
                GetComponent<Animator>().runtimeAnimatorController = null;
                GetComponent<SpriteRenderer>().sprite = startSprite;
                Debug.Log("NWOEGHWOEGIHWEGOIWHEGOIW");


                animating = false;
                
            }

                

            //  Debug.Log(anim.GetCurrentAnimatorStateInfo(0).length);
            //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            //if (anim.GetCurrentAnimatorStateInfo(0).length)
            //{
                //anim.runtimeAnimatorController = null;
              //  animating = false;
            //}
        }

    }

    IEnumerator ActivateBoost()
    {
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<Rigidbody2D>().velocity *= 2;
        yield return new WaitForSeconds(1);
        GetComponent<TrailRenderer>().enabled = false;
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
                HitWall(coll);
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


    void HitWall(Collision2D coll)
    {
        // Build check here on what side the Hamster hits the wall.
        string loadResource = "Animations/HitWall/"; 

        // Get the angle
        float angle = transform.eulerAngles.z;
        List<int> list = new List<int> { 0, 45, 90, 135, 180, 225, 315 };
        int closest = list.Aggregate((x, y) => Math.Abs(x - angle) < Math.Abs(y - angle) ? x : y);

        Debug.Log(angle);
        
        /*
            Bepaal welke map er gekozen moet worden voor raken.
            Bepaal dit op de collider van chico waar deze geraakt wordt vanuit het center point van chico
            Boven: +Y
            Onder: -Y
            Links: -X
            Rechts: +X
        */

        loadResource += "bot_to_top/"+closest+"/Ball";

        //if(angle <= 45)
        //{
        //    loadResource += "bot_to_top/0/Ball";
        //}
        //else if(angle > 45 && angle <= 90)
        //{
        //    loadResource += "bot_to_top/45/Ball";
        //}
        //else if (angle > 90 && angle <= 135)
        //{
        //    loadResource += "bot_to_top/90/Ball";
        //}
        //else if (angle > 135 && angle <= 180)
        //{
        //    loadResource += "bot_to_top/135/Ball";
        //}
        //else if (angle > 180 && angle <= 225)
        //{
        //    loadResource += "bot_to_top/180/Ball";
        //}
        //else if (angle > 225 && angle <= 315)
        //{
        //    loadResource += "bot_to_top/225/Ball";
        //}
        //else if (angle > 315)
        //{
        //    loadResource += "bot_to_top/315/Ball";
        //}

        anim.runtimeAnimatorController = Resources.Load(loadResource) as RuntimeAnimatorController;

        animating = true;

        if (GameObject.Find("GameManager"))
        {
            manager.IncreaseScoreOnHit();
        }
        amountOfHits++;
    }

    void HitFromTop()
    {
        Debug.Log("HitFromTop");
    }
    void HitFromBottom()
    {
        Debug.Log("HitFromBottom");
    }
    void HitFromRight()
    {
        Debug.Log("HitFromRight");
    }
    void HitFromLeft()
    {
        Debug.Log("HitFromLeft");
    }
}
