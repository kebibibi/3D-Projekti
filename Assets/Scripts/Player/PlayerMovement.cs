using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public PlayerHurt hurt;

    public float playerSpeed;
    public float maxSpeed;
    public float timer;
    float horizontal;
    float vertical;

    Vector3 playerDir;

    public AudioSource audioSource;
    public Animator animator;

    public List<AudioClip> footsteps = new List<AudioClip>();
    int randomStep;
    int lastStep;

    public bool key;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        enabled = false;
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

    void AudioRandomizer()
    {
        int maxAttempts = 10;
        
        for (int i = 0; randomStep == lastStep && i < maxAttempts; i++)
        {
            randomStep = Random.Range(0, 5);
        }
        lastStep = randomStep;
    }

    private void FixedUpdate()
    {

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        playerDir = new Vector3(horizontal, 0, vertical).normalized;

        if (playerDir.x != 0 || playerDir.z != 0)
        {
            animator.SetBool("Run", true);

            playerSpeed += 0.5f;

            if (playerSpeed > maxSpeed)
                playerSpeed = maxSpeed;
        }
        else
        {
            playerSpeed = 0;
            animator.SetBool("Run", false);
        }

        if (playerSpeed > 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    AudioRandomizer();
                    audioSource.clip = footsteps[randomStep];
                    audioSource.Play();
                    timer = 0.5f;
                }
            }
        }

        if (playerDir.x == 0 && playerDir.z == 0)
        {
            hurt.health += 1 * Time.deltaTime;
        }

        rb.velocity = new Vector3(playerDir.x * playerSpeed, 0, playerDir.z * playerSpeed);
    }
}