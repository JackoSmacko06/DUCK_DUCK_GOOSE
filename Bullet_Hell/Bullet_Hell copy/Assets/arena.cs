using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arena : MonoBehaviour
{
    public static arena instance;

    public GameObject glockDuck;
    public GameObject SMGDuck;
    public GameObject shotgunDuck;

    public bool room1;
    public bool room2;
    public bool room3;
    private GameObject[] enemies;
    bool canSpawn;
    public Transform[] spawnPoints;
    public float enemiesAlive;
    public GameObject gate1;
    public GameObject gate2;
    public GameObject gate3;


    private void Start()
    {
        instance = this;
        
        canSpawn = true;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            if (room1)
            {
                closeGates();

                if (canSpawn)
                {
                    StartCoroutine(spawnRoom1(.5f));

                    enemiesAlive = 3;
                    canSpawn = false;
                }

                if (enemiesAlive == 0)
                {
                    openGates();
                    room1 = false;
                    Destroy(gameObject);
                }
            }

            if (room2)
            {

                if (canSpawn)
                {
                    StartCoroutine(spawnRoom2(0.5f));

                    enemiesAlive = 6;
                    canSpawn = false;
                }

                if (enemiesAlive == 0)
                {
                    room2 = false;
                    Destroy(gameObject);
                }
            }
            if (room3)
            {

                if (canSpawn)
                {
                    StartCoroutine(spawnRoom3(0.5f));

                    enemiesAlive = 5;
                    canSpawn = false;
                }

                if (enemiesAlive == 0)
                {
                    room3 = false;
                    Destroy(gameObject);
                }
            }


        }
    }

    public void closeGates()
    {
        if (room1)
        {
            gate1.GetComponent<Animator>().SetTrigger("open");
            gate2.GetComponent<Animator>().SetTrigger("open");
        }


    }
    public void openGates() 
    {
        if (room1)
        {
            gate1.GetComponent<Animator>().SetTrigger("close");
            gate2.GetComponent<Animator>().SetTrigger("close");
        }

    }

    IEnumerator spawnRoom1(float time)
    {
        GameObject enemy1 = Instantiate(glockDuck, spawnPoints[0].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy2 = Instantiate(glockDuck, spawnPoints[1].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy3 = Instantiate(glockDuck, spawnPoints[2].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
    }

    IEnumerator spawnRoom2(float time)
    {
        GameObject enemy1 = Instantiate(glockDuck, spawnPoints[0].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy2 = Instantiate(shotgunDuck, spawnPoints[1].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy3 = Instantiate(glockDuck, spawnPoints[2].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy4 = Instantiate(shotgunDuck, spawnPoints[3].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy5 = Instantiate(glockDuck, spawnPoints[4].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy6 = Instantiate(shotgunDuck, spawnPoints[5].position, Quaternion.identity);
    }

    IEnumerator spawnRoom3(float time)
    {
        GameObject enemy1 = Instantiate(glockDuck, spawnPoints[0].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy2 = Instantiate(shotgunDuck, spawnPoints[1].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy3 = Instantiate(glockDuck, spawnPoints[2].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy4 = Instantiate(shotgunDuck, spawnPoints[3].position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameObject enemy5 = Instantiate(glockDuck, spawnPoints[4].position, Quaternion.identity);

    }

}
