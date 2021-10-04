using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameManager gameManager;
    private Pickup pickup;

    // Start is called before the first frame update
    void Start()
    {
        pickup = Object.FindObjectOfType<Pickup>();
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameManager.hasKey)
        {
            pickup.amount = pickup.amount - 1;
            gameManager.isLocked = false;
            print("You Unlock the Door");
        }
        else
        {
            print("The Door is Locked! You need a Key!");
        }
    }
}
