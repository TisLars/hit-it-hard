using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

    public bool replayLevel = false;
    public bool goToMenu = false;

    private bool canClick = true;

    // Use this for initialization
    void Start () {
        if(replayLevel && goToMenu)
        {
            Debug.Log("Y u trying to replay and go to the menu at the same time bro?");
            Debug.Log("Disabled the buttons");
            canClick = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown()
    {
        if(canClick)
        {
            if (goToMenu)
            {
                GoToMenu();
            }

            if (replayLevel)
            {
                ReplayLevel();
            }
        }
    }

    void ReplayLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void GoToMenu()
    {
        Application.LoadLevel(0);
    }

}
