using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemySpawner : MonoBehaviour
{
    public static enemySpawner instance;

    public GameObject enemy;
    public Transform enemyLandPos;
    public Transform firePos;
    public float cooldown;
    private float timer;
    public bool canSpawn;
    public float distance;
    private GameObject player;

    void Start()
    {
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player");
        timer = cooldown;
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < distance)
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }

        if (canSpawn)
        {
            if(timer <= 0)
            {
                spawn();
                timer = cooldown;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void spawn()
    {

        GameObject littleDuck = Instantiate(enemy, firePos.position, firePos.rotation);
        littleDuck.GetComponent<MovingEnemy>().canMove = false;
        littleDuck.transform.DOMove(enemyLandPos.position, 1f).SetEase(Ease.OutQuad);
        littleDuck.GetComponent<MovingEnemy>().canMove = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
