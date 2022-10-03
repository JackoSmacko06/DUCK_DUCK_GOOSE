using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int value;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            coinCollector.instance.collectCoin(value);
            sfxManager.instance.coinSound();
            Destroy(gameObject);
        }

    }
}
