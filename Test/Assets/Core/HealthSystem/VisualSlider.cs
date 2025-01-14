using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class VisualSlider
{
    [SerializeField]
    private Image slider;

    public void Update(float precent)
    {
        slider.fillAmount = precent;
    }
}