using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    [Header("OTHER")]
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    public PlayerHealth health;


    
    public GameObject gun;
    public GameObject spriteFlipper;

    [Space(10)]
    [Header("MOVEMENT")]
    public bool canMove = true;
    public float speed;
    private Vector2 moveInput;


    void Start()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        ProcessInputs();

        spr.flipX = spriteFlipper.GetComponent<spriteFlipper>().rotationZ < -90;

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
        
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(2);
            
        }
    }

}
