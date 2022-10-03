using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    public static FireBullets instance;
    
    public int bulletsAmount = 10;

    public float fireRate;

    public float rotationSpeed;

    public bool staticfire;


    public float startAngle = 0f, endAngle = 360f;

    private Vector2 bulletMoveDirection;

    void Start()
    {
        instance = this;

        if (staticfire)
        {
            InvokeRepeating("Fire", 0f, fireRate);
        }
        

    }

    public void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = bulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.gameObject.SetActive(true);
                bul.GetComponent<_EnemyBullet>().SetMoveDirection(bulDir);

            angle += angleStep;

            startAngle += rotationSpeed;
            endAngle += rotationSpeed;
        }
    }
}
