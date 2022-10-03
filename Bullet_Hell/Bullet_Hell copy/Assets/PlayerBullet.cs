using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage;
    private Rigidbody2D rb;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);

            DESTROY();
        }
        else if (collision.gameObject.tag == "crate")
        {
            collision.GetComponent<crate>().TakeDamage(damage);

            DESTROY();
        }
        else if (collision.gameObject.tag == "turret")
        {
            sfxManager.instance.metalHitSound();
            DESTROY();
        }
        else if (collision.gameObject.tag == "obstacle")
        {
            DESTROY();
        }

    }

    private void DESTROY()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("destroy");
    }

    public void BREAK()
    {
        Destroy(gameObject);
    }


}
