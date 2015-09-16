using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelScript : MonoBehaviour {

    public int minimalHitRule;
    public int maximumHitRule;
    public int showTextTimer = 3;

    private GameObject ball;
    private BallScript ballScript;

    private GameObject levelTextPanel;
    private GameObject levelText;

    private ShootLogicV3 shootScript;

    void Awake()
    {
        levelText = GameObject.Find("LevelText");
        levelTextPanel = GameObject.Find("LevelTextPanel");
        
        ball = GameObject.Find("Ball");
        if (ball)
        {
            ballScript = ball.GetComponent<BallScript>();
            shootScript = ball.GetComponent<ShootLogicV3>();
        }

        if (PlayerPrefs.HasKey("Level" + Application.loadedLevel))
            Debug.Log(PlayerPrefs.GetInt("Level" + Application.loadedLevel));
    }

    void Start()
    {
        setLevelIntroText();
        if (!PlayerPrefs.HasKey("Level" + Application.loadedLevel))
            PlayerPrefs.SetInt("Level" + Application.loadedLevel, 1);
    }

    void Update()
    {
        if (levelText != null && levelTextPanel != null && shootScript.isShot)
        {
            Destroy(levelText);
            Destroy(levelTextPanel);
        }

    }
    
    void setLevelIntroText()
    {
        string ruleText = "Level "+ Application.loadedLevel +"\n";
        string wallText = "walls";

        if (minimalHitRule > 0)
        {
            if (minimalHitRule == 1)
            {
                wallText = "wall";
            }
            ruleText += "Hit at least " + minimalHitRule + " " + wallText + "\n";
        }

        wallText = "walls"; // Reset it to "walls"

        if (maximumHitRule > 0)
        {
            if (maximumHitRule == 1)
            {
                wallText = "wall";
            }
            ruleText += "Do not hit more than " + maximumHitRule + " " + wallText + "\n";
        }

        if (maximumHitRule == -1 && minimalHitRule == 0)
        {
            ruleText += "Don't hit any walls!";
        }

        levelText.GetComponent<Text>().text = ruleText;
        
        Destroy(levelText, showTextTimer);
        Destroy(levelTextPanel, showTextTimer);
    }

    public int getMaxHitRule()
    {
        return maximumHitRule;
    }
    public int getMinHitRule()
    {
        return minimalHitRule;
    }

    public void LevelComplete()
    {
        int i = Application.loadedLevel;
        if (i == (Application.levelCount - 1))
        {
            Application.LoadLevel(0);
        } else
        {
            Application.LoadLevel(i + 1);
        }
    }

    public void LevelFailed()
    {
        Application.LoadLevel(Application.loadedLevel);
        Destroy(ball);
    }

}
