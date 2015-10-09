using UnityEngine;
using System.Collections;

public class RemoveOnClickScript : MonoBehaviour {
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Destroy(gameObject);
        }
    }
    
}
