using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bet : MonoBehaviour
{
    public float modValue;

    public float value;
    public Text apuestaText;
    public int apuestaMinima;

    private void Start()
    {
        apuestaText.text = "Tu Apuesta: " + value.ToString();
    }
    public void ModifyValue(float mod)
    {
        value += mod;
        Mathf.Clamp(value, 0f, 200f);
        Debug.Log(value);
    }
}
