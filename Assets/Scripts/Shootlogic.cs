using UnityEngine;
using System.Collections;

public class Shootlogic : MonoBehaviour
{

    public float maxStretch = 2.0f;
    public LineRenderer startFrom;
    private Transform startPoint;
    private SpringJoint2D spring;
    private bool clickedOn;
    private Vector2 prevVelocity;
    private Ray rayToMouse;
    private float maxStrechSqrd;
    private float circleRadius;
    private Ray leftStartPointToBall;
     
    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        startPoint = spring.connectedBody.transform;
    }

    // Use this for initialization
    void Start()
    {
        LineRendererSetup(); 
        rayToMouse = new Ray(startPoint.position, Vector3.zero);

        leftStartPointToBall = new Ray(startFrom.transform.position, Vector3.zero);

        maxStrechSqrd = maxStretch * maxStretch;

        CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
        circleRadius = circle.radius;
    }

    void LineRendererSetup()
    {
        startFrom = spring.connectedBody.GetComponent<LineRenderer>();
        startFrom.SetPosition(0, startFrom.transform.position);
    }

    void LineRendererUpdate()
    {
        Vector2 startPointToBall = transform.position - startFrom.transform.position;
        leftStartPointToBall.direction = startPointToBall;
        Vector3 holdPoint = leftStartPointToBall.GetPoint(startPointToBall.magnitude);
        startFrom.SetPosition(1, holdPoint);
    }

    // Update is called once per frame
    void Update()
    {

        if (clickedOn)
        {
            Dragging();
        }

        if (spring != null)
        {
            if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                Destroy(spring);
                Destroy(GameObject.Find("Startshoot"));
                GetComponent<Rigidbody2D>().velocity = prevVelocity;
            }

            if (!clickedOn)
            {
                prevVelocity = GetComponent<Rigidbody2D>().velocity;
            }
        }

    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }

    void OnMouseUp()
    {
        spring.enabled = true;
        clickedOn = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }


    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 catapultToMouse = mouseWorldPoint - startPoint.position;

        if (catapultToMouse.sqrMagnitude > maxStrechSqrd)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }

        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }

}
