using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour {

    public GameObject levelButton;
    public Button returnButton;

    void Start()
    {
        UnlockLevels();
    }

    public void StartLevel(int level)
    {
        Application.LoadLevel("Level" + level);
    }

    void UnlockLevels()
    {
        for (int i = 1; i < Application.levelCount - 3; i++)
            if (PlayerPrefs.GetInt("Level" + i) == 1)
                GameObject.Find("LockedLevel" + i).SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
