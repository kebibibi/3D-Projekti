using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenu : MonoBehaviour
{
    public GameObject menu;

    public MenuCam camMenu;
    public CamFollow followCam;

    public PlayerTurn turn;
    public PlayerMovement playerMove;
    public WeaponController weapon;
    public Arrow arrow;

    public void DisableMenuFunc()
    {
        arrow = FindAnyObjectByType<Arrow>();

        menu.SetActive(false);
        camMenu.CameraFollow();
        followCam.coolTransition = true;

        turn.enabled = true;
        playerMove.enabled = true;
        weapon.enabled = true;
        weapon.FirstArrow();
    }
}
