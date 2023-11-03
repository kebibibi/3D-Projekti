using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public GameObject gameoverScreen;
    public WeaponController weapon;
    public GameObject player;

    public float maxHealth;
    public float health;

    public float maxInv;
    public float invTimer;

    public bool hurt;

    public AudioSource source;
    public AudioClip hurtsound;

    void Start()
    {
        gameoverScreen.SetActive(false);
        health = maxHealth;
        invTimer = maxInv;
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameoverScreen.SetActive(true);
            player.SetActive(false);
        }

        if(health >= 100)
        {
            health = 100;
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
                source.PlayOneShot(hurtsound);
            }
        }

        if (other.gameObject.CompareTag("WPEnemy"))
        {
            if (hurt)
            {
                health -= 10;
                hurt = false;
                source.PlayOneShot(hurtsound);
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
                    source.PlayOneShot(hurtsound);
                    health -= 10f;
                    invTimer = maxInv;
                }
            }
        }

        if (other.gameObject.CompareTag("WPEnemy"))
        {
            if (invTimer > 0)
            {
                invTimer -= Time.deltaTime;

                if (invTimer <= 0)
                {
                    source.PlayOneShot(hurtsound);
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

        if (other.gameObject.CompareTag("WPEnemy"))
        {
            invTimer = maxInv;
        }
    }

}
