using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyHB;

    float randomNumber;

    private void Start()
    {
        randomNumber = Random.Range(1.1f, 4.1f);
    }

    void Update()
    {
        if(randomNumber > 0)
        {
            randomNumber -= Time.deltaTime;
            if(randomNumber <= 0)
            {
                Instantiate(enemy, transform);
                Instantiate(enemyHB, transform);
            }
        }
    }
}
