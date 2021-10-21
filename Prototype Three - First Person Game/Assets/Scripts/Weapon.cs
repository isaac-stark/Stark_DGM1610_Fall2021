using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
        //Initialize Variables
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
        muzzle = GameObject.Find("Muzzle").transform;
    }

    void Start()
    {
        ammo = 10;
        maxAmmo = 10;
        infAmmo = false;
        fireSpeed = 60;
        fireRate = 1;
    }

    public bool CanFire()
    {
        if (Time.time - lastFireTime >= fireRate)
        {
            bool x = ((ammo > 0 || infAmmo == true) ? true : false);
            return x;
        }
        else return false;
    }

    public void Fire()
    {
        if (CanFire())
        {
            //Fire Cooldown
            lastFireTime = Time.time;

            //Decrement Ammo Count
            ammo --;

            //Fire Bullet
            GameObject bullet = Instantiate((Resources.Load("Bullet") as GameObject), muzzle.position, muzzle.rotation);
            
            //Assign Speed To Bullet
            bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * fireSpeed;
        }
    }

    void Update()
    {
        
    }
}
