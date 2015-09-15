using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour {

    public GameObject levelButton;
    public Button returnButton;

    void Start()
    {
        returnButton = returnButton.GetComponent<Button>();
    }

    public void StartLevel(int level)
    {
        string levelName;
        if (level < 10)
        {
            levelName = "Level0" + level;
        } else
        {
            levelName = "Level" + level;
        }
        
        Application.LoadLevel(levelName);
    }

    public void ReturnToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
