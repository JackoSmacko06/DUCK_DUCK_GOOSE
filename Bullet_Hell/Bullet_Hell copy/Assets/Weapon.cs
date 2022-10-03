using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;
    
    [Header("GUN TYPE")]
    public bool pistol;
    public bool AK47;
    public bool smg;
    public bool shotgun;
    public bool laser;
    public bool machinePistol;
    public bool miniGun;

    public int maxClipSize, maxAmmoSize;
    public int currentClip, currentAmmo;
    public float reloadTime;

    public float damage;

    public bool canShoot;
    private Animator anim;
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform firePos;
    public GameObject muzzleFlash1;
    public GameObject muzzleFlash2;
    public float fireSpeed;
    public float cooldown;
    public float timer;
    private Vector2 mousePosition;
    public float rotationZ;
    public float accuracy;

    public GameObject reloadWarning;

    public float radius;

    private void OnEnable()
    {
        timer = 0;
        canShoot = true;
    }
    private void Start()
    {
        instance = this;

        canShoot = true;

        timer = cooldown;

        currentAmmo = maxAmmoSize;
        currentClip = maxClipSize;

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(currentClip < maxClipSize)
            {
                reload();
            }
        }

        if(currentClip <= 0)
        {
            reloadWarning.SetActive(true);
        }
        else
        {
            //reloadWarning.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            if (canShoot)
            {
                if (currentClip > 0)
                {
                    if (shotgun)
                    {
                        if (timer <= 0)
                        {
                            fire();
                            fire();
                            fire();
                            fire();
                            fire();

                            currentClip--;

                            timer = cooldown;
                        }
                    }
                    else
                    {
                        if (timer <= 0)
                        {
                            fire();
                            currentClip--;
                            timer = cooldown;
                        }
                    }
                }
                else if(currentClip <= 0)
                {
                    if (pistol || machinePistol)
                    {
                        StartCoroutine(waitToReload(0.2f));
                    }
                    else if (shotgun)
                    {
                        StartCoroutine(waitToReload(1f));
                    }
                    else
                    {
                        StartCoroutine(waitToReload(0.5f));
                    }
                    
                }
            } 

        }

        timer -= Time.deltaTime;

        rotateToMouse();

    }


    public void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        bullet.GetComponent<PlayerBullet>().damage = damage;
        float randomZ = Random.Range(-accuracy, accuracy);

        float origionalRotation = firePos.rotation.z;

        firePos.transform.Rotate(0, 0, randomZ);

        bullet.GetComponent<Rigidbody2D>().AddForce(firePos.up * fireSpeed, ForceMode2D.Impulse);

        firePos.transform.Rotate(0, 0, -randomZ);

        anim.SetTrigger("fire");

        //crosshair.instance.fireAnim();
        StartCoroutine(MuzzleFlash());

        if (pistol)
        {
            sfxManager.instance.Player_Fire_Pistol();
            

        }else if (AK47)
        {
            sfxManager.instance.ak47sound();
        }
        else if (smg)
        {
            sfxManager.instance.SMGsound();
        }
        else if (shotgun)
        {
            sfxManager.instance.shotgunPlayerSound();
        }
        else if (laser)
        {
            sfxManager.instance.laserShootSound();
        }
        else if (machinePistol)
        {
            sfxManager.instance.machinePistolSound();
        }

        cameraShake.instance.Shake(4f, 10f, .1f);
    }

    public void reload()
    {
        anim.SetTrigger("reload");
        

        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void addAmmo(int ammoAmout)
    {
        currentAmmo += ammoAmout;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }

    }

    void rotateToMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float RotationZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, -RotationZ);


        rotationZ = RotationZ;


        if (RotationZ < -90 || RotationZ > 90)
        {
            if (player.transform.eulerAngles.y <= 0)
            {
                
                transform.localRotation = Quaternion.Euler(180, 0, RotationZ);

            }
            else if(player.transform.eulerAngles.y  == 180)
            {

                transform.localRotation = Quaternion.Euler(180, 180, -RotationZ);

            }
        }
    }

    public IEnumerator MuzzleFlash()
    {
        float randomNumber = Random.Range(0, 2);


        if (randomNumber == 0)
        {
            muzzleFlash1.SetActive(true);

            yield return new WaitForSeconds(0.1f);

            muzzleFlash1.SetActive(false);
        }
        else if(randomNumber == 1)
        {
            muzzleFlash2.SetActive(true);

            yield return new WaitForSeconds(0.1f);

            muzzleFlash2.SetActive(false);
        }
        
        
    }

    public IEnumerator waitToReload(float time)
    {
        yield return new WaitForSeconds(time);

        reload();
    }

    public void canShootFalse()
    {
        canShoot = false;
    }

    public void canShootTrue()
    {
       canShoot = true;
        reloadWarning.SetActive(false);
    }
    public void makeSound()
    {
        if (pistol)
        {
            sfxManager.instance.pistolReloadSound();
        }
        else if (smg)
        {
            sfxManager.instance.smgReloadSound();
        }
        else if (shotgun)
        {
            sfxManager.instance.shotgunReloadSound();
        }
        else if (laser)
        {
            sfxManager.instance.laserreloadSound();
        }
        else if (machinePistol)
        {
            sfxManager.instance.lmachinePistolReloadSound();
        }
        else if (miniGun)
        {
            sfxManager.instance.minigunShotSound();
        }
    }

}
