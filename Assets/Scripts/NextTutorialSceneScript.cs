using UnityEngine;
using System.Collections;

public class NextTutorialSceneScript : MonoBehaviour {

    public int tutorialLevelNumber;

	void OnMouseUp()
    {
        if(tutorialLevelNumber == 0)
        {
            Application.LoadLevel("MainMenu");
        } else
        {
            Application.LoadLevel("Tutorial0" + tutorialLevelNumber);
        }
    }

}
