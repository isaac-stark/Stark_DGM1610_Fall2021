using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupType type;
    private Vector3 spawnPoint;
    public int value;
    private float T;

    //Bobbing Motion
    public float rotSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbing;

    void Start()
    {
        spawnPoint = transform.position;
        rotSpeed = 10;
        bobHeight = .15f;
        bobSpeed = .04f;
        T = Time.deltaTime;
    }

    public enum PickupType
    {
        Health,
        Ammo
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            PlayerController player = c.GetComponent<PlayerController>();

            switch(type)
            {
                case PickupType.Health:
                    value = 2;
                    player.Heal(value);
                    break;
                case PickupType.Ammo:
                    value = 5;
                    player.Reload(value);
                    break;
                default:
                    print("ERROR: Bad Pickup Type");
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed * T, Space.World);
        Vector3 offset = (bobbing) ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight, 0);
        transform.position = Vector3.MoveTowards(transform.position, spawnPoint + offset, bobSpeed * T);
        if (transform.position == spawnPoint + offset) bobbing = !bobbing;
    }
}
