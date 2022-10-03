using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class weaponWheelButton : MonoBehaviour
{
    public static weaponWheelButton instance;
    
    public int id;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    public Image image;
    private bool selected = false;
    public Sprite Pistol;
    public Sprite SMG;
    public Sprite Shotgun;
    public Sprite RobotArm;
    public Sprite MachinePistol;
    public Sprite none;
    [HideInInspector] public Button button;

    [HideInInspector] public bool pistolSelected;
    [HideInInspector] public bool smgSelected;
    [HideInInspector] public bool shotgunSelected;
    [HideInInspector] public bool robotArmSelected;
    [HideInInspector] public bool machinePistolSelected;
    [HideInInspector] public bool minigunSelected;

    public GameObject pistol;
    public GameObject smg;
    public GameObject shotgun;
    public GameObject robotArm;
    public GameObject machinePistol;
    public GameObject minigun;

    public bool slot1;
    public bool slot2;
    public bool slot3;
    public bool slot4;


    void Start()
    {
        instance = this;

        button = GetComponent<Button>();

    }


    void Update()
    {
        if (selected)
        {
            itemText.text = itemName;
        }

        if (pistolSelected)
        {
            pistol.SetActive(true);
            smg.SetActive(false);
            shotgun.SetActive(false);
            robotArm.SetActive(false);
            machinePistol.SetActive(false);
            minigun.SetActive(false);
        }
        else if (smgSelected)
        {
            pistol.SetActive(false);
            smg.SetActive(true);
            shotgun.SetActive(false);
            robotArm.SetActive(false);
            machinePistol.SetActive(false);
            minigun.SetActive(false);
        }
        else if (shotgunSelected)
        {
            pistol.SetActive(false);
            smg.SetActive(false);
            shotgun.SetActive(true);
            robotArm.SetActive(false);
            machinePistol.SetActive(false);
            minigun.SetActive(false);
        }
        else if (robotArmSelected)
        {
            pistol.SetActive(false);
            smg.SetActive(false);
            shotgun.SetActive(false);
            robotArm.SetActive(true);
            machinePistol.SetActive(false);
            minigun.SetActive(false);
        }
        else if (machinePistolSelected)
        {
            pistol.SetActive(false);
            smg.SetActive(false);
            shotgun.SetActive(false);
            robotArm.SetActive(false);
            machinePistol.SetActive(true);
            minigun.SetActive(false);
        }
        else if (minigunSelected)
        {
            pistol.SetActive(false);
            smg.SetActive(false);
            shotgun.SetActive(false);
            robotArm.SetActive(false);
            machinePistol.SetActive(false);
            minigun.SetActive(true);
        }
    }

    public void Selected()
    {
        selected = true;
        if (button.interactable == true)
        {
            weaponWheelController.weaponID = id;
            weaponWheelController.weaponSheelSelected = false;
        }
        
    }

    public void DeSelected()
    {
        selected = false;
        weaponWheelController.weaponID = 0;
        itemText.text = "";
    }

    public void HoverEnter()
    {
        if(button.interactable == true)
        {
            itemText.text = itemName;
            weaponWheelController.weaponID = id;
        }      
    }

    public void HoverExit()
    {
        itemText.text = "";
        weaponWheelController.weaponID = 0;
    }
}
