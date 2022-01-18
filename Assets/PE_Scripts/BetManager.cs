using System.Collections;
using System.Collections.Generic;
using uAdventure.Core;
using uAdventure.Runner;
using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{
    public Image e1Image;
    public Image e2Image;

    public Toggle e1toggle;
    public Toggle e2toggle;
    public Toggle draw1toggle;
    public Toggle draw2toggle;

    public Button confirmButton;
    public void Init(BetData betData)
    {
        e1Image.sprite = betData.e1Image;
        e2Image.sprite = betData.e2Image;
        //configurar los equipos y multiplicadores segun numApuestas
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

    private bool ApuestaHecha()
    {
        return e1toggle.isOn || e2toggle.isOn || draw1toggle.isOn || draw2toggle.isOn;
    }
}
