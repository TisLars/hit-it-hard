using UnityEngine;
using System.Collections;

public class KattenPoot : MonoBehaviour {

    private LevelScript level;

    void Awake()
    {
        level = GameObject.Find("Level").GetComponent<LevelScript>();
    }

	void OnTriggerEnter2D()
    {
        level.LevelFailed();
    }

}
