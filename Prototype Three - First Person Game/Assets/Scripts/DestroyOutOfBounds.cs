using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    void Update()
    {
        //Deactivate Bullet When Out Of Bounds
        if ((Mathf.Abs(transform.position.x) >= 80)
            ^ (Mathf.Abs(transform.position.y) >= 80)
            ^ (Mathf.Abs(transform.position.z) >= 80))
            gameObject.active = false;
    }
}