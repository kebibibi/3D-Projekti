using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salaovi : MonoBehaviour
{
    public float ghostCount;



    void Update()
    {
        if (ghostCount == 4)
        {
            Vector3 open = new Vector3(-14.5f, 3.75f, 54.55f);
            transform.position = Vector3.Lerp(transform.localPosition, open, 0.1f);
        }
    }
}
