using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Declare Variables
    GameObject objPrefab;
    List<GameObject> objPool = new List<GameObject>();
    int createOnStart;

    void Awake()
    {
        //Get Component To Pool
        objPrefab = Resources.Load("bullet") as GameObject;
    }

    void Start()
    {
        //Initialize Variables
        createOnStart = 5;

        //Create & Pool Starting Objects
        for (int x = 0; x < createOnStart; x++)
        {
            CreateNewObject();
        }
    }

    GameObject CreateNewObject()    //Create & Pool New Object
    {
        GameObject obj = Instantiate(objPrefab);
        obj.SetActive(false);
        objPool.Add(obj);
        return obj;
    }

    public GameObject GetObject()   //Access Object Properties
    {
        //Collect Inactive Object In Pool
        GameObject obj = objPool.Find(x => x.activeInHierarchy == false);

        //Do We Not Have Objects?
        if (obj == null)
        {
            obj = CreateNewObject();
        }

        //Activate New Object
        obj.SetActive(true);
        return obj;
    }
}
