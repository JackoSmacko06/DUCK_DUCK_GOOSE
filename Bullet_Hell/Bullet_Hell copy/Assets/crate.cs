using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class crate : MonoBehaviour
{
    public static crate Instance;

    private Rigidbody2D rb;

    private SpriteRenderer spr;
    public Material flashMaterial;
    public float flashDuration;

    public GameObject brokenWood;
    public GameObject brokeneffect;

    public Transform coin1land;
    public Transform coin2land;
    public Transform coin3land;
    public Transform coin4land;
    public Transform coin5land;

    public GameObject coin;

    public float health;


    void Start()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();

        spr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (health <= 0)
        {
            //Instantiate(brokeneffect, transform.position, Quaternion.identity);

            sfxManager.instance.woodSmashSound();

            Instantiate(brokenWood, transform.position, Quaternion.identity);

            GameObject coin1 = Instantiate(coin, transform.position, Quaternion.identity);
            coin1.transform.DOMove(coin1land.position, .5f).SetEase(Ease.OutQuad);

            GameObject coin2 = Instantiate(coin, transform.position, Quaternion.identity);
            coin2.transform.DOMove(coin2land.position, .5f).SetEase(Ease.OutQuad);

            GameObject coin3 = Instantiate(coin, transform.position, Quaternion.identity);
            coin3.transform.DOMove(coin3land.position, .5f).SetEase(Ease.OutQuad);

            GameObject coin4 = Instantiate(coin, transform.position, Quaternion.identity);
            coin4.transform.DOMove(coin4land.position, .5f).SetEase(Ease.OutQuad);

            GameObject coin5 = Instantiate(coin, transform.position, Quaternion.identity);
            coin5.transform.DOMove(coin5land.position, .5f).SetEase(Ease.OutQuad);

            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(flash(flashDuration));

        sfxManager.instance.woodSound();

        health -= damage;
    }

    IEnumerator flash(float dur)
    {
        Material origionalMaterial = spr.material;
        spr.material = flashMaterial;

        yield return new WaitForSeconds(dur);

        spr.material = origionalMaterial;
    }

}
