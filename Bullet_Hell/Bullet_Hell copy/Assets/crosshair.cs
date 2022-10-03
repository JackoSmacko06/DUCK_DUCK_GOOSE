using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    public static crosshair instance;
    
    Vector2 targetPos;

    public Animator anim;



    void Start()
    {
        instance = this; 
        
        Cursor.visible = false;
    }


    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPos;
    }

    public void fireAnim()
    {
        anim.SetTrigger("fire");
    }
}
