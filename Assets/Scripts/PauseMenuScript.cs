using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

    public GameObject pauseMenuCanvas;
    public GameObject ui;
    public Button menuButton;
    public string mainMenu;
    public bool isPaused;

    void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
    }
    
    public void Resume()
    {
        isPaused = false;
    }

    public void MainMenu()
    {
        if (GameObject.Find("TimeAttackSession(Clone)"))
            GameObject.Destroy(GameObject.Find("TimeAttackSession(Clone)"));
        Application.LoadLevel(mainMenu);
    }
}
