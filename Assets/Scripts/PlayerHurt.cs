using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public float maxInv;
    public float invTimer;

    public bool hurt;

    void Start()
    {
        health = maxHealth;
        invTimer = maxInv;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (hurt)
            {
                health -= 10;
                hurt = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (invTimer > 0)
            {
                invTimer -= Time.deltaTime;

                if (invTimer <= 0)
                {
                    health -= 10f;
                    invTimer = maxInv;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            invTimer = maxInv;
        }
    }

}