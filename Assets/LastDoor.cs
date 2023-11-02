using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.key)
            {
                winScreen.SetActive(true);
            }
        }
    }

}
