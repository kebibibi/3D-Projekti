using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointHb : MonoBehaviour
{
    public Vector3 hbScale;
    public WaypointEnemy enemy;
    public GameObject target;

    public float damageGiven;

    private void Update()
    {
        hbScale.x = enemy.health / 100;

        if (hbScale.x <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.localScale = new Vector3(hbScale.x, 1f, 1f);
        transform.localPosition = new Vector3(target.transform.localPosition.x - 0.5f, 3.6f, target.transform.localPosition.z + 1f);

    }
}
