using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Initialize Variables
    ObjectPool bulletPool;
    Transform muzzle;
    int
        ammo,                   //Current Ammo
        maxAmmo;                //Maximum Ammo
    bool
        infAmmo,                //Do We Have Infinite Ammo?
        isPlayer;               //Is This A Player?
    float
        fireSpeed,              //Bullet Speed
        fireRate,               //Fire Frequency
        lastFireTime;           //Last Time Weapon Fired

    void Awake()
    {
        //Get Components
        if (GetComponent<PlayerController>()) isPlayer = true;
        muzzle = ((isPlayer)
            ? transform.Find("Camera/Blaster/Muzzle").transform
            : transform.Find("Blaster/Muzzle").transform);
        bulletPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        //Set Initial Values
        ammo = 10;
        maxAmmo = 10;
        infAmmo = false;
        fireSpeed = 60;
        fireRate = 1;
    }

    public bool CanFire()       //Can We Fire?
    {
        //Has Enough Time Passed?
        if (Time.time - lastFireTime >= fireRate)
        {
            //Do You Have Ammo?
            bool x = ((ammo > 0 || infAmmo == true) ? true : false);
            return x;
        }
        else return false;
    }

    public void Fire()          //Fire
    {
        if (CanFire())
        {
            //Fire Cooldown
            lastFireTime = Time.time;

            //Decrement Ammo Count
            ammo --;

            //Fire Bullet
            Transform bullet = bulletPool.GetObject().transform;
            bullet.position = muzzle.position;
            bullet.rotation = muzzle.rotation;
                        
            //Assign Speed To Bullet
            bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * fireSpeed;
        }
    }
}
