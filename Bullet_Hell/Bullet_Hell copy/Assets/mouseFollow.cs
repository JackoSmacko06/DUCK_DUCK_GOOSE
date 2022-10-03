using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFollow : MonoBehaviour
{

    Vector2 mousePos;
    public float radius;

    public Transform player;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = player.transform.position;
        Vector3 playerToCursor = mousePos - playerPos;
        Vector3 dir = playerToCursor.normalized;
        Vector3 cursorVector = dir * radius;
        Vector3 finalPos = playerPos + cursorVector;


        Vector2 followPos = new Vector2((finalPos.x + player.position.x) / 2, (finalPos.y + player.position.y) / 2);

        transform.position = followPos;
        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player.transform.position, radius);

    }


}
