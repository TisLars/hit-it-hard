using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelScript : MonoBehaviour {

    public int minimalHitRule;
    public int maximumHitRule;

    private GameObject ball;
    
    public int showTextTimer = 3;

    void Awake()
    {
        setLevelIntroText();
        ball = GameObject.Find("Ball");
    }

    void setLevelIntroText()
    {
        GameObject levelText = GameObject.Find("LevelText");
        GameObject levelTextPanel = GameObject.Find("LevelTextPanel");
        string ruleText = "Level "+ Application.loadedLevel +"\n";
        string wallText = "muren";

        if (minimalHitRule > 0)
        {
            if (minimalHitRule == 1)
            {
                wallText = "muur";
            }
            ruleText += "Raak minimaal " + minimalHitRule + " " + wallText + "\n";
        }

        wallText = "muren"; // Reset it to Muren

        if (maximumHitRule > 0)
        {
            if (maximumHitRule == 1)
            {
                wallText = "muur";
            }
            ruleText += "Raak maximaal " + maximumHitRule + " " + wallText + "\n";
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
        Debug.Log("You finished this level. Good job!");

        int i = Application.loadedLevel;
        if(i == (Application.levelCount - 1))
        {
            Application.LoadLevel(0);
        } else
        {
            Application.LoadLevel(i + 1);
        }

    }

    public void LevelFailed()
    {
        Debug.Log("Nope!");
        Application.LoadLevel(Application.loadedLevel);
        Destroy(ball);
    }

}
