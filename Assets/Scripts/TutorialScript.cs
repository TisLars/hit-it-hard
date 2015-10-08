using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
    
	void Start () {
        PlayerPrefs.SetInt("Tutorial", 1);
	}

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Application.LoadLevel("LevelMenu");
    }
}
