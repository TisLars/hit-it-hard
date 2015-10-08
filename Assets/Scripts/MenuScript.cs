using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MenuScript : MonoBehaviour {

    public Button playButton;
    public Button timeAttackButton;
    public Button volumeButton;
    public Button tutorialButton;
    public Button settingsButton;
    public Button exitButton;

    bool showSettings = false;
    bool isMute;

    public GameObject main;
    public GameObject settings;
    public GameObject TimeAttackSession;

    void Start()
    {
        playButton = playButton.GetComponent<Button>();
        timeAttackButton = timeAttackButton.GetComponent<Button>();
        volumeButton = volumeButton.GetComponent<Button>();
        tutorialButton = tutorialButton.GetComponent<Button>();
        settingsButton = settingsButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetInt("volume", 1);
        }
        else
        {
            if (PlayerPrefs.GetInt("volume") == 0)
                Mute();
        }

        // GOOGLE PLAY SERVICES
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => { });
    }

    public void ShowAchievements() { Social.ShowAchievementsUI(); }
    public void ShowLeaderboard() { Social.ShowLeaderboardUI(); }

    public void GoToLevelMenu()
    {
        if (!PlayerPrefs.HasKey("Tutorial"))
            Application.LoadLevel("Tutorial01");
        else
            Application.LoadLevel("LevelMenu");
    }

    public void StartTimeAttack()
    {
        if (!PlayerPrefs.HasKey("Tutorial"))
            Application.LoadLevel("Tutorial01");
        else
        {
            Instantiate(TimeAttackSession);
            Application.LoadLevel(1);
        }
    }

    public void ToggleSettingsMenu()
    {
        showSettings = !showSettings;
    }

    public void StartTutorial()
    {
        Application.LoadLevel("Tutorial01");
    }

    public void Mute()
    {
        isMute = !isMute;
        if (isMute)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("volume", 1);
        } else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("volume", 0);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (showSettings)
        {
            main.SetActive(false);
            settings.SetActive(true);
        } else
        {
            settings.SetActive(false);
            main.SetActive(true);
        }
        //if (Input.GetButtonDown("Fire3"))
        //    PlayerPrefs.DeleteAll();
    }
}
