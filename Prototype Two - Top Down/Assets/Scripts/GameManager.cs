using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasKey && !isLocked)
        {
            print("Door Opened");
        }
    }
}
