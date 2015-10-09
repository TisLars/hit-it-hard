using UnityEngine;
using System.Collections;
using System;

public class Wheel : MonoBehaviour {

    // Privates
    private Animator animator;
    private GameObject ball;
    private UnityEngine.Object tapIndicator;
    private Vector3 endPos;
    private Vector3 startPos;

    private bool isLerping =  false;
    private bool hamsterInWheel = false;
    private float animatorStartSpeed;
    private float lerpDuration = 0.25f;
    private float lerpStartTime;

    private float originGravityScale;

    private int turnDirection;
    private const int LEFT = 0;
    private const int RIGHT = 1;
    
    private GameObject circleEffectOnTouch;
    private LineRenderer line;
    private bool slammed = false;
    private float slamOffsetStart = -1;

    // Publics
    public float animatorSpeed = 5;
    public float shootAcceleration = 3f;

    public float WheelTouchEffectRotateSpeed = 0.1f;

    void Awake()
    { 
        ball = GameObject.Find("Ball");
        animator = GetComponent<Animator>();
        animatorStartSpeed = animator.speed;
        animator.speed = 0; // Stop animation.

        if(GameObject.Find("WheelTouchEffect"))
        {
            circleEffectOnTouch = GameObject.Find("WheelTouchEffect");
            line = circleEffectOnTouch.GetComponent<LineRenderer>();
            line.material.mainTextureOffset = new Vector2(slamOffsetStart, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        StartLerping();
        StartAnimator(); // Start animation.
        originGravityScale = coll.GetComponent<Rigidbody2D>().gravityScale;
        coll.GetComponent<Rigidbody2D>().gravityScale = 0;
        tapIndicator = Instantiate((GameObject)Resources.Load("TapIndicator"), new Vector3(8, 0), transform.rotation);
        hamsterInWheel = true;
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

    void SlamHamster()
    {
        Vector3 inputPosition = Input.mousePosition;
        Vector3 wheelPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (inputPosition - wheelPosition).normalized;
        Destroy(tapIndicator);
        
        ball.GetComponent<Rigidbody2D>().AddForce(dir * (500f * shootAcceleration)); // Shoot it;
        
        slammed = true;

        // Stop the rotation;
        hamsterInWheel = false; //  We are not in the wheel no more.
        ball.GetComponent<Rigidbody2D>().gravityScale = originGravityScale;
        animator.speed = 0;
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
            //RotateHamster(); // Rotate the hamster with the direction the wheel is spinning.

            foreach (Touch t in Input.touches)
            {
                if(t.phase == TouchPhase.Ended)
                {
                    if (line)
                    {
                        Vector3 touchPos = t.position;
                        line.transform.position = Camera.main.ScreenToWorldPoint(touchPos); // Get the cirle to the touchposition.
                        line.transform.position = new Vector3(line.transform.position.x, line.transform.position.y, 0); // Set the Z to 0. Else we dont see it in the scene
                    }
                    SlamHamster();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (line)
                {
                    line.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the cirle to the touchposition.
                    line.transform.position = new Vector3(line.transform.position.x, line.transform.position.y, 0); // Set the Z to 0. Else we dont see it in the scene
                }
                SlamHamster();
            }

        }

        // Apply the circle after touch effect with a linerenderer
        if(slammed)
        {
            float slamOffset = slamOffsetStart;
            if (slamOffset < 1f)
            {
                slamOffset += WheelTouchEffectRotateSpeed;
                line.material.mainTextureOffset = line.material.mainTextureOffset + new Vector2(WheelTouchEffectRotateSpeed, 0);
            }
            if(line.material.mainTextureOffset.x >= 1.1f)
            {
                slammed = false; // Reset the slammed boolean, otherwize it will keep on going.
                line.material.mainTextureOffset = new Vector2(slamOffsetStart, 0);
            }
        }

    }

   
    
}
