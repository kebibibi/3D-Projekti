using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public PlayerMovement player;
    public Arrow arrow;
    public EnemyHb enemyHB;
    public salaovi salainen;

    public Vector3 destination;

    public float health;
    float randomSpeed;
    float randomTurn;
    float randomAcc;

    public bool seeking;
    public float seekDis;

    public NavMeshAgent agent;

    void Start()
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

    void Seek()
    {
        agent.SetDestination(destination);
    }

    void Update()
    {
        destination = player.transform.position;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            salainen.ghostCount++;
        }
    }

    private void FixedUpdate()
    {
        Vector3 playerDis = player.transform.position - transform.position;

        if(playerDis.magnitude <= seekDis)
        {
            seeking = true;
        }

        if (seeking == true)
        {
            Seek();
        }
    }
}
