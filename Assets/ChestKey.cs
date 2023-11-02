using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKey : MonoBehaviour
{
    public PlayerMovement player;
    public Light shine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.key = true;
            shine.enabled = false;
        }
    }

}
