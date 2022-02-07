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

    public Text e1text;
    public Text e2text;
    public Text draw1text;
    public Text draw2text;

    public Button confirmButton;
    private bool bet;
    public void Init(BetData betData)
    {
        bet = false;
        e1Image.sprite = betData.e1Image;
        e1text.text = betData.e1Multiplier.ToString();

        e2Image.sprite = betData.e2Image;
        e2text.text = betData.e2Multiplier.ToString();

        draw1text.text = betData.drawMultiplier.ToString();
        draw2text.text = betData.drawMultiplier.ToString();

        //configurar los equipos y multiplicadores segun numApuestas
        confirmButton.onClick.AddListener(() =>
        {
            if (ApuestaHecha())
            {
                GameManager.Instance.Apuesta();
            }
        });

        e1toggle.onValueChanged.AddListener((value) =>
        {
            if (value && !bet) 
            { 
                bet = true;
                GameManager.Instance.BajaRecurso();
            }
        });

        e2toggle.onValueChanged.AddListener((value) =>
        {
            if (value && !bet)
            {
                bet = true;
                GameManager.Instance.BajaRecurso();
            }
        });

        draw1toggle.onValueChanged.AddListener((value) =>
        {
            if (value && !bet)
            {
                bet = true;
                GameManager.Instance.BajaRecurso();
            }
        });

        draw1toggle.onValueChanged.AddListener((value) =>
        {
            if (value && !bet)
            {
                bet = true;
                GameManager.Instance.BajaRecurso();
            }
        });
    }

    private bool ApuestaHecha()
    {
        return e1toggle.isOn || e2toggle.isOn || draw1toggle.isOn || draw2toggle.isOn;
    }
}
