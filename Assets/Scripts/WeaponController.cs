using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject arrow;
    public Transform parentPos;
    public bool loaded;

    void Start()
    {
    }

    void Update()
    {
        parentPos = player.transform;

        if (Input.GetKeyDown(KeyCode.R) && loaded == false)
        {
            Instantiate(arrow, parentPos);
            loaded = true;
        }
    }
}
