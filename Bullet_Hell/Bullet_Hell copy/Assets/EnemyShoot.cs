using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyShoot : MonoBehaviour
{
    public static EnemyShoot instance;

    private GameObject player;

    [Header("WEAPON TYPES")]
    public bool Pistol;
    public bool SMG;
    public bool Shotgun;

    [Space(10)]
    [Header("Shooting")]
    public bool canShoot;
    public GameObject bullet;
    public Transform firePos1;

    public float cooldownMin;
    public float cooldownMax;

    public float cooldown;
    private float timer;

    public float accuracy;

    public float rotaionZ;

    public float bulletSpeed;

    public GameObject muzzleFlash1;
    public GameObject muzzleFlash2;

    public float racastLength;
    public LayerMask wall;


    [Space(10)]
    [Header("SMG")]
    public float restTime;
    public bool canshootSMG;

    [Space(10)]
    [Header("Shotgun")]
    public Transform firePos2;
    public Transform firePos3;
    public Transform firePos4;
    public Transform firePos5;





    private void Start()
    {
        instance = this;
        
        timer = cooldown;

        canshootSMG = true;

        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {

        if(player != null)
        {
            Vector2 fromPos = transform.position;
            Vector2 toPos = player.transform.position;
            Vector2 direction = toPos - fromPos;

            RaycastHit2D hit = Physics2D.Raycast(fromPos, direction, racastLength);

            Debug.DrawRay(fromPos, direction, Color.yellow);

            if (hit.collider.tag == ("obstacle"))
            {
                canShoot = false;
            }
        }
        


        if (canShoot)
        {
            if (Pistol)
            {
                if (timer <= 0)
                {
                    fire();

                    timer = Random.Range(cooldownMin, cooldownMax);
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            else if (SMG)
            {
                if (canshootSMG)
                {
                    StartCoroutine(SMGshoot(restTime, cooldown));
                }
                
            }
            else if (Shotgun)
            {
                if (timer <= 0)
                {
                    shotgunFire();

                    timer = cooldown;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            
        }
    }

    public void fire()
    {
        if(player != null)
        {
            GameObject bul = Instantiate(bullet, firePos1.position, Quaternion.identity);
            bul.GetComponent<Rigidbody2D>().AddForce(firePos1.up * bulletSpeed, ForceMode2D.Impulse);

            if (Pistol)
            {
                sfxManager.instance.Glocksound();
                StartCoroutine(MuzzleFlash());
            }
            else if (SMG)
            {
                sfxManager.instance.SMGsound();
                StartCoroutine(MuzzleFlash());
            }


        }

    }

    public void shotgunFire()
    {
        if(player != null)
        {
            GameObject shot1 = Instantiate(bullet, firePos1.position, firePos1.rotation);
            shot1.GetComponent<Rigidbody2D>().AddForce(firePos1.up * bulletSpeed, ForceMode2D.Impulse);

            GameObject shot2 = Instantiate(bullet, firePos2.position, firePos2.rotation);
            shot2.GetComponent<Rigidbody2D>().AddForce(firePos2.up * bulletSpeed, ForceMode2D.Impulse);

            GameObject shot3 = Instantiate(bullet, firePos3.position, firePos3.rotation);
            shot3.GetComponent<Rigidbody2D>().AddForce(firePos3.up * bulletSpeed, ForceMode2D.Impulse);

            GameObject shot4 = Instantiate(bullet, firePos4.position, firePos4.rotation);
            shot4.GetComponent<Rigidbody2D>().AddForce(firePos4.up * bulletSpeed, ForceMode2D.Impulse);

            GameObject shot5 = Instantiate(bullet, firePos5.position, firePos5.rotation);
            shot5.GetComponent<Rigidbody2D>().AddForce(firePos5.up * bulletSpeed, ForceMode2D.Impulse);

            StartCoroutine(MuzzleFlash());
            sfxManager.instance.Shotgunsound();

        }


    }

    IEnumerator SMGshoot(float restTime, float cooldown)
    {
        canshootSMG = false;
        for (int i = 0; i < 10; i++)
        {
            fire();
            yield return new WaitForSeconds(cooldown);
        }

        yield return new WaitForSeconds(restTime);
        canshootSMG = true;
    }

    IEnumerator MuzzleFlash()
    {
        float rand = Random.Range(0, 2);

        if (rand == 0)
        {
            muzzleFlash1.SetActive(true);

            yield return new WaitForSeconds(0.1f);

            muzzleFlash1.SetActive(false);
        }
        else if (rand == 1)
        {
            muzzleFlash2.SetActive(true);

            yield return new WaitForSeconds(0.1f);

            muzzleFlash2.SetActive(false);
        }


    }



}
