using UnityEngine;
using System.Collections;
using System;

public class ChangeDirection : MonoBehaviour {

    // Privates
    private Animator animator;
    private GameObject ball;
    private Vector3 endPos;
    private Vector3 startPos;

    private bool isLerping =  false;
    private bool hamsterInWheel = false;
    private float animatorStartSpeed;
    private float lerpDuration = 0.5f;
    private float lerpStartTime;

    private int turnDirection;
    private const int LEFT = 0;
    private const int RIGHT = 1;
   

    // Publics
    public float animatorSpeed = 5;
    
    void Awake()
    {
        ball = GameObject.Find("Ball");
        animator = GetComponent<Animator>();
        animatorStartSpeed = animator.speed;
        animator.speed = 0; // Stop animation.
    }
	
    void OnTriggerEnter2D()
    {
        StartLerping();
        StartAnimator(); // Start animation.
        hamsterInWheel = true;
    }

    void RotateHamster()
    {
        if(turnDirection == RIGHT)
        {
            ball.transform.Rotate(0, 0, (0 - (Time.deltaTime * 500)));
        }
        else
        {
            ball.transform.Rotate(0, 0, Time.deltaTime * 500);
        }
       
    }

    void StartAnimator()
    {
        // If hit from the right, animate the wheel left
        if(transform.InverseTransformPoint(ball.transform.position).x > 0) {
            animator.runtimeAnimatorController = Resources.Load("Animations/Wheel/WheelTurnLeft") as RuntimeAnimatorController;
            turnDirection = LEFT;
        }
        else
        {
            animator.runtimeAnimatorController = Resources.Load("Animations/Wheel/WheelTurnRight") as RuntimeAnimatorController;
            turnDirection = RIGHT;
        }

        animator.speed = animatorStartSpeed * animatorSpeed;
    }

    void HitBall()
    {
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(20f, 5f), ForceMode2D.Impulse);
    }

    void StartLerping()
    {
        ball.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 10);

        lerpStartTime = Time.time;

        startPos = ball.transform.position;
        endPos = transform.position;
        
        isLerping = true;
    }

    void Update()
    {
        if(isLerping)
        {
            float timeSinceLerpStart = Time.time - lerpStartTime;
            float amountCompleteLerp = timeSinceLerpStart / lerpDuration;

            ball.transform.position = Vector3.Lerp(startPos, endPos, amountCompleteLerp);

            if(amountCompleteLerp >= 1f)
            {
                isLerping = false;
            }
        }


        //
        if(hamsterInWheel)
        {
            RotateHamster();
            foreach (Touch t in Input.touches)
            {
                if(t.phase == TouchPhase.Ended)
                {
                    HitBall();
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                HitBall();
            }

        }
        //
        
    }

   
    
}
