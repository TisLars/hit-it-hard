using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (Application.loadedLevel == 0)
            {
                Application.Quit();
            } 
        }

    }
}
