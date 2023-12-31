using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject arrow;
    public Arrow arrow1;

    public Transform parentPos;

    public bool loaded;
    public bool loading;
    public bool wallFront;

    public float timer;
    public float maxTimer;

    public AudioSource audioSource;

    public List<AudioClip> reload = new List<AudioClip>();

    void Start()
    {
        enabled = false;
    }

    public void FirstArrow()
    {
        Instantiate(arrow, parentPos);
        loaded = true;
        timer = maxTimer;
    }

    void Update()
    {
        parentPos = transform;

        if (Input.GetKeyDown(KeyCode.R) && loaded == false && loading == false)
        {
            loading = true;

            int random = Random.Range(0, 2);
            audioSource.clip = reload[random];
            audioSource.Play();
        }
        if (loading == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    Instantiate(arrow, parentPos);
                    loaded = true;
                    timer = maxTimer;
                    loading = false;
                }
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Brown"))
        {
            wallFront = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Brown"))
        {
            wallFront = false;
        }
    }
}