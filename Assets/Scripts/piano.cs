using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piano : MonoBehaviour
{
    AudioSource pianosource;
    bool played;

    private void Start()
    {
        pianosource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!played)
            {
                pianosource.Play(0);
                played = true;
            }
        }
    }
}
