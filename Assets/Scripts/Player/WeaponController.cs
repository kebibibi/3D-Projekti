using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public PlayerMovement player;

    public GameObject arrow;

    public Transform parentPos;

    public bool loaded;
    public bool loading;

    public float timer;
    public float maxTimer;

    public AudioSource audioSource;

    void Start()
    {
        Instantiate(arrow, parentPos);
        loaded = true;
        timer = maxTimer;
    }

    void Update()
    {
        parentPos = player.transform;

        if (Input.GetKeyDown(KeyCode.R) && loaded == false && loading == false)
        {
            loading = true;
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
}