using UnityEngine;
using System.Collections;

public class ShootLogicTouchAreaScript : MonoBehaviour {

    private ShootLogicV3 shoot;

	// Use this for initialization
	void Start () {
        shoot = transform.parent.GetComponent<ShootLogicV3>();
    }

    void Update()
    {
        if(shoot.isShot)
        {
            Debug.Log("HHHH");
            Destroy(gameObject);
        }
    }

}
