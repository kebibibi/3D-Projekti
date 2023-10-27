using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public Vector3 mouseDirection;
    public float mouseDistanceFromPlayer = 0.2f;
    public CamFollow cam;
    public Camera mainCam;

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.position.y;
        mousePos = mainCam.ScreenToWorldPoint(mousePos);

        mouseDirection = mousePos - transform.position;

        if (mouseDirection.magnitude > mouseDistanceFromPlayer)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, mouseDirection, 1, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        } 
    }

}
