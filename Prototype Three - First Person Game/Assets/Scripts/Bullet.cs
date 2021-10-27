using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Declare Variables
    int damage;                     //How Much Damage Bullets Inflict
    float               
        lifetime,                   //How Long Bullets Last In The Environment
        shootTime;                  //When Bullet Was Shot

    void OnEnable()                 //Get When Bullet Was Shot
    {
        shootTime = Time.time;
    }

    void Start()
    {
        //Initiate Variables
        damage = 1;
        lifetime = 5;
    }

    void OnTriggerEnter(Collider c) //When Bullet Hits Something
    {
        //Damage If Player
        if (c.CompareTag("Player")) 
            c.GetComponent<PlayerController>().TakeDamage(damage);

        //Damage If Enemy
        else if (c.CompareTag("Enemy"))
            c.GetComponent<EnemyController>().TakeDamage(damage);

        //Deactivate Bullet
        gameObject.SetActive(false);
    }

    void Deactivate()               //Deactivate Bullet When Too Far Or Too Old
    {

        if ((Mathf.Abs(transform.position.x) >= 80)
            || (Mathf.Abs(transform.position.y) >= 80)
            || (Mathf.Abs(transform.position.z) >= 80)
            || (Time.time - shootTime >= lifetime))
            gameObject.SetActive(false);
    }

    void Update()
    {
        //Deactivate Bullet
        Deactivate();
    }
}
