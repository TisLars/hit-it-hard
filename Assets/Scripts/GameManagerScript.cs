using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript manager;

    int totalHits = 0;

    void Awake()
    {
        if (!manager)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScoreOnHit()
    {
        totalHits++;
    }

    public int getScore()
    {    
        return totalHits;
    }

    public void setScore(int value)
    {
        totalHits = value;
    }

    public void Login()
    {

    }

}
