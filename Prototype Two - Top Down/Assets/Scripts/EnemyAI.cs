using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        //Set Variables Automatically
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //Funky Conditional Stuff So I Stop Getting Errors On Player Death
        Vector2 direction;
        if (player != null)
        {
            //Math To Calculate Angle Towards Player
            direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            //Turn Enemy Towards Player
            rb.rotation = angle;
            movement = direction;
        }
        else
        {
            //Stop Enemy Movement Upon Player Death
            speed = 0;
        }
    }

    void MoveEnemy(Vector2 direction)
    {
        //Cause Enemy To Move Towards Player
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void FixedUpdate()
    {
        //Call Enemy Movement
        MoveEnemy(movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy Enemy When Shot
        if (other.CompareTag("Projectile")) Destroy(gameObject, .05f);
    }
}
