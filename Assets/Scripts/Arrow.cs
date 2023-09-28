using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed;
    public float timer;
    public float damage;

    public int randomNum;

    public bool flying;
    public bool stopped;

    public Vector3 arrowDir;
    public Vector3 hbScale;

    ParticleSystem.MainModule main;
    public ParticleSystem ps;
    public WeaponController weapon;
    public EnemyAI enemy;
    public EnemyHb enemyHB;

    public AudioSource AudioSource;
    public AudioSource audioSource1;

    public List<AudioClip> Audio = new List<AudioClip>();

    private void Start()
    {
        main = ps.main;
        ps = GetComponent<ParticleSystem>();

        AudioSource = GetComponent<AudioSource>();

        weapon = GetComponent<WeaponController>();
        weapon = FindAnyObjectByType<WeaponController>();

        enemyHB = FindAnyObjectByType<EnemyHb>();

        arrowDir = new Vector3(0, 0, 1);
    }

    void Randomizer()
    {
        randomNum = Random.Range(0, 4);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && weapon.loaded == true && transform.parent != null)
        {
            AudioSource.Play();

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

        /*if (Physics.Raycast(transform.position, arrowDir, out RaycastHit hitInfo, 4f))
        {
            if (hitInfo.collider.gameObject.CompareTag("Brown"))
            {
                arrowSpeed = 0;
            }
        }*/

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

            Randomizer();
            audioSource1.clip = Audio[randomNum];
            audioSource1.Play();
        }

        if (other.gameObject.CompareTag("White") && flying == true)
        {
            flying = false;
            stopped = true;
            arrowSpeed = 0;
            main.startColor = new Color(255, 255, 255, 100);
            ps.Play();

            Randomizer();
            audioSource1.clip = Audio[randomNum];
            audioSource1.Play();
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
