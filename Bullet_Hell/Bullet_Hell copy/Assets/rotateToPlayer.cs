using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToPlayer : MonoBehaviour
{
    public static rotateToPlayer instance;

    private GameObject player;

    public GameObject enemy;

    public float RotationZ;


    private void Start()
    {
        
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 difference = player.transform.position - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, -rotationZ);

        RotationZ = rotationZ;

        if (rotationZ < -90 || rotationZ > 90)
        {
            if (enemy.transform.eulerAngles.y <= 0)
            {

                transform.localRotation = Quaternion.Euler(180, 0, rotationZ);

            }
            else if (enemy.transform.eulerAngles.y == 180)
            {

                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);

            }
        }
    }
}
