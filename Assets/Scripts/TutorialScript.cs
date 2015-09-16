using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
    
	void Start () {
        PlayerPrefs.SetInt("Tutorial", 1);
	}
}
