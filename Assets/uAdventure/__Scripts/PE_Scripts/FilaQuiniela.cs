using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FilaQuiniela : MonoBehaviour
{
    public Button[] arrayBotones;

    public void OnClick(int indx)
    {
        ColorBlock aux = arrayBotones[indx].colors;
        aux.disabledColor = Color.yellow;
        arrayBotones[indx].colors = aux;
        BetManager.instance.ModifyBetMenu(true);
        BetManager.instance.setQuinielaActual(this);
    }

    public void ConfirmaApuesta()
    {
        foreach(Button b in arrayBotones){
            b.interactable = false;
        }
    }
}
