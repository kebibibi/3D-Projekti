using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    public PlayerMovement playerMove;
    public GameObject player;
    public GameObject winScreen;

    bool playerWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerMove.key)
            {
                winScreen.SetActive(true);
                if (playerWin)
                {
                    player.SetActive(false);
                }
            }
        }
    }

}
