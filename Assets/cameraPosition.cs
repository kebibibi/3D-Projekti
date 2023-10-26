using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    public CamFollow cam;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.changeZ = 0;
            cam.playerRot.x = 80;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.changeZ = 1.6f;
            cam.playerRot.x = 65;
        }
    }
}
