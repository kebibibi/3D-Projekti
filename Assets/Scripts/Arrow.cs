using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed;
    public float timer;

    public bool flying;
    public bool stopped;

    public Vector3 arrowDir;

    ParticleSystem ps;
    public WeaponController weapon;


    private void Start()
    {
        ps = GetComponent<ParticleSystem>();

        weapon = GetComponent<WeaponController>();
        weapon = FindAnyObjectByType<WeaponController>();

        arrowDir = new Vector3(0, 0, 1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && weapon.loaded == true && transform.parent != null)
        {
            transform.parent = null;
            weapon.loaded = false;
            flying = true;
        }

        if (stopped == true)
        {

        }
    }

    private void FixedUpdate()
    {
        if (flying == true)
        {
            Vector3 arrowVel = arrowDir * arrowSpeed;
            transform.Translate(arrowVel * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            flying = false;
            stopped = true;
            arrowSpeed = 0;
            ps.Play();
        }
    }
}
