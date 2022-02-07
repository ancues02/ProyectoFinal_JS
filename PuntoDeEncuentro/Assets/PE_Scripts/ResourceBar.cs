using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void Init(int maxValue, int minValue)
    {
        slider.maxValue = maxValue;
        slider.minValue = minValue;
        fill.color = gradient.Evaluate(1);
    }
    public void SetValue(int value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
