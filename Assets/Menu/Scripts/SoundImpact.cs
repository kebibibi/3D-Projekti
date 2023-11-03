using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundImpact : MonoBehaviour
{
    AudioSource impactSource;

    private void Start()
    {
        impactSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 2.5f)
        {
            impactSource.volume = 0.375f;
            impactSource.Play();
        }
        if (collision.relativeVelocity.magnitude > 4)
        {
            impactSource.volume = 1f;
            impactSource.Play();
        }
    }
}
