using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuScript : MonoBehaviour
{

    public Button returnButton;

    void Start()
    {
        returnButton = returnButton.GetComponent<Button>();
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
