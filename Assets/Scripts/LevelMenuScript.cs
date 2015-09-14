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
        Application.LoadLevel(level);
    }

    public void ReturnToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
