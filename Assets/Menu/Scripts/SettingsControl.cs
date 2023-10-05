using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{

    public GameObject settings;
    public GameObject menu;

    private void Start()
    {
        settings.SetActive(false);
    }

    public void SettingsFunc()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void BackToMenu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }
}
