using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBreak : MonoBehaviour
{
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    public BoxCollider collider;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rigidbodies[0].isKinematic = false;
            rigidbodies[1].isKinematic = false;
            rigidbodies[2].isKinematic = false;
            rigidbodies[3].isKinematic = false;
            rigidbodies[4].isKinematic = false;
            rigidbodies[5].isKinematic = false;

            collider.isTrigger = true;
            collider.enabled = false;
        }
    }
}
