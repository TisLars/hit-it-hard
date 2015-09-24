using UnityEngine;
using System.Collections;

public class RopeObjectScript : MonoBehaviour {

    GameObject ball;
    private bool hasPlayer = false;
    ShootLogicV3 shoot;

	void Update () {
        //TODO rotate rope between z:-35 z:35
        transform.Rotate(0, 0, 2 * Time.deltaTime);

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
