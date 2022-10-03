using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{
    public static sfxManager instance;
    
    public AudioSource src;
    public AudioSource srcLoud;
    public AudioClip shot1, shot2, shot3, shot4;
    public AudioClip smg;
    public AudioClip glock;
    public AudioClip ak47;
    public AudioClip shotgun;
    public AudioClip hitEnemy;
    public AudioClip slap;
    public AudioClip woodHit;
    public AudioClip coin;
    public AudioClip damagePlayer;
    public AudioClip woodSmash;
    public AudioClip shotgunPlayer;
    public AudioClip pistolReload;
    public AudioClip smgReload;
    public AudioClip shotgunReload;
    public AudioClip metalHit;
    public AudioClip laserShoot1;
    public AudioClip laserreload;
    public AudioClip machinePistolShoot;
    public AudioClip machinePistolReload;
    public AudioClip minigunshot;

    private void Start()
    {
        instance = this; 
    }

    public void Player_Fire_Pistol()
    {
        float rand = Random.Range(1, 4);

        if(rand == 1)
        {
            src.PlayOneShot(shot1);
        }
        else if(rand == 2)
        {
            src.PlayOneShot(shot2);
        }
        else if(rand == 3)
        {
            src.PlayOneShot(shot3);
        }
        else if(rand == 4)
        {
            src.PlayOneShot(shot4);
        }
    }
    public void SMGsound()
    {
        src.PlayOneShot(smg);
    }
    public void Glocksound()
    {
        src.PlayOneShot(glock);
    }
    public void ak47sound()
    {
        src.PlayOneShot(ak47);
    }
    public void Shotgunsound()
    {
        src.PlayOneShot(shotgun);
    }
    public void hitEnemySound()
    {
        src.PlayOneShot(hitEnemy);
    }
    public void slapSound()
    {
        srcLoud.PlayOneShot(slap);
    }
    public void woodSound()
    {
        srcLoud.PlayOneShot(woodHit);
    }
    public void coinSound()
    {
        srcLoud.PlayOneShot(coin);
    }
    public void damagePlayerSound()
    {
        srcLoud.PlayOneShot(damagePlayer);
    }
    public void woodSmashSound()
    {
        srcLoud.PlayOneShot(woodSmash);
    }
    public void shotgunPlayerSound()
    {
        srcLoud.PlayOneShot(shotgunPlayer);
    }
    public void pistolReloadSound()
    {
        srcLoud.PlayOneShot(pistolReload);
    }
    public void smgReloadSound()
    {
        srcLoud.PlayOneShot(smgReload);
    }
    public void shotgunReloadSound()
    {
        srcLoud.PlayOneShot(shotgunReload);
    }
    public void metalHitSound()
    {
        float rand = Random.Range(0.92f, 1.08f);
        
        srcLoud.pitch = rand;
        srcLoud.PlayOneShot(metalHit);
    }
    public void laserShootSound()
    {
        float rand = Random.Range(0.92f, 1.08f);

        src.pitch = rand;
        src.PlayOneShot(laserShoot1);
    }
    public void laserreloadSound()
    {
        srcLoud.PlayOneShot(laserreload);
    }
    public void machinePistolSound()
    {
        src.PlayOneShot(machinePistolShoot);
    }
    public void lmachinePistolReloadSound()
    {
        srcLoud.PlayOneShot(machinePistolReload);
    }
    public void minigunShotSound()
    {
        srcLoud.PlayOneShot(minigunshot);
    }
}
