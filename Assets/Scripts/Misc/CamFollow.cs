using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;

    public float transitionSpeed;
    public float followSpeed;

    public float camX;
    public float camY;

    public bool coolTransition;

    public Vector3 playerRot;

    private void Start()
    {
        transitionSpeed = 0.04f;
    }

    void FixedUpdate()
    {
        if (coolTransition)
        {
            Vector3 smoothPos = Vector3.Lerp(transform.position, player.position, transitionSpeed);

            float smoothUp = Mathf.Lerp(transform.position.y, 15, transitionSpeed);
            float smoothRotX = Mathf.Lerp(transform.eulerAngles.x, 90, transitionSpeed);
            float smoothRotY = Mathf.Lerp(transform.eulerAngles.y, 0, transitionSpeed);

            transform.position = new Vector3(smoothPos.x, smoothUp, smoothPos.z);
            transform.eulerAngles = new Vector3(smoothRotX, smoothRotY, 0);
        }

        if(transform.position.y >= 13.99f)
        {
            coolTransition = false;
            Vector3 smoothPos = Vector3.Lerp(transform.position, player.position, followSpeed);

            transform.position = new Vector3(smoothPos.x, 14, smoothPos.z - 2f);
            transform.localEulerAngles = playerRot;
        }
    }
}
