using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[System.Serializable]

public class itemToSpawn
{
    public GameObject item;
    public float spawnRate;
    [HideInInspector] public float minSpawnProb, maxSpawnProb;
}

public class chest : MonoBehaviour
{
    private Animator anim;
    public bool selected;
    public bool opened = false;

    public Transform landPos;

    public itemToSpawn[] itemToSpawn;

 

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

        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if(i == 0)
            {
                itemToSpawn[i].minSpawnProb = 0;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawnRate - 1;
            }
            else
            {
                itemToSpawn[i].minSpawnProb = itemToSpawn[i -1].maxSpawnProb + 1;
                itemToSpawn[i].minSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawnRate;


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
        float randomNum = Random.Range(0, 100);

        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if (randomNum >= itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
            {
                GameObject item = Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                item.transform.DOMove(landPos.position, 1).SetEase(Ease.OutBounce);
                break;
            }


        }

        /*GameObject item = Instantiate(itemToSpawn[0].item, transform.position, Quaternion.identity);
        item.transform.DOMove(landPos.position, 1).SetEase(Ease.OutBounce);*/
    }

}
