using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponWheelController : MonoBehaviour
{
    public static weaponWheelController instance;
    
    public static bool weaponSheelSelected = false;
    private Animator anim;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;

    public GameObject healthUI;

    [Space(10)]
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;

    public bool slot1Free = true;
    public bool slot2Free = true;
    public bool slot3Free = true;
    public bool slot4Free = true;



    [Space(10)]
    [Header("WEAPON BOOLS")]
    public bool starter;

    public bool pistolUnlocked = true;
    public bool pistolUsed;
    public bool smgUnlocked;
    public bool smgUsed;
    public bool shotgunUnlocked;
    public bool shotgunUsed;
    public bool robotarmUnlocked;
    public bool robotArmUsed;
    public bool machinePistolUnlocked;
    public bool machinePistolUsed;


    void Start()
    {
        instance = this;
        
        anim = GetComponent<Animator>();

        slot1Free = true;
        slot2Free = true;
        slot3Free = true;
        slot4Free = true;

        slot1.GetComponent<Button>().interactable = false;
        slot1.GetComponent<weaponWheelButton>().itemText.text = "";

        slot2.GetComponent<Button>().interactable = false;
        slot2.GetComponent<weaponWheelButton>().itemText.text = "";


        slot3.GetComponent<Button>().interactable = false;
        slot3.GetComponent<weaponWheelButton>().itemText.text = "";

        slot4.GetComponent<Button>().interactable = false;
        slot4.GetComponent<weaponWheelButton>().itemText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            weaponSheelSelected = true;

        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            weaponSheelSelected = false;
        }

        if (pistolUnlocked && !pistolUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = true;
                slot1.GetComponent<weaponWheelButton>().id = 2;
                slot1.GetComponent<weaponWheelButton>().itemName = "Pistol";
                slot1Free = false;
                pistolUsed = true;
                slot1.GetComponent<weaponWheelButton>().pistolSelected = true;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = true;
                slot2.GetComponent<weaponWheelButton>().id = 2;
                slot2.GetComponent<weaponWheelButton>().itemName = "Pistol";
                slot2Free = false;
                pistolUsed = true;
                slot2.GetComponent<weaponWheelButton>().pistolSelected = true;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = true;
                slot3.GetComponent<weaponWheelButton>().id = 2;
                slot3.GetComponent<weaponWheelButton>().itemName = "Pistol";
                slot3Free = false;
                pistolUsed = true;
                slot2.GetComponent<weaponWheelButton>().pistolSelected = true;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = true;
                slot4.GetComponent<weaponWheelButton>().id = 2;
                slot4.GetComponent<weaponWheelButton>().itemName = "Pistol";
                slot4Free = false;
                pistolUsed = true;
                slot2.GetComponent<weaponWheelButton>().pistolSelected = true;
            }
        }
        else if(!pistolUnlocked || pistolUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = false;
                slot1.GetComponent<weaponWheelButton>().id = 0;
                slot1.GetComponent<weaponWheelButton>().itemName = "";
                slot1Free = true;
                slot1.GetComponent<weaponWheelButton>().pistolSelected = false;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = false;
                slot2.GetComponent<weaponWheelButton>().id = 0;
                slot2.GetComponent<weaponWheelButton>().itemName = "";
                slot2Free = true;
                slot2.GetComponent<weaponWheelButton>().pistolSelected = false;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = false;
                slot3.GetComponent<weaponWheelButton>().id = 0;
                slot3.GetComponent<weaponWheelButton>().itemName = "";
                slot3Free = true;
                slot2.GetComponent<weaponWheelButton>().pistolSelected = false;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = false;
                slot4.GetComponent<weaponWheelButton>().id = 0;
                slot4.GetComponent<weaponWheelButton>().itemName = "";
                slot4Free = true;
                slot2.GetComponent<weaponWheelButton>().pistolSelected = false;
            }
        }

        if (smgUnlocked && !smgUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = true;
                slot1.GetComponent<weaponWheelButton>().id = 3;
                slot1.GetComponent<weaponWheelButton>().itemName = "SMG";
                slot1Free = false;
                smgUsed = true;
                slot1.GetComponent<weaponWheelButton>().smgSelected = true;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = true;
                slot2.GetComponent<weaponWheelButton>().smgSelected = true;
                slot2.GetComponent<weaponWheelButton>().id = 3;
                slot2.GetComponent<weaponWheelButton>().itemName = "SMG";
                slot2Free = false;
                smgUsed = true;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = true;
                slot3.GetComponent<weaponWheelButton>().smgSelected = true;
                slot3.GetComponent<weaponWheelButton>().id = 3;
                slot3.GetComponent<weaponWheelButton>().itemName = "SMG";
                slot3Free = false;
                smgUsed = true;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = true;
                slot4.GetComponent<weaponWheelButton>().smgSelected = true;
                slot4.GetComponent<weaponWheelButton>().id = 3;
                slot4.GetComponent<weaponWheelButton>().itemName = "SMG";
                slot4Free = false;
                smgUsed = true;
            }
        }
        else if (!smgUnlocked || smgUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = false;
                slot1.GetComponent<weaponWheelButton>().id = 0;
                slot1.GetComponent<weaponWheelButton>().itemName = "";
                slot1Free = true;
                slot1.GetComponent<weaponWheelButton>().smgSelected = false;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = false;
                slot2.GetComponent<weaponWheelButton>().id = 0;
                slot2.GetComponent<weaponWheelButton>().itemName = "";
                slot2Free = true;
                slot2.GetComponent<weaponWheelButton>().smgSelected = false;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = false;
                slot3.GetComponent<weaponWheelButton>().id = 0;
                slot3.GetComponent<weaponWheelButton>().itemName = "";
                slot3Free = true;
                slot2.GetComponent<weaponWheelButton>().smgSelected = false;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = false;
                slot4.GetComponent<weaponWheelButton>().id = 0;
                slot4.GetComponent<weaponWheelButton>().itemName = "";
                slot4Free = true;
                slot2.GetComponent<weaponWheelButton>().smgSelected = false;
            }
        }

        if (shotgunUnlocked && !shotgunUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = true;
                slot1.GetComponent<weaponWheelButton>().id = 4;
                slot1.GetComponent<weaponWheelButton>().itemName = "Shotgun";
                slot1Free = false;
                shotgunUsed = true;
                slot1.GetComponent<weaponWheelButton>().shotgunSelected = true;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = true;
                slot2.GetComponent<weaponWheelButton>().shotgunSelected = true;
                slot2.GetComponent<weaponWheelButton>().id = 4;
                slot2.GetComponent<weaponWheelButton>().itemName = "Shotgun";
                slot2Free = false;
                shotgunUsed = true;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = true;
                slot4.GetComponent<weaponWheelButton>().shotgunSelected = true;
                slot3.GetComponent<weaponWheelButton>().id = 4;
                slot3.GetComponent<weaponWheelButton>().itemName = "Shotgun";
                slot3Free = false;
                shotgunUsed = true;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = true;
                slot4.GetComponent<weaponWheelButton>().shotgunSelected = true;
                slot4.GetComponent<weaponWheelButton>().id = 4;
                slot4.GetComponent<weaponWheelButton>().itemName = "Shotgun";
                slot4Free = false;
                shotgunUsed = true;
            }
        }
        else if (!shotgunUnlocked || shotgunUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = false;
                slot1.GetComponent<weaponWheelButton>().id = 0;
                slot1.GetComponent<weaponWheelButton>().itemName = "";
                slot1Free = true;
                slot1.GetComponent<weaponWheelButton>().shotgunSelected = false;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = false;
                slot2.GetComponent<weaponWheelButton>().id = 0;
                slot2.GetComponent<weaponWheelButton>().itemName = "";
                slot2Free = true;
                slot2.GetComponent<weaponWheelButton>().shotgunSelected = false;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = false;
                slot3.GetComponent<weaponWheelButton>().id = 0;
                slot3.GetComponent<weaponWheelButton>().itemName = "";
                slot3Free = true;
                slot3.GetComponent<weaponWheelButton>().shotgunSelected = false;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = false;
                slot4.GetComponent<weaponWheelButton>().id = 0;
                slot4.GetComponent<weaponWheelButton>().itemName = "";
                slot4Free = true;
                slot4.GetComponent<weaponWheelButton>().shotgunSelected = false;
            }
        }

        if (robotarmUnlocked && !robotArmUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = true;
                slot1.GetComponent<weaponWheelButton>().robotArmSelected = true;
                slot1.GetComponent<weaponWheelButton>().id = 5;
                slot1.GetComponent<weaponWheelButton>().itemName = "Severed Robot Arm";
                slot1Free = false;
                robotArmUsed = true;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = true;
                slot2.GetComponent<weaponWheelButton>().robotArmSelected = true;
                slot2.GetComponent<weaponWheelButton>().id = 5;
                slot2.GetComponent<weaponWheelButton>().itemName = "Severed Robot Arm";
                slot2Free = false;
                robotArmUsed = true;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = true;
                slot3.GetComponent<weaponWheelButton>().robotArmSelected = true;
                slot3.GetComponent<weaponWheelButton>().id = 5;
                slot3.GetComponent<weaponWheelButton>().itemName = "Severed Robot Arm";
                slot3Free = false;
                robotArmUsed = true;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = true;
                slot4.GetComponent<weaponWheelButton>().robotArmSelected = true;
                slot4.GetComponent<weaponWheelButton>().id = 5;
                slot4.GetComponent<weaponWheelButton>().itemName = "Severed Robot Arm";
                slot4Free = false;
                robotArmUsed = true;
            }
        }
        else if (!robotarmUnlocked || robotArmUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = false;
                slot1.GetComponent<weaponWheelButton>().id = 0;
                slot1.GetComponent<weaponWheelButton>().itemName = "";
                slot1Free = true;
                slot1.GetComponent<weaponWheelButton>().robotArmSelected = false;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = false;
                slot2.GetComponent<weaponWheelButton>().id = 0;
                slot2.GetComponent<weaponWheelButton>().itemName = "";
                slot2Free = true;
                slot2.GetComponent<weaponWheelButton>().robotArmSelected = false;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = false;
                slot3.GetComponent<weaponWheelButton>().id = 0;
                slot3.GetComponent<weaponWheelButton>().itemName = "";
                slot3Free = true;
                slot3.GetComponent<weaponWheelButton>().robotArmSelected = false;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = false;
                slot4.GetComponent<weaponWheelButton>().id = 0;
                slot4.GetComponent<weaponWheelButton>().itemName = "";
                slot4Free = true;
                slot4.GetComponent<weaponWheelButton>().robotArmSelected = false;
            }
        }

        if (machinePistolUnlocked && !machinePistolUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = true;
                slot1.GetComponent<weaponWheelButton>().machinePistolSelected = true;
                slot1.GetComponent<weaponWheelButton>().id = 6;
                slot1.GetComponent<weaponWheelButton>().itemName = "Machine Pistol";
                slot1Free = false;
                machinePistolUsed = true;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = true;
                slot2.GetComponent<weaponWheelButton>().machinePistolSelected = true;
                slot2.GetComponent<weaponWheelButton>().id = 6;
                slot2.GetComponent<weaponWheelButton>().itemName = "Machine Pistol";
                slot2Free = false;
                machinePistolUsed = true;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = true;
                slot3.GetComponent<weaponWheelButton>().machinePistolSelected = true;
                slot3.GetComponent<weaponWheelButton>().id = 6;
                slot3.GetComponent<weaponWheelButton>().itemName = "Machine Pistol";
                slot3Free = false;
                machinePistolUsed = true;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = true;
                slot4.GetComponent<weaponWheelButton>().machinePistolSelected = true;
                slot4.GetComponent<weaponWheelButton>().id = 6;
                slot4.GetComponent<weaponWheelButton>().itemName = "Machine Pistol";
                slot4Free = false;
                machinePistolUsed = true;
            }
        }
        else if (!machinePistolUnlocked || machinePistolUsed)
        {
            if (slot1Free)
            {
                slot1.GetComponent<Button>().interactable = false;
                slot1.GetComponent<weaponWheelButton>().id = 0;
                slot1.GetComponent<weaponWheelButton>().itemName = "";
                slot1Free = true;
                slot1.GetComponent<weaponWheelButton>().machinePistolSelected = false;
            }
            else if (slot2Free)
            {
                slot2.GetComponent<Button>().interactable = false;
                slot2.GetComponent<weaponWheelButton>().id = 0;
                slot2.GetComponent<weaponWheelButton>().itemName = "";
                slot2Free = true;
                slot3.GetComponent<weaponWheelButton>().machinePistolSelected = false;
            }
            else if (slot3Free)
            {
                slot3.GetComponent<Button>().interactable = false;
                slot3.GetComponent<weaponWheelButton>().machinePistolSelected = false;
                slot3.GetComponent<weaponWheelButton>().id = 0;
                slot3.GetComponent<weaponWheelButton>().itemName = "";
                slot3Free = true;
            }
            else if (slot4Free)
            {
                slot4.GetComponent<Button>().interactable = false;
                slot4.GetComponent<weaponWheelButton>().machinePistolSelected = false;
                slot4.GetComponent<weaponWheelButton>().id = 0;
                slot4.GetComponent<weaponWheelButton>().itemName = "";
                slot4Free = true;
            }
        }





        if (weaponSheelSelected)
        {
            anim.SetBool("opened", true);
            healthUI.SetActive(false);
             
        }
        else if (!weaponSheelSelected)
        {
            anim.SetBool("opened", false);
            healthUI.SetActive(true);

        }

        switch (weaponID)
        {
            case 0: //nothing
                selectedItem.sprite = noImage;
                //weaponWheelButton.instance.button.interactable = false;
                break;
            case 2: //Pistol
                weaponSwitcher.instance.pistol.SetActive(true);
                weaponWheelButton.instance.button.interactable = true;


                weaponSwitcher.instance.SMG.SetActive(false);
                weaponSwitcher.instance.shotgun.SetActive(false);
                weaponSwitcher.instance.robotArm.SetActive(false);
                weaponSwitcher.instance.machinePistol.SetActive(false);

                break;
            case 3: //SMG
                weaponSwitcher.instance.SMG.SetActive(true);
                weaponWheelButton.instance.button.interactable = true;

                weaponSwitcher.instance.pistol.SetActive(false);
                weaponSwitcher.instance.shotgun.SetActive(false);
                weaponSwitcher.instance.robotArm.SetActive(false);
                weaponSwitcher.instance.machinePistol.SetActive(false);

                break;
            case 4: //Shotgun
                weaponSwitcher.instance.shotgun.SetActive(true);
                weaponWheelButton.instance.button.interactable = true;

                weaponSwitcher.instance.SMG.SetActive(false);
                weaponSwitcher.instance.pistol.SetActive(false);
                weaponSwitcher.instance.robotArm.SetActive(false);
                weaponSwitcher.instance.machinePistol.SetActive(false);

                break;
            case 5: //Severed Robot Arm
                weaponSwitcher.instance.robotArm.SetActive(true);
                weaponWheelButton.instance.button.interactable = true;

                weaponSwitcher.instance.SMG.SetActive(false);
                weaponSwitcher.instance.pistol.SetActive(false);
                weaponSwitcher.instance.shotgun.SetActive(false);
                weaponSwitcher.instance.machinePistol.SetActive(false);

                break;
            case 6: //Machine Pistol
                weaponSwitcher.instance.machinePistol.SetActive(true);
                weaponWheelButton.instance.button.interactable = true;

                weaponSwitcher.instance.SMG.SetActive(false);
                weaponSwitcher.instance.pistol.SetActive(false);
                weaponSwitcher.instance.shotgun.SetActive(false);
                weaponSwitcher.instance.robotArm.SetActive(false);

                break;
            case 7: //6
                ;
                break;
            case 8: //7
                
                break;
        }



    }

    public void slow()
    {
        Time.timeScale = 0.07f;
    }
    public void unSlow()
    {
        Time.timeScale = 1f;
    }

}
