using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameover;

    public MenuCam camMenu;
    public CamFollow followCam;

    public PlayerTurn turn;
    public PlayerMovement playerMove;
    public GameObject hb;
    public WeaponController weapon;
    public Arrow arrow;

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

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartFunc()
    {
        SceneManager.LoadScene("3D-ProjektiScene");
        gameover.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
