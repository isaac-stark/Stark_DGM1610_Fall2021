using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 7f;
    private float turnSpeed = 160f;
    private float hInput;
    private float vInput;
    private float xRange = 8.46f;
    private float yRange = 4.58f;
    private Transform launcher;

    void Start()
    {
        //Set Launcher Variable Automatically
        launcher = GameObject.Find("Launcher").transform;
    }

    void Update()
    {
        //Player Movement
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.back * turnSpeed * hInput * Time.deltaTime);
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

        //Instantiate & Shoot Spell From Resources Folder
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate((Resources.Load("Spell")), launcher.transform.position, launcher.transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy Player When Touching Enemy
        if (other.CompareTag("Enemy")) Destroy(gameObject);
    }
}
