using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelMenuScript : MonoBehaviour {

    public Button levelOneButton;
    public Button returnButton;

    void Start()
    {
        levelOneButton = levelOneButton.GetComponent<Button>();
        returnButton = returnButton.GetComponent<Button>();
    }

    public void StartLevel()
    {
        Application.LoadLevel(1);
    }

    public void ReturnToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
