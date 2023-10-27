using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    Light lighting;
    public float lightTimer;

    private void Start()
    {
        lighting = GetComponent<Light>();
    }

    void FixedUpdate()
    {
        if (lightTimer > 0)
        {
            lightTimer -= Time.deltaTime;

            if (lightTimer <= 0)
            {
                lighting.range = Random.Range(15, 17);
                lightTimer = 0.1f;
            }
        }
        
    }
}
