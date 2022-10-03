using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public int health;
    public int numOfHearts;
    private Rigidbody2D rb;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Vector2 respawnPos;

    public GameObject shadow;

    public float slowTime = 0.2f;
    public bool isSlowed = false;
    public float SlowTimeLength;

    public bool canTakeDamage = true;
    public float InvincibilityTime;
    private SpriteRenderer spr;
    public Color invisColor;


    void Start()
    {
        Instance = this;

        spr = GetComponent<SpriteRenderer>();

        rb = spr.GetComponent<Rigidbody2D>();

        health = 3;

    }


    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
        if (health <= 0)
        {
            StartCoroutine(DIE(2));

            health = 3;
            transform.position = respawnPos;
            PlayerController.instance.canMove = true;
            shadow.SetActive(true);
            spr.enabled = true;
            PlayerController.instance.gun.SetActive(true);
            StartCoroutine(IFrames(0.2f));
        }
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            sfxManager.instance.damagePlayerSound();
            cameraShake.instance.Shake(4f, 10f, .1f);     
            StartCoroutine(SSlowTime());

            if (health > 0)
            {
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("enemy_bullet");
                foreach (GameObject bullet in bullets)
                {
                    bullet.SetActive(false);
                }

                StartCoroutine(IFrames(0.2f));
            }


        }
    }

    IEnumerator IFrames(float waitTime)
    {
        canTakeDamage = false;
        spr.color = invisColor;
        yield return new WaitForSeconds(waitTime);
        spr.color = Color.white;
        yield return new WaitForSeconds(waitTime);
        spr.color = invisColor;
        yield return new WaitForSeconds(waitTime);
        spr.color = Color.white;
        yield return new WaitForSeconds(waitTime);
        spr.color = invisColor;
        yield return new WaitForSeconds(waitTime);
        spr.color = Color.white;
        yield return new WaitForSeconds(waitTime);
        spr.color = invisColor;
        yield return new WaitForSeconds(waitTime);
        spr.color = Color.white;
        yield return new WaitForSeconds(waitTime);
        canTakeDamage = true;      
    }

    IEnumerator SSlowTime()
    {
        SlowTime();
        yield return new WaitForSecondsRealtime(SlowTimeLength);
        SlowTime();
    }

    public void SlowTime()
    {
        if (isSlowed)
        {
            isSlowed = false;
            Time.timeScale = 1;
            Time.fixedDeltaTime -= Time.deltaTime;
        }
        else
        {
            isSlowed = true;
            Time.timeScale = slowTime;
            Time.fixedDeltaTime = slowTime * Time.deltaTime;
        }
    }

    public IEnumerator DIE(float time)
    {
        PlayerController.instance.canMove = false;
        rb.velocity = Vector2.zero;
        shadow.SetActive(false);
        spr.enabled = false;
        canTakeDamage = false;
        PlayerController.instance.gun.SetActive(false);

        yield return new WaitForSecondsRealtime(time);
    }
}
