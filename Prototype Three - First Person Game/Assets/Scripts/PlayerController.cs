using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float
        moveSpeed,          //Move Speed In U/s
        jumpForce,          //Upwards Jump Force
        lookSens,           //Mouse Camera Control Sensitivity
        minLook,            //Highest Vertical Camera Angle
        maxLook;            //Lowest Vertical Camera Angle
    private float rotX;
    private Camera cam;
    private Rigidbody rb;
    private Transform launcher;

    void Start()
    {
        //Get Components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        launcher = GameObject.Find("Blast").transform;
    }

    void Update()
    {
        Move();
        CamLook();
        Jump();
        Shoot();
    }

    void Move()             //Player Movement
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(x, 0, z);
    }

    void CamLook()          //Camera Rotation
    {
        float x = Input.GetAxis("Mouse X") * lookSens;
        rotX += Input.GetAxis("Mouse Y") * lookSens;
        float clamp = Mathf.Clamp(rotX, minLook, maxLook); 
        transform.Rotate(0, x, 0);
        cam.transform.localRotation = Quaternion.Euler(-clamp, 0, 0);
    }

    void Awake()
    {
        //Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Jump()             //Jumping
    {
        if (Input.GetButtonDown("Jump")) rb.velocity = new Vector3(0, jumpForce, 0);
    }

    void Shoot()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            Instantiate((Resources.Load("Bullet")), launcher.transform.position, launcher.transform.rotation);
            print("Bang!");
        }
    }
}