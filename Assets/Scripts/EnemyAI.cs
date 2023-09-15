using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    public Vector3 destination;

    public float health;
    public float maxHealth;

    public NavMeshAgent agent;

    void Start()
    {
        health = maxHealth;
    }

    void Seek()
    {
        agent.SetDestination(destination);
    }

    void Update()
    {
        destination = player.position;

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
