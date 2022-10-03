using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteFlipper : MonoBehaviour
{

    public float rotationZ;

    public GameObject player;

    private void Update()
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
            else if (player.transform.eulerAngles.y == 180)
            {

                transform.localRotation = Quaternion.Euler(180, 180, -RotationZ);

            }
        }
    }
}
