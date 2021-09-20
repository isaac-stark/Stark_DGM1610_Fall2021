using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float hInput;
    public float vInput;
    public float xRange = 8.46f;
    public float yRange = 4.58f;
    public GameObject projectile;
    public Vector3 offset = new Vector3(0,1);
    //public int health;

    void Update()
    {
        //Player Movement
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * speed * hInput * Time.deltaTime);
        transform.Translate(Vector2.up * speed * vInput * Time.deltaTime);

        //Set X Bounds
        if (Mathf.Abs(transform.position.x) >= xRange)
        {
            float x = (transform.position.x < 0)
                ? x = -xRange
                : x = xRange;
            transform.position = new Vector2(x, transform.position.y);
        }

        //Set Y Bounds
        if (Mathf.Abs(transform.position.y) >= yRange)
        {
            float y = (transform.position.y < 0)
                ? y = -yRange
                : y = yRange;
            transform.position = new Vector2(transform.position.x, y);
        }

        //Shoot Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position + offset, projectile.transform.rotation);
        }
    }
}
