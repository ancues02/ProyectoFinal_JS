using System.Collections;
using System.Collections.Generic;
using uAdventure.Core;
using uAdventure.Runner;
using UnityEngine;
using UnityEngine.UI;

public class FilaQuiniela : MonoBehaviour
{
    //public BetManager betManager;
   /* public Button[] arrayBotones;
    public Text[] teamTexts;

    void Start()
    {
        foreach(Button b in arrayBotones)
        {        
            ColorBlock aux = b.colors;
            aux.disabledColor = Color.yellow;
            b.colors = aux;
        }
    }
    public void SetBet(BetType team, string teamName, float betMul, UnityEngine.Events.UnityAction onClick)
    {
        arrayBotones[(int)team].onClick.AddListener(onClick);
        teamTexts[(int)team].text = teamName + "\t" + betMul.ToString();
    }
    public void OnClick(int indx)
    {
        ColorBlock aux = arrayBotones[indx].colors;
        aux.disabledColor = Color.yellow;
        arrayBotones[indx].colors = aux;
        //betManager.ModifyBetMenu(true);
        //BetManager.instance.setQuinielaActual(this);
    }

    public void ConfirmaApuesta()
    {
        foreach(Button b in arrayBotones){
            b.interactable = false;
        }
        
    }*/
}
