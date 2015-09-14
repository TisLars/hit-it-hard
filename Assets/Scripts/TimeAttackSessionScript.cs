using UnityEngine;
using System.Collections;

public class TimeAttackSessionScript : MonoBehaviour {

    private float time;

	void Start () {
        DontDestroyOnLoad(this);
        Debug.Log("starting timer");
	}

    void Update()
    {
        time += Time.deltaTime;
    }

    public float getTime()
    {
        return time;
    }
}
