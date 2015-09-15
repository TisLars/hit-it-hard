using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript manager;
    private BallScript ball = null;
    CameraShakeScript camShake;

    int totalHits = 0;

    void Start()
    {
        camShake = GetComponent<CameraShakeScript>();
    }

    void Awake()
    {
        if(GameObject.Find("Ball"))
        {
            ball = GameObject.Find("Ball").GetComponent<BallScript>();
        } 

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
}
