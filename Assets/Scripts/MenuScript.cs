using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Button playButton;
    public Button timeAttackButton;
    public Button exitButton;

    public GameObject TimeAttackSession;

    void Start () {
        playButton = playButton.GetComponent<Button>();
        timeAttackButton = timeAttackButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
	}

    public void GoToLevelMenu()
    {
        Application.LoadLevel(1);
    }

    public void StartTimeAttack()
    {
        Instantiate(TimeAttackSession);
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
