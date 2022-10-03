using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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

        if(Player != null)
        {
            Vector2 moveDir = (Player.transform.position - transform.position).normalized * speed;

        }
        

        Vector2 error = Random.insideUnitCircle * accuracy;
        this.transform.LookAt(Player.transform.position + (transform.right * error.x) + (transform.up * error.y));
        //rb.velocity = new Vector2(moveDir.x, moveDir.y);
        rb.velocity = transform.forward * speed;

        Invoke("Destroy", lifetime);
    }



    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy();
        }
        else if(collision.gameObject.tag == ("obstacle"))
        {
            Destroy();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("obstacle"))
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    
}
