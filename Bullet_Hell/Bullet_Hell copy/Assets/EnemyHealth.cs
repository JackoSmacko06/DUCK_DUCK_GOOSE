using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{

    public static EnemyHealth Instance;

    private Rigidbody2D rb;

    private GameObject arena1;

    public FireBullets bullets;
    public enemySpawner spawner;
    public bool shootOnDeath;

    private SpriteRenderer spr;
    public Material origionalMaterial;
    public Material flashMaterial;
    public float flashDuration;

    public GameObject bloodSplatter1;
    public GameObject bloodSplatter2;
    public GameObject bloodSplatter3;

    public GameObject bloodSplatterEffect;
    public GameObject bloodHitEffect;

    public float knockbackForce;
    public float knockbackDuration;

    public float health;
    public int collisionDamage;

    void Start()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();

        spr = GetComponent<SpriteRenderer>();

        arena1 = GameObject.FindGameObjectWithTag("arena1");
    }

    
    void Update()
    {
        if (health <= 0)
        {
            DIE();
            
        }   
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(flash(flashDuration));
        Instantiate(bloodHitEffect, transform.position, Quaternion.identity);


        sfxManager.instance.hitEnemySound();

        health -= damage;
    }

    public void DIE()
    {
        if (arena1 != null)
        {
            arena1.GetComponent<arena>().enemiesAlive--;
        }

        if (shootOnDeath)
        {
            bullets.Fire();
            spawner.spawn();
            spawner.spawn();
            spawner.spawn();
        }

        Instantiate(bloodSplatterEffect, transform.position, Quaternion.identity);

        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            Instantiate(bloodSplatter1, transform.position, Quaternion.identity);
        }
        else if (rand == 2)
        {
            Instantiate(bloodSplatter2, transform.position, Quaternion.identity);
        }
        else if (rand == 3)
        {
            Instantiate(bloodSplatter3, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(collisionDamage);
        }
    }

    IEnumerator flash(float dur)
    {
        spr.material = flashMaterial;
        
        yield return new WaitForSeconds(dur);

        spr.material = origionalMaterial;
    }

    IEnumerator idk()
    {
        yield return new WaitForSeconds(.5f);

        spr.material = origionalMaterial;
    }

    /*public IEnumerator knockback(float dur, float power, GameObject obj)
    {
        float timer = 0;

        while (dur > timer)
        {
            timer += Time.deltaTime;

            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(direction * power);

            yield return 0;
        }
    }*/


}
