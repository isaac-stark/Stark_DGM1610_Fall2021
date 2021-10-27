using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    //Declare Variables
    private List<Vector3> path;                 //Pathfinding
    private GameObject target;                  //Target To Pathfind
    private Weapon weapon;                      //Access Blaster Functions

    private int
        HP,                             //Current HP
        maxHP;                          //Max HP                    
    private float
        speed,                          //Movement Speed
        range,                          //Attack Range
        yPathOffset,                    //Unsure What This Actually Does
        dist;                           //Distance From Target

    void Start()
    {
        //Get Components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0, .25f);

        //Intitialize Variables
        maxHP = 20;
        HP = maxHP;
        speed = 2.6f;
        range = 10;
        yPathOffset = .983f;
    }

    void UpdatePath()                   //Reroute Path
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

    void Move()                         //Movement Logic
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

    public void TakeDamage(int damage)  //Taking Damage
    {
        HP -= damage;
        if (HP <= 0) Destroy(gameObject);
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