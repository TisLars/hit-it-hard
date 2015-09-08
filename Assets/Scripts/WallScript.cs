using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

    private Camera cam;
    Color current;
    Color bgColor;
    int amountOfHits;

    void Awake()
    {
        cam = Camera.main;
        amountOfHits = 0;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        ChangeBackgroundColor();
        amountOfHits++;
        Debug.Log(amountOfHits);
    }

    private void ChangeBackgroundColor()
    {
        current = new Color(Random.value, Random.value, Random.value);
        bgColor = new Color(Random.value, Random.value, Random.value);
        cam.backgroundColor = Color.Lerp(current, bgColor, 5.0f);
    }
}
