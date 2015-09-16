using UnityEngine;
using System.Collections;

public class SkipTutorialScript : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel("MainMenu");
    }
	
}
