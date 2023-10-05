using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioSource audioSource;

    public void ButtonSound()
    {
        audioSource.Play(0);
    }
}
