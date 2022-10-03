using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;




public class chest : MonoBehaviour
{
    private Animator anim;
    public bool selected;
    public bool opened = false;

    public Transform landPos;

    public WeightedRandomList<GameObject> lootTable;



    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        if (selected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!opened)
                {
                    OpenChest();
                    opened = true;
                }
                
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            selected = true;
            anim.SetTrigger("selected");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            selected = true;
            anim.SetTrigger("leaveSelected");
        }
    }

    void OpenChest()
    {
        anim.SetTrigger("open");

        Spawner();
    }

    public void Spawner()
    {
        GameObject obj = Instantiate(lootTable.GetRandom(), transform.position, transform.rotation);
        obj.transform.DOMove(landPos.position, 1f).SetEase(Ease.OutQuad);
    }

}
