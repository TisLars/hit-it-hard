using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour {

    public GameObject levelButton;
    public Button returnButton;

    void Start()
    {
        returnButton = returnButton.GetComponent<Button>();
        UnlockLevels();
    }

    public void StartLevel(int level)
    {
        Application.LoadLevel("Level" + level);
    }

    void UnlockLevels()
    {
        for (int i = 2; i < Application.levelCount - 4; i++)
        {
            Debug.Log("show " + PlayerPrefs.GetInt("Level" + i));
            if (PlayerPrefs.GetInt("Level" + i) == 1)
            {
                GameObject.Find("LockedLevel" + i).SetActive(false);
                Debug.Log("unlocked" + i);
            }
        }
    }

    public void ReturnToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
