using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHb : MonoBehaviour
{
    public Vector3 hbScale;
    public EnemyAI enemy;

    public float damageGiven;

    void Start()
    {
        enemy = FindFirstObjectByType<EnemyAI>();
    }

    private void Update()
    {
        hbScale.x = enemy.health / 100;

        if(hbScale.x <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.localScale = new Vector3(hbScale.x, 1f, 1f);
        transform.localPosition = new Vector3(enemy.transform.localPosition.x - 0.5f, 1.5f, enemy.transform.localPosition.z + 0.65f);
    }
}
