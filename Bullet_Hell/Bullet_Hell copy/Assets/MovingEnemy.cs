using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovingEnemy : MonoBehaviour
{
    private SpriteRenderer spr;
    public GameObject gun;
    public bool GGun;

    public AIPath AIPath;

    [Header("Movement")]
    private GameObject Player;
    public bool canMove = true;

    private Rigidbody2D rb;
    public float distance;
    public float stoppinDistance;
    public float speed;

    public float rotaionZ;



    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        spr = GetComponent<SpriteRenderer>();

        //AIPath.instance.canMove = false;
        rb = GetComponent<Rigidbody2D>();   
    }

    
    void Update()
    {
        if (GGun)
        {
            rotaionZ = gun.GetComponent<rotateToPlayer>().RotationZ;

            spr.flipX = rotaionZ < -90;
        }
        else
        {
            spr.flipX = Player.transform.position.x < this.transform.position.x;
        }



        if(Player != null)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) < distance && Vector2.Distance(transform.position, Player.transform.position) > stoppinDistance)
            {
                if (canMove)
                {       
                    //AIPath.canMove = true;
                    transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
                    gun.GetComponent<EnemyShoot>().canShoot = true;
                }
                
            }
            else if (Vector2.Distance(transform.position, Player.transform.position) < stoppinDistance)
            {
                if (canMove)
                {
                    //AIPath.canMove = false;
                    gun.GetComponent<EnemyShoot>().canShoot = true;
                }
                
            }
            else
            {
                
                //AIPath.canMove = false;
                gun.GetComponent<EnemyShoot>().canShoot = false;
            }
        }

           
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stoppinDistance);
    }
}
