using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Teleport : MonoBehaviour
{
    
    void OnCollisionEnter(Collision bye)
    {
        if (bye.gameObject.name == "Rocketship")
        {
            Debug.Log("Collision Detected");
            Destroy(bye.gameObject);
        }
    }
}
