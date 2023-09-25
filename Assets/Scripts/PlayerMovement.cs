using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public PlayerHurt hurt;

    public float playerSpeed;
    public float maxSpeed;
    float horizontal;
    float vertical;

    Vector3 playerDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        /*if (Physics.Raycast(transform.position, playerDir, out RaycastHit hitInfo, 0.6f))
        {
            if (hitInfo.collider.gameObject.CompareTag("Wall"))
            {
                playerSpeed = 0;
            }
        }*/
    }

    private void FixedUpdate()
    {

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
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

        if (playerDir.x == 0 && playerDir.z == 0)
        {
            hurt.health += 1 * Time.deltaTime;
        }

        rb.velocity = new Vector3(playerDir.x * playerSpeed, 0, playerDir.z * playerSpeed);
    }
}