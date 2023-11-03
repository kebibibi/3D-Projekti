using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject creditsScreen;
    public GameObject menu;

    private void Start()
    {
        creditsScreen.SetActive(false);
    }

    public void CreditsFunc()
    {
        creditsScreen.SetActive(true);
        menu.SetActive(false);
    }

    public void BackToMenu()
    {
        menu.SetActive(true);
        creditsScreen.SetActive(false);
    }
}
