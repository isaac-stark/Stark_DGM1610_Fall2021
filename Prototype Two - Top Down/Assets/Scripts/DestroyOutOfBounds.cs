using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xRange = 8.88f;
    private float yRange = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        //Destroy Projectile When Out Of Bounds
        if (Mathf.Abs(transform.position.x) >= xRange) Destroy(gameObject);
        if (Mathf.Abs(transform.position.y) >= yRange) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy Projectile On Any Collision To Prevent Buildup
        Destroy(gameObject);
    }
}
