using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class chestItem : MonoBehaviour
{
    
    void Start()
    {
        transform.DOMove(new Vector2(0, -.01f), 2).SetEase(Ease.InSine);
    }


}
