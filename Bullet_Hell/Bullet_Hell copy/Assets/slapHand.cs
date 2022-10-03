using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slapHand : MonoBehaviour
{
    public int damage;
    private GameObject player;


    private Vector2 mousePosition;
    public float rotationZ;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        rotateToMouse();
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
            else if (player.transform.eulerAngles.y == 180)
            {

                transform.localRotation = Quaternion.Euler(180, 180, -RotationZ);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            sfxManager.instance.slapSound();

            cameraShake.instance.Shake(5f, 10f, .1f);
        }
    }
}
