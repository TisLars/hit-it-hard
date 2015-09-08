using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Button playButton;
    public Button exitButton;

	void Start () {
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
	
	}

    public void GoToLevelMenu()
    {
        Application.LoadLevel(2); // Set it to 2 for now (skip the level select)
        Debug.Log("Start level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit game");
    }
}
