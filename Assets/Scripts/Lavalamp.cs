using UnityEngine;
using System.Collections;

public class Lavalamp : MonoBehaviour {

    public int secondsToWait;

    private Animator animator;

    IEnumerator waitForStartLavalamp()
    {
        yield return new WaitForSeconds(secondsToWait);

        animator.speed = 1;

    }

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.speed = 0;

        StartCoroutine(waitForStartLavalamp());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
