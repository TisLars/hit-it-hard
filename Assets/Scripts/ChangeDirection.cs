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
    private float lerpDuration = 1f;
    private float lerpStartTime;
   

    // Publics
    public float animatorSpeed = 5;
    
    void Awake()
    {
        ball = GameObject.Find("Ball");

        animator = GetComponent<Animator>();
        animatorStartSpeed = animator.speed;
        animator.speed = 0;
    }
    
	
    void OnTriggerEnter2D()
    {
        StartLerping();
        StartAnimator();
        hamsterInWheel = true;
    }

    void StartAnimator()
    {
        // If hit from the right, animate the wheel left
        if(transform.InverseTransformPoint(ball.transform.position).x > 0) {
            
            animator.runtimeAnimatorController = Resources.Load("Animations/Wheel/WheelTurnLeft") as RuntimeAnimatorController;
        }
        else
        {
            animator.runtimeAnimatorController = Resources.Load("Animations/Wheel/WheelTurnRight") as RuntimeAnimatorController;
        }

        animator.speed = animatorStartSpeed * animatorSpeed;
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

        


    }
    
}
