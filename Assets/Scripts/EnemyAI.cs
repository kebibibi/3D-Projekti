using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public PlayerMovement player;

    public Vector3 destination;

    public float health;

    public NavMeshAgent agent;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
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
