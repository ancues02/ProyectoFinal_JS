using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{
    // Singleton
    public static BetManager instance = null;
    
    public GameObject betPannel;

    public float dineroActual;
    public Text dineroActualText;

    public int apuestaMinima;

    float dineroApostado;
    FilaQuiniela quinielaActual;

    public void setQuinielaActual(FilaQuiniela fq)
    {
        quinielaActual = fq;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        dineroActualText.text = dineroActual.ToString() + " C";
    }

    public void Apuesta(float apuesta)
    {
        dineroApostado += apuesta;
        dineroActual -= apuesta;
        dineroActualText.text = dineroActual.ToString() + " C";
        quinielaActual.ConfirmaApuesta();
    }

    public void ModifyBetMenu(bool mod)
    {
        betPannel.SetActive(mod);
    }

}
