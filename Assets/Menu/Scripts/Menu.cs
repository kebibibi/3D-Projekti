using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    public MenuCam camMenu;
    public CamFollow followCam;

    public PlayerTurn turn;
    public PlayerMovement playerMove;
    public GameObject hb;
    public WeaponController weapon;
    public Arrow arrow;
    public Camera cam;

    private void Start()
    {
        hb.SetActive(false);
    }

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
        hb.SetActive(true);
        cam.transform.parent = null;

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
