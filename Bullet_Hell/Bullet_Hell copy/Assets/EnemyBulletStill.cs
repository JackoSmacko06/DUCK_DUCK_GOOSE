using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletStill : MonoBehaviour
{
    public int damage;
    public float lifetime = 3f;
    public float speed;
    private Rigidbody2D rb;
    private GameObject Player;
    public float accuracy;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        

        Invoke("Destroy", lifetime);
    }



    private void Update()
    {
        //rb.velocity = transform.forward * speed * Time.deltaTime;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy();
        }
        else if (collision.gameObject.tag == ("Enemy"))
        {

        }
        else if (collision.gameObject.tag == ("player_bullet"))
        {

        }
        else
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
