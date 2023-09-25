using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed;
    public float timer;
    public float damage;

    public bool flying;
    public bool stopped;

    public Vector3 arrowDir;
    public Vector3 hbScale;

    ParticleSystem.MainModule main;
    public ParticleSystem ps;
    public WeaponController weapon;
    public EnemyAI enemy;
    public EnemyHb enemyHB;


    private void Start()
    {
        main = ps.main;
        ps = GetComponent<ParticleSystem>();

        weapon = GetComponent<WeaponController>();
        weapon = FindAnyObjectByType<WeaponController>();

        enemyHB = FindAnyObjectByType<EnemyHb>();

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
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (flying == true)
        {
            Vector3 arrowVel = arrowDir * arrowSpeed;
            transform.Translate(arrowVel * Time.deltaTime);

            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    flying = false;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brown") && flying == true)
        {
            flying = false;
            stopped = true;
            arrowSpeed = 0;
            main.startColor = new Color(137, 74, 33, 100);
            ps.Play();
        }

        if (other.gameObject.CompareTag("White") && flying == true)
        {
            flying = false;
            stopped = true;
            arrowSpeed = 0;
            main.startColor = new Color(255, 255, 255, 100);
            ps.Play();
            Debug.Log("homo");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.gameObject.GetComponent<EnemyAI>();

            if (flying == true)
            {
                enemy.health -= damage;
            }
        }
    }
}
