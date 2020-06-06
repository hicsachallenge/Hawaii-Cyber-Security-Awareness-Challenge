using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress_Bar_Controller : MonoBehaviour
{
    public Slider slider;
    private float minVal;
    private float maxVal;

    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
    }

    void Update()
    {
        slider.value = Set_Player_Progress.getPlayerProgress();
    }
}
