using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        //Initialize Variables
    float
        moveSpeed,                  //Move Speed In U/s
        jumpForce,                  //Upwards Jump Force
        lookSens,                   //Mouse Camera Control Sensitivity
        minLook,                    //Highest Vertical Camera Angle
        maxLook,                    //Lowest Vertical Camera Angle
        y,                          //Current Vertical Camera Angle
        T;                          //Time.deltaTime
    bool colliding;                 //Are We Touching Anything?
    Camera cam;                     //Player Camera
    Rigidbody rb;                   //Player Rigidbody
    Weapon weapon;                  //Player Weapon Script

    void Awake()
    {
        //Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;

        //Get Components
        weapon = GetComponent<Weapon>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Set Initial Values
        moveSpeed = 3;
        jumpForce = 20;
        lookSens = 280;
        minLook = -90;
        maxLook = 90;
        T = Time.deltaTime;

        //Verify Everything is Zeroed Out On Start
        Input.ResetInputAxes();
    }

    void Move()                     //Player Movement
    {
        //Get Axes
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed * T;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed * T;

        //Move
        transform.Translate(x, 0, z);
    }

    void Look()                     //Camera Rotation
    {
        //Get Axes
        float x = Input.GetAxisRaw("Mouse X") * lookSens * T;
        y += Input.GetAxisRaw("Mouse Y") * lookSens * T;

        //Limit Vertical Look
        y = Mathf.Clamp(y, minLook, maxLook);

        //Look
        transform.Rotate(0, x, 0);
        cam.transform.localRotation = Quaternion.Euler(-y, 0, 0);
    }

    void Jump()                     //Jumping
    {
        //Instantaneous Force On Player
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnCollisionEnter()  //Check For Collision Enter
    {
        colliding = true;
    }

    public void OnCollisionExit()   //Check For Collision Exit
    {
        colliding = false;
    }

    void Update()
    {
        Move();
        Look();

        //Jump Button & Disable Multi-Jumping
        if (Input.GetButtonDown("Jump") && colliding)
            Jump();

        //Fire Button & Verify Ability To Shoot
        if (Input.GetKeyDown("mouse 0")) 
            weapon.Fire();
    }
}