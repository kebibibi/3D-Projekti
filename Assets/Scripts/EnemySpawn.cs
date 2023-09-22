using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyHB;

    float randomNumber;
    public float randomBigNumber;
    float randomX;
    float randomZ;

    private void Start()
    {
        randomNumber = Random.Range(1.1f, 4.1f);
    }

    private void RandomNumber()
    {
        randomBigNumber = Random.Range(58, 69);
        randomX = Random.Range(-14.51f, 14.51f);
        randomZ = Random.Range(0, -14);
    }

    void Update()
    {
        Vector3 randomPos = new Vector3(randomX, 0.5f, randomZ);
        transform.position = randomPos;

        if(randomNumber > 0)
        {
            randomNumber -= Time.deltaTime;
            if(randomNumber <= 0)
            {
                Instantiate(enemy, transform);
                Instantiate(enemyHB, transform);
                RandomNumber();
            }
        }

        if (randomBigNumber > 0)
        {
            randomBigNumber -= Time.deltaTime;
            if (randomBigNumber <= 0)
            {
                Instantiate(enemy, transform);
                Instantiate(enemyHB, transform);
                RandomNumber();
            }
        }
    }
}
