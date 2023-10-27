using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public cameraPosition area;

    public float transitionSpeed;
    public float followSpeed;
    [Range(0, 1.6f)]
    public float changeZ;

    public bool coolTransition;

    public Vector3 playerRot;
    public Vector3 zRange;

    private void Start()
    {
        transitionSpeed = 0.04f;
    }

    void FixedUpdate()
    {
        if (coolTransition)
        {
            Vector3 smoothPos = Vector3.Lerp(transform.position, player.position, transitionSpeed);

            float smoothUp = Mathf.Lerp(transform.position.y, 17.2f, transitionSpeed);
            float smoothRotX = Mathf.Lerp(transform.eulerAngles.x, 80, transitionSpeed);
            float smoothRotY = Mathf.Lerp(transform.eulerAngles.y, 0, transitionSpeed);

            transform.position = new Vector3(smoothPos.x, smoothUp, smoothPos.z);
            transform.eulerAngles = new Vector3(smoothRotX, smoothRotY, 0);
        }

        if(transform.position.y >= 17.19f)
        {
            coolTransition = false;
            Vector3 smoothPos = Vector3.Lerp(transform.position, player.position, followSpeed);

            transform.position = new Vector3(smoothPos.x, 17.2f, smoothPos.z - changeZ);
            transform.localEulerAngles = playerRot;
        }
        /*

        zRange = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 1.7f);
        Vector3 dir = transform.position - zRange;

        Ray ray = new Ray(transform.localPosition, dir);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            changeZ = hit.transform.position.z;
        }*/
    }

}
