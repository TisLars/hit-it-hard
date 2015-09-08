using UnityEngine;
using System.Collections;

public class ShootLogicV2 : MonoBehaviour {
    
    public float maxDrag = 2.0f;

    private bool isClicked;

    private Vector2 prevVelocity;
    private Vector3 ballStartPosition;

    private Transform dragToShootStartPosition;
    private Transform dragToShootDestinationPosition;

    private SpringJoint2D dragToShoot;
    private LineRenderer lineRenderer;

    private float dist;
    private float maxDragSqr;

    private Ray rayToMouse;


    void Awake()
    {
        ballStartPosition = transform.position; // Set the ball position
        dragToShoot = GetComponent<SpringJoint2D>();
        dragToShootStartPosition = dragToShoot.connectedBody.transform; // Set dragtoshoot start position.
    }

    // Use this for initialization
    void Start ()
    {
        lineRenderer = dragToShoot.connectedBody.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, lineRenderer.transform.position);
        rayToMouse = new Ray(dragToShootStartPosition.position, Vector3.zero);  

        //dist = Vector3.Distance(dragToShootStartPosition.position, dragToShootDestinationPosition.position);

        maxDragSqr = maxDrag * maxDrag;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isClicked)
        {
            Dragging();
        }

        if (dragToShoot != null)
        {
            if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                //Shoot();

                Destroy(dragToShoot);
                Destroy(GameObject.Find("Startshoot"));

                GetComponent<Rigidbody2D>().velocity = prevVelocity;
            }

            if (!isClicked)
            {
                prevVelocity = GetComponent<Rigidbody2D>().velocity;
            }
        }

    }

    void OnMouseDown()
    {
        dragToShoot.enabled = false; 
        isClicked = true;
    }

    void OnMouseUp()
    {
        dragToShoot.enabled = true;
        isClicked = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPoint.z = 0f; // Set Z to 0 -> we dont need this in a 2D game.
        //dragToShootStartPosition.transform.position = mouseWorldPoint;
        
        lineRenderer.SetPosition(1, mouseWorldPoint);
    }

    void Shoot()
    {
        //Debug.Log(Input.mousePosition);
        
        Ray moveit = new Ray(ballStartPosition, Vector3.zero);
        Vector2 startPointToBall = ballStartPosition - Input.mousePosition;
        moveit.direction = startPointToBall;

        //GetComponent<Rigidbody2D>().AddForce((transform.position - Input.mousePosition).normalized * 3.0f);

    }
}
