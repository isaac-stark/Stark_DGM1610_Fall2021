using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
            gameObject.SetActive(false);
    }
}