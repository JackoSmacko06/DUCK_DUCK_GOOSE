using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWeapon : MonoBehaviour
{
    public bool slapHand;
    public bool AK47;
    public bool smg;
    public bool shotgun;
    public bool machinePistol;
    public bool robotArm;
    public bool minigun;

    private BoxCollider2D col;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        
        StartCoroutine(wait(1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            if (slapHand)
            {
                weaponSwitcher.instance.addSlapHand();
            }
            else if (AK47)
            {
                weaponSwitcher.instance.addAK47();
            }
            else if (smg)
            {
                //weaponSwitcher.instance.addSMG();
                weaponWheelController.instance.smgUnlocked = true;
            }
            else if (shotgun)
            {
                weaponWheelController.instance.shotgunUnlocked = true;
            }
            else if (machinePistol)
            {
                weaponWheelController.instance.machinePistolUnlocked = true;
            }
            else if (robotArm)
            {
                weaponWheelController.instance.robotarmUnlocked = true;
            }
            else if (minigun)
            {
                weaponWheelController.instance.minigunUnlocked = true;
            }

            Destroy(gameObject);
        }
    }

    IEnumerator wait(float time)
    {
        col.enabled = false;
        yield return new WaitForSeconds(time);
        col.enabled = true;
    }
}
