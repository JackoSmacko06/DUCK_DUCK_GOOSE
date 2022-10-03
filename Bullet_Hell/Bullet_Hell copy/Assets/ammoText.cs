using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ammoText : MonoBehaviour
{
    public weaponSwitcher weapon;
    public TextMeshProUGUI text;

    public bool clip, ammo;

    private void Start()
    {
        updateAmmoText();
    }

    private void Update()
    {
        updateAmmoText();
    }

    public void updateAmmoText()
    {

        
        if (clip)
        {
            if (weaponWheelController.weaponID == 2)
            {
                text.text = $"{weapon.pistol.GetComponent<Weapon>().currentClip} | {weapon.pistol.GetComponent<Weapon>().maxClipSize}";
                
            }
            else if (weaponWheelController.weaponID == 3)
            {
                text.text = $"{weapon.SMG.GetComponent<Weapon>().currentClip} | {weapon.SMG.GetComponent<Weapon>().maxClipSize}";
            }
            else if (weaponWheelController.weaponID == 4)
            {
                text.text = $"{weapon.shotgun.GetComponent<Weapon>().currentClip} | {weapon.shotgun.GetComponent<Weapon>().maxClipSize}";
            }
            else if (weaponWheelController.weaponID == 5)
            {
                text.text = $"{weapon.robotArm.GetComponent<Weapon>().currentClip} | {weapon.robotArm.GetComponent<Weapon>().maxClipSize}";
            }
            else if (weaponWheelController.weaponID == 6)
            {
                text.text = $"{weapon.machinePistol.GetComponent<Weapon>().currentClip} | {weapon.machinePistol.GetComponent<Weapon>().maxClipSize}";
            }
            else if (weaponWheelController.weaponID == 7)
            {
                text.text = $"{weapon.minigun.GetComponent<Weapon>().currentClip} | {weapon.minigun.GetComponent<Weapon>().maxClipSize}";
            }
        }
        else if (ammo)
        {
            if (weapon.weapon1Selected)
            {
                //text.text = $"{weapon.weapon1.GetComponent<Weapon>().currentAmmo} | {weapon.weapon1.GetComponent<Weapon>().maxAmmoSize}";
            }
            else if (weapon.weapon2Selected)
            {
                //text.text = $"{weapon.weapon2.GetComponent<Weapon>().currentAmmo} | {weapon.weapon2.GetComponent<Weapon>().maxAmmoSize}";
            }
        }
        
        
        
    }
}
