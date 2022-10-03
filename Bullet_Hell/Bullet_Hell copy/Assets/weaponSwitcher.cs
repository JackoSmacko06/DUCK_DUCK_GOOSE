using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitcher : MonoBehaviour
{
    public static weaponSwitcher instance;


    [HideInInspector] public bool weapon1Selected = true;
    [HideInInspector] public bool weapon2Selected = false;

    public bool Default;


    private GameObject weapon1;

    private GameObject weapon2;

    private GameObject currentGun;

    public GameObject pistol;
    public GameObject ak47;
    public GameObject SMG;
    public GameObject shotgun;
    public GameObject slapHand;
    public GameObject robotArm;
    public GameObject machinePistol;
    public GameObject minigun;

    private void Start()
    {
        instance = this;
        
        /*weapon1Selected = true;
        currentGun = weapon1;
        weapon1 = pistol;

        weapon2 = null;

        if (Default)
        {
            weapon1 = pistol;
            weapon2 = SMG;
        }*/

        //switchGun();
        //switchGun();

        pistol.SetActive(true);
    }

    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            switchGun();
        }*/


        /*if (weapon1Selected)
        {
            currentGun = weapon1;

            weapon1.SetActive(true);

            if (weapon2 != null)
            {
                weapon2.SetActive(false);
            }
        }
        else if (weapon2Selected)
        {
            currentGun = weapon2;

            weapon2.SetActive(true);
            weapon1.SetActive(false);
        }*/
    }

    public void switchGun()
    {
        if (weapon1Selected)
        {
            if(weapon2 != null)
            {
                weapon2Selected = true;
                weapon1Selected = false;

                currentGun = weapon2;

            }
            
        }
        else if (weapon2Selected)
        {
            weapon1Selected = true;
            weapon2Selected = false;

            currentGun = weapon1;

        }

        StartCoroutine(wait(0.4f));
    }

    public void addSlapHand()
    {
        weapon2 = slapHand;
    }
    public void addAK47()
    {
        //weaponWheelController.instance.ak47Unlocked = true;
    }
    public void addSMG()
    {
        weaponWheelController.instance.smgUnlocked = true;
    }
    public void addShotgun()
    {
        weaponWheelController.instance.shotgunUnlocked = true;
    }
    public void addRobotArm()
    {
        weaponWheelController.instance.robotarmUnlocked = true;
    }
    public void addmachinePistol()
    {
        weaponWheelController.instance.machinePistolUnlocked = true;
    }
    public void addMinigun()
    {
        weaponWheelController.instance.minigunUnlocked = true;
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);

        pistol.GetComponent<Weapon>().timer = 0;
        shotgun.GetComponent<Weapon>().timer = 0;
        SMG.GetComponent<Weapon>().timer = 0;
        ak47.GetComponent<Weapon>().timer = 0;
        robotArm.GetComponent<Weapon>().timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("slapHandDrop"))
        {
            weapon2 = slapHand;

            Destroy(collision.gameObject);
        }
    }

}
