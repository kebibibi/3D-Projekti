using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHb : MonoBehaviour
{
    public Vector3 hbScale;
    public Transform target;
    public EnemyAI enemy;

    public float damageGiven;

    private void Start()
    {
    }

    private void Update()
    {
        hbScale.x = enemy.health / 100;

        transform.localScale = new Vector3(hbScale.x, 1f, 1f);
        transform.localPosition = new Vector3(target.localPosition.x - 0.5f, 1.5f, target.localPosition.z + 0.65f);
    }
}
