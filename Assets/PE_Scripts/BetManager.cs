using System.Collections;
using System.Collections.Generic;
using uAdventure.Core;
using uAdventure.Runner;
using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{    
    public Toggle e1toggle;
    public Toggle e2toggle;
    public Toggle draw1toggle;
    public Toggle draw2toggle;

    public Button confirmButton;
    private void Start()
    {
        Init(GameManager.Instance.NumApuestas);
        confirmButton.onClick.AddListener(() =>
        {
            if (ApuestaHecha())
            {
                GameManager.Instance.Apuesta();
                // GameManager.VeALaEscenaDeUadvEnLaQueEstabas();
                //              o a ala que toque podemos hacer varias segun los dialogos supongo();
            }
        });
    }
    private void Init(int NumApuestas)
    {
        //configurar los equipos y multiplicadores segun el nº de apuestas o la escena no se
    }

    private bool ApuestaHecha()
    {
        return e1toggle.isOn || e2toggle.isOn || draw1toggle.isOn || draw2toggle.isOn;
    }
}
