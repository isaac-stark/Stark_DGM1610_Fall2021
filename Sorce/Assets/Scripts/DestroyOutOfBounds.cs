using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float bound = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= bound) Destroy(gameObject);
        if (Mathf.Abs(transform.position.z) >= bound) Destroy(gameObject);
    }
}
