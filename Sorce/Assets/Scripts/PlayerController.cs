using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float hInput;
    private float vInput;
    private float speed = 5f;
    private float mouseX;
    private float mouseSens = 1000f;
    private Transform launcher;

    void Start()
    {
        launcher = GameObject.Find("Launcher").transform;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        
        transform.Translate(Vector3.forward * speed * vInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * hInput * Time.deltaTime);
        transform.Rotate(Vector3.up * mouseSens * mouseX * Time.deltaTime);

        if (Input.GetKeyDown("mouse 0")) Instantiate((Resources.Load("Spell")), launcher.transform.position, launcher.transform.rotation);
    }
}
