using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyHB;

    private void Start()
    {
        Instantiate(enemy);
        Instantiate(enemyHB);

    }

    void Update()
    {
        
    }
}
