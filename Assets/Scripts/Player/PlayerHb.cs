using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHb : MonoBehaviour
{
    Vector3 hbScale;
    public Transform player;
    public PlayerHurt playerH;

    void Update()
    {
        hbScale.x = playerH.health / 100;

        if (hbScale.x <= 0)
        {
            this.gameObject.SetActive(false);
        }

        transform.localScale = new Vector3(hbScale.x, 1, 1);
        transform.localPosition = new Vector3(player.localPosition.x - 0.5f, 3.5f, player.localPosition.z + 2f);
    }
}
