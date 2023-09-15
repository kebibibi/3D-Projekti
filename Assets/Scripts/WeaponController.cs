using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Arrow arrowClass;
    public GameObject arrow;
    public Transform parentPos;

    void Start()
    {
        Instantiate(arrow, parentPos);
    }

    void Update()
    {
        parentPos = transform;
    }
}
