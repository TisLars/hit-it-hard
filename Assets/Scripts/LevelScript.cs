﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class LevelScript : MonoBehaviour {

    public int minimalHitRule;
    public int maximumHitRule;
    public int showTextTimer = 3;

    private GameObject ball;
    private GameObject cam;
    private BallScript ballScript;

    private GameObject levelTextPanel;
    private GameObject levelText;

    private ShootLogicV3 shootScript;

    private bool warpToEndActivated;

    void Awake()
    {
        levelText = GameObject.Find("LevelText");
        levelTextPanel = GameObject.Find("ChicoWithTextBoard");
        
        ball = GameObject.Find("Ball");
        if (ball)
        {
            ballScript = ball.GetComponent<BallScript>();
            shootScript = ball.GetComponent<ShootLogicV3>();
        }
    }

    void Start()
    {
        setLevelIntroText();
        if (!PlayerPrefs.HasKey("Level" + Application.loadedLevel))
            PlayerPrefs.SetInt("Level" + Application.loadedLevel, 1);

        /**
         * CAMERA
         * at start of a level, move the camera
         */
        cam = GameObject.Find("Render");
        if (Application.loadedLevel == 13)
        {
            cam = new GameObject("PreviewCam");
            cam.AddComponent<PreviewCamScript>();

            if (GameObject.Find("GameManager").GetComponent<GameManagerScript>().getWarpActivated())
            {
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().setWarpActivated(false);
            }
        }
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

    public void LevelComplete()
    {
        int i = Application.loadedLevel;
        if (i == (Application.levelCount - 1))
        {
            Application.LoadLevel(0);
        }
        else
        {
            Application.LoadLevel(i + 1);
        }
    }

    public void LevelFailed()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public int getMaxHitRule()
    {
        return maximumHitRule;
    }
    public int getMinHitRule()
    {
        return minimalHitRule;
    }
}
