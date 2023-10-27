using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salaovi : MonoBehaviour
{
    public float ghostCount;

    public Camera cutsceneCam;
    public Camera mainCam;

    public float camTimer;

    private void Start()
    {
        cutsceneCam.enabled = false;
    }

    void FixedUpdate()
    {
        if (ghostCount == 4)
        {
            mainCam.enabled = false;
            cutsceneCam.enabled = true;

            Vector3 open = new Vector3(-14.5f, 3.75f, 54.55f);
            transform.position = Vector3.Lerp(transform.localPosition, open, 0.01f);

            if (transform.position.z <= 55f)
            {
                mainCam.enabled = true;
                cutsceneCam.enabled = false;
            }

        }
    }
}
