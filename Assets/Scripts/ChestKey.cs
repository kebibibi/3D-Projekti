using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKey : MonoBehaviour
{
    public PlayerMovement player;
    public Light shine;
    AudioSource collect;

    private void Start()
    {
        collect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collect.Play(0);
            player.key = true;
            shine.enabled = false;
        }
    }

}
