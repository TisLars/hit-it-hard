using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Button playButton;
    public Button timeAttackButton;
    public Button volumeButton;
    public Button exitButton;

    bool isMute;
    public GameObject TimeAttackSession;

    void Start () {
        playButton = playButton.GetComponent<Button>();
        timeAttackButton = timeAttackButton.GetComponent<Button>();
        volumeButton = volumeButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
	}

    public void GoToLevelMenu()
    {
        Application.LoadLevel(Application.levelCount - 1);
    }

    public void StartTimeAttack()
    {
        Instantiate(TimeAttackSession);
        Application.LoadLevel(1);
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
