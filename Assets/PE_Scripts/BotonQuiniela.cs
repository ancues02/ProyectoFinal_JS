using System.Collections;
using System.Collections.Generic;
using uAdventure.Core;
using uAdventure.Runner;
using UnityEngine;
using UnityEngine.UI;

public class BotonQuiniela : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    
    public void OnClick()
    {
        ColorBlock aux = button.colors;
        //rm.ModifyValue(-valueMod);
        aux.normalColor = Color.yellow;
        aux.highlightedColor = Color.yellow;
        aux.selectedColor = Color.yellow;
        aux.pressedColor = Color.yellow;
        button.colors = aux;

    }

}
