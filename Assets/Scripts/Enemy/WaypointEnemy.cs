using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject target;
    public PlayerMovement player;
    public Arrow arrow;
    public EnemyHb enemyHB;

    public Vector3 destination;

    public float health;
    float randomSpeed;
    float randomTurn;
    float randomAcc;

    bool played;

    public bool seeking;
    public float seekDis;

    public AudioSource seek;
    public AudioClip ghostaudio;
    public AudioClip ghostdie;

    public GameObject[] waypoints;

    public int currentWP;

    public void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();

        randomSpeed = Random.Range(3.2f, 5.2f);
        randomTurn = Random.Range(80.1f, 119.1f);
        randomAcc = Random.Range(7, 15);

        agent.speed = randomSpeed;
        agent.angularSpeed = randomTurn;
        agent.acceleration = randomAcc;

        seeking = false;
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Update()
    {
        if (health <= 0)
        {
            seek.PlayOneShot(ghostdie);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        Vector3 playerDis = player.transform.position - transform.position;

        if (playerDis.magnitude <= seekDis)
        {
            seeking = true;
        }

        if (seeking == true)
        {
            if (!played)
            {
                seek.PlayOneShot(ghostaudio);
                played = true;
            }
            Seek(player.transform.position);
        }
        else
        {
            Seek(waypoints[currentWP].transform.position);
        }
    }
}
