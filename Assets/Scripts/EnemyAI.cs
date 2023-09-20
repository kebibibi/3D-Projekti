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
    float randomNumber;

    public NavMeshAgent agent;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();

        enemyHB = FindAnyObjectByType<EnemyHb>();

        randomNumber = Random.Range(3.2f, 5.2f);

        agent.speed = randomNumber;
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
