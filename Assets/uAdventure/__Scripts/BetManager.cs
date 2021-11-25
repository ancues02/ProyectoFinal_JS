using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{
    
    public float value;
    public Text valueText;
    public int apuestaMinima;

    private void Start()
    {
        valueText.text = value.ToString() + " C";
    }
    public void ModifyValue(float mod)
    {
        value += (mod);
        Debug.Log(value);
        valueText.text = value.ToString() + " C";
        if (value > 0)
            valueText.color = Color.green;
        else
            valueText.color = Color.red;
    }
}
