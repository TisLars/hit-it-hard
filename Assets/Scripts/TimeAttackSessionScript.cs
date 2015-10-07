using UnityEngine;
using System.Collections;

public class TimeAttackSessionScript : MonoBehaviour {

    private float time;

	void Start () {
        DontDestroyOnLoad(this);
	}

    void Update()
    {
        time += Time.deltaTime * 1000;
    }

    public float getTime()
    {
        return time;
    }
}
