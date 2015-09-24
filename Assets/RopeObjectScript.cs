using UnityEngine;
using System.Collections;

public class RopeObjectScript : MonoBehaviour {

    GameObject ball;
    ShootLogicV3 shoot;
    private bool hasPlayer = false;

    private float phase, time;
    private float period = 1f;
    private float angle = 35f;

	void Update () {
        time = time + Time.deltaTime;
        phase = Mathf.Sin(time / period);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, phase * angle));

        if (hasPlayer)
        {
            if (ball.GetComponent<ShootLogicV3>().getIsClicking())
            {
                LineRenderer line = ball.GetComponent<LineRenderer>();
                line.SetPosition(0, ball.transform.position);
                line.SetPosition(1, shoot.getMouseWorldPoint());
            }
            if (Input.GetButtonUp("Fire1"))
            {
                hasPlayer = false;
                ball.transform.parent = GameObject.Find("BallHolder").transform;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Ball")
        {
            ball = GameObject.Find(coll.name);
            Destroy(coll.GetComponent<ShootLogicV3>());
            coll.gameObject.AddComponent<ShootLogicV3>();
            shoot = coll.GetComponent<ShootLogicV3>();

            coll.transform.parent = gameObject.transform;
            coll.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            coll.GetComponent<Rigidbody2D>().angularVelocity = 0;

            hasPlayer = true;
        }
    }
}
