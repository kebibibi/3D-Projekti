using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCam : MonoBehaviour
{
    public CamFollow camFollow;

    public Vector3 menuPos;

    void Start()
    {
        camFollow.enabled = false;
        menuPos = new Vector3(6, 1.6f, 7);
        transform.eulerAngles = new Vector3(0, 215, 0);
    }

    public void CameraFollow()
    {
        camFollow.enabled = true;
    }
}
