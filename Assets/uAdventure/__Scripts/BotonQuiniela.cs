using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonQuiniela : MonoBehaviour
{
    Button button;
    public float valueMod;
    public BetManager rm;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    
    public void OnClick()
    {
        ColorBlock aux = button.colors;
        rm.ModifyValue(-valueMod);
        aux.normalColor = Color.yellow;
        aux.highlightedColor = Color.yellow;
        aux.selectedColor = Color.yellow;
        aux.pressedColor = Color.yellow;
        button.colors = aux;


    }

}
