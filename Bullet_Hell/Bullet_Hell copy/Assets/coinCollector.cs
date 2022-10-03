using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollector : MonoBehaviour
{
    public static coinCollector instance;

    public int coins;

    void Start()
    {
        instance = this;
    }


    void Update()
    {
        
    }
    

    public void collectCoin(int value)
    {
        coins += value;
    }
}
