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
    private float rotX;     //Current X Camera Rotation
    private Camera cam;
    private Rigidbody rb;

    void Start()
    {
        //Get Components
        //camera = camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()             //Player Movement
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CamLook()          //Camera Rotation
    {
        float x = Input.GetAxis("Mouse X") * lookSens;
        rotX += Input.GetAxis("Mouse X") * lookSens;
    }
}