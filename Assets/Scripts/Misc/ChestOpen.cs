using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public Transform player;
    public Material chestmat;

    public float chestOpenDistance;

    public bool open;
    bool oneOpen = true;

    private void Start()
    {
        chestmat.color = new Color(255, 0, 0);
    }

    void FixedUpdate()
    {
        Vector3 playerDir = player.position - transform.position;

        if (playerDir.magnitude < chestOpenDistance)
        {
            open = true;

            if (open)
            {
                if (oneOpen)
                {
                    chestmat.color = new Color(254, 254, 254);
                    oneOpen = false;
                }
            }
        }
    }
}
