using UnityEngine;
using System.Collections;

public class BasketObjectScript : MonoBehaviour {

    ParticleSystem prtclSys;
    float moveDirection;

    void Start()
    {
        prtclSys = GetComponent<ParticleSystem>();
    }

	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        moveDirection = Random.Range(-6f, 6f);
        Debug.Log(moveDirection);
        coll.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveDirection, 25f), ForceMode2D.Impulse);
        StartCoroutine(ShowParticles());
    }

    IEnumerator ShowParticles()
    {
        prtclSys.Play(true);
        yield return new WaitForSeconds(1);
        prtclSys.Stop(true);
    }
}
