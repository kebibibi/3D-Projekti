using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public PlayerMovement player;
    public Arrow arrow;
    public EnemyHb enemyHB;

    public Vector3 destination;

    public float health;
    float randomSpeed;
    float randomTurn;

    public NavMeshAgent agent;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();

        enemyHB = FindAnyObjectByType<EnemyHb>();

        randomSpeed = Random.Range(3.2f, 5.2f);
        randomTurn = Random.Range(80.1f, 119.1f);

        agent.speed = randomSpeed;
        agent.angularSpeed = randomTurn;
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
        }
    }

    private void FixedUpdate()
    {
        Seek();
    }
}
