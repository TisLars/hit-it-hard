using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    private Vector2 camPosition;
    public float maxVertical;
    public float maxHorizontal;

    void Start()
    {
        camPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    void Update()
    {
        if (gameObject.transform.position.y > maxVertical)
            camPosition = new Vector2(gameObject.transform.position.x, maxVertical);
        if (gameObject.transform.position.x > maxHorizontal)
            camPosition = new Vector2(maxHorizontal, gameObject.transform.position.y);
    }
}
