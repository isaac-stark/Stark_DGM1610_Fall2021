using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    //Stats
    int
        HP,                     //Current HP
        maxHP,                  //Max HP
        scoreToGive;            //?

    //Movement
    float
        speed,                  //Movement Speed
        range,                  //Attack Range
        yPathOffset,            //?
        dist;                   //Distance From Target
    List<Vector3> path;         //Pathfinding
    GameObject target;          //Target To Pathfind

    //Weapon
    Weapon weapon;              //Access Blaster Functions

    void Start()
    {
        //Get Components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0, .25f);

        //Set Initial Values
        maxHP = 20;
        HP = maxHP;
        speed = 2.6f;
        range = 10;
        yPathOffset = .98f;
    }

    void UpdatePath()
    {
        //Create Path To Target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(
            transform.position,
            target.transform.position,
            NavMesh.AllAreas,
            navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    void Move()
    {
        if (path.Count == 0) return;

        //Face Target
        transform.LookAt(target.transform);

        //Pathfind
        transform.position = Vector3.MoveTowards(
            transform.position, 
            path[0] + new Vector3(0, yPathOffset, 0), 
            speed * Time.deltaTime);

        if (transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    void Update()
    {
        Move();

        //Set 'dist'
        dist = Vector3.Distance(
            transform.position,
            target.transform.position);

        //Shoot When Within Range, Else Get In Range
        if (dist <= range)
        {
            weapon.Fire();
        }
    }
}