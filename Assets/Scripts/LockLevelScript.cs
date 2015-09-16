using UnityEngine;
using System.Collections;
using System;

public class LockLevelScript : MonoBehaviour {

    public static int worlds = 1;
    public static int levels = 6;

    private int worldIndex;
    private int levelIndex;

	void Start () {
        PlayerPrefs.DeleteAll();
        LockLevels();
	
	}

    private void LockLevels()
    {
        for (int i = 0; i < worlds; i++)
        {
            for (int j = 1; j < levels; j++)
            {
                worldIndex = (i + 1);
                levelIndex = (j + 1);
                if (!PlayerPrefs.HasKey("Level" + worldIndex.ToString() + ":" + levelIndex.ToString()))
                {
                    PlayerPrefs.SetInt("Level" + worldIndex.ToString() + ":" + levelIndex.ToString(), 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
