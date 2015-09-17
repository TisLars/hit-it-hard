using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

    public GameObject pauseMenuCanvas;
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

        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
    }
    
    public void Resume()
    {
        isPaused = false;
    }

    public void MainMenu()
    {
        Application.LoadLevel(mainMenu);
    }
}
