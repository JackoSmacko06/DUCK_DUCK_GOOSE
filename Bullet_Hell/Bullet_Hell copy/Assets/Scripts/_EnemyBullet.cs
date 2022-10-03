using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed;

    public float lifetime;

    public int damage;

    private void OnEnable()
    {
        Invoke("Destroy", lifetime);
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);

    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy();
        }
        else if (collision.gameObject.tag == ("obstacle"))
        {
            Destroy();
        }

    }
}
