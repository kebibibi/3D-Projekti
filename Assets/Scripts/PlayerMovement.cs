using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float playerSpeed;
    public float maxSpeed;

    Vector3 playerDir;

    public bool shoot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        playerDir = new Vector3(horizontal, 0, vertical).normalized;

        if (playerDir.x != 0 || playerDir.z != 0)
        {
            playerSpeed += 0.5f;

            if (playerSpeed > maxSpeed)
                playerSpeed = maxSpeed;
        }
        else
        {
            playerSpeed = 0;
        }

        rb.velocity = new Vector3(playerDir.x * playerSpeed, 0, playerDir.z * playerSpeed);
    }
}
