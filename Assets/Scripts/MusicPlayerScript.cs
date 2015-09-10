using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour {

    public static MusicPlayerScript player;

    void Awake()
    {
        if (!player)
        {
            player = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
