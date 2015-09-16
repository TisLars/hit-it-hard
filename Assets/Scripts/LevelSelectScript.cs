using UnityEngine;
using System.Collections;
using System;

public class LevelSelectScript : MonoBehaviour {

    private int worldIndex;
    private int levelIndex;

	void Start () {
        for (int i = 1; i <= LockLevelScript.worlds; i++)
        {
            if (Application.loadedLevelName == "World" + i)
            {
                worldIndex = i;
                CheckLockedLevels();
            }
        }
	}

    public void SelectLevel(string worldLevel)
    {
        Application.LoadLevel("Level" + worldLevel);
    }

    private void CheckLockedLevels()
    {
        for (int j = 1; j < LockLevelScript.levels; j++)
        {
            levelIndex = (j + 1);
            if ((PlayerPrefs.GetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString())) == 1)
            {
                GameObject.Find("LockedLevel" + (j + 1)).SetActive(false);
                Debug.Log("Unlocked");
            }
        }
    }
}
