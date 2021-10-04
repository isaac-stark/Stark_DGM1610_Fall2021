using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int amount;
    private GameManager gameManager;

    void Start()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Rotate(Vector3.back * 100 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.hasKey = true;
            print(gameObject.name + " acquired!");
            amount = amount + 1;
            Destroy(gameObject);
        }
    }
}
