using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 8f;

    void Update()
    {
        //Move Projectile Foward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
