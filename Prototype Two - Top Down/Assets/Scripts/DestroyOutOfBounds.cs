using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float xRange = 8.88f;
    public float yRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= xRange) Destroy(gameObject);
        if (Mathf.Abs(transform.position.y) >= yRange) Destroy(gameObject);
    }
}
