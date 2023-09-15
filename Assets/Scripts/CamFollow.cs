using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;

    public float speed;

    void FixedUpdate()
    {
        Vector3 smoothPos = Vector3.Lerp(transform.position, player.position, speed);

        transform.position = new Vector3(smoothPos.x, 20, smoothPos.z);
    }
}
