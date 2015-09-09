using UnityEngine;
using System.Collections;

public class ButtonBehaviourV2 : MonoBehaviour {

    public bool isReplayButton;
    public bool isMenuButton;

    void OnMouseDown()
    {
        if (isReplayButton)
        {
            ReplayLevel();
        }
        if (isMenuButton)
        {
            GoToMenu();
        }
    }

    public void ReplayLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GoToMenu()
    {
        Application.LoadLevel(0);
    }



}
