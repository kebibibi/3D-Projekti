using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public Transform player;
    public Animator chestani;

    public float chestOpenDistance;

    public bool open;

    void FixedUpdate()
    {
        Vector3 playerDir = player.position - transform.position;

        if (playerDir.magnitude < chestOpenDistance)
        {
            open = true;

            if (open)
            {
                chestani.SetBool("Open", true);
            }
        }
    }
}
