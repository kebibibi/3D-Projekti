using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class VolumeText : MonoBehaviour
{

    public Slider slider;
    public TMP_Text text;
    

    void Update()
    {
        float sliderText = slider.value * 100;

        text.text = "Volume: " + ((int)sliderText).ToString();
    }
}
