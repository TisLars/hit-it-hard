using UnityEngine;
using System.Collections;

public class RopeObjectScript : MonoBehaviour {

    GameObject ball;
    ShootLogicV3 shoot;
    private bool hasPlayer = false;
    float originGravityScale;

    private float phase, time;
    public float timeToSwing = 1f;
    public float angle = 35f;
    
    private bool isLerping = false;
    private float animatorStartSpeed;
    private float lerpDuration = 0.25f;
    private float lerpStartTime;

    private Vector3 endPos;
    private Vector3 startPos;

    private bool isShot = false;
    

    void Update () {
        time = time + Time.deltaTime;
        phase = Mathf.Sin(time / timeToSwing);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, phase * angle));

        if (hasPlayer)
        {

            if (ball.GetComponent<ShootLogicV3>().getIsClicking())
            {
                LineRenderer line = ball.GetComponent<LineRenderer>();
                line.SetPosition(0, ball.transform.position);
                shoot.Dragging();
                //line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            if (Input.GetButtonUp("Fire1"))
            {
                isLerping = false;
                hasPlayer = false;
                isShot = true;
                ball.GetComponent<Rigidbody2D>().gravityScale = originGravityScale;
                ball.transform.parent = GameObject.Find("BallHolder").transform;
            }
        }
        
        if (isLerping)
        {
            float timeSinceLerpStart = Time.time - lerpStartTime;
            float amountCompleteLerp = timeSinceLerpStart / lerpDuration;

            ball.transform.position = Vector3.Lerp(startPos, endPos, amountCompleteLerp);

            if (amountCompleteLerp >= 1f)
            {
                isLerping = false;
            }
        }
    }

    void StartLerping()
    {
        lerpStartTime = Time.time;

        startPos = ball.transform.position;
        endPos = transform.position;
        endPos.y -= 3.3f;
        endPos.x = endPos.x - 0.5f;
        
        isLerping = true;
    }
    
    void OnTriggerExit2D(Collider2D coll)
    {
        isShot = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(isShot == false)
        {
            ball = GameObject.Find(coll.name);
            originGravityScale = ball.GetComponent<Rigidbody2D>().gravityScale;

            ball.GetComponent<Rigidbody2D>().gravityScale = 0;
            Destroy(coll.GetComponent<ShootLogicV3>());
            coll.gameObject.AddComponent<ShootLogicV3>();
            shoot = coll.GetComponent<ShootLogicV3>();

            coll.transform.parent = gameObject.transform;
            coll.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            coll.GetComponent<Rigidbody2D>().angularVelocity = 0;

            hasPlayer = true;

            StartLerping();
        }
    }
}
