using System.Collections;
using System.Collections.Generic;
using uAdventure.Core;
using uAdventure.Runner;
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

    /// <summary>
    /// Las veces que has apostado
    /// </summary>
    int numApuestas = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            instance.betPannel = betPannel;
            instance.dineroActualText = dineroActualText;
            instance.quinielaActual = quinielaActual;
            dineroActualText.text = instance.dineroActual.ToString() + " C";
            Destroy(this.gameObject);
        }
    }


    public void setQuinielaActual(FilaQuiniela fq)
    {
        quinielaActual = fq;
    }

    public FilaQuiniela getQuinielaActual( )
    {
        return quinielaActual;
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


    /**
     * cosas para cambiar variables dentro de uadventure desde una escena nuestra
     * // Setting the flag to Active
        Game.Instance.GameState.SetFlag("Foo", FlagCondition.FLAG_ACTIVE);
        // Checking the flag value
        if(Game.Instance.GameState.CheckFlag("Foo") == FlagCondition.FLAG_ACTIVE){
          Debug.Log("The flag is active!");
        }
     */
    public void changeScene(string name)
    {
        numApuestas++;
        // Setting the flag to Active
        Game.Instance.GameState.SetFlag("Apostar", FlagCondition.FLAG_INACTIVE);
        Game.Instance.GameState.SetVariable("numApuestas", numApuestas);

        //Esto es para cambiar de escenas dentro de uadventure
        Game.Instance.Execute(new EffectHolder(new Effects{
        new TriggerSceneEffect(name, 0, 0)//el nombre de la escena es la que hemos puesto en uadventure
        }));

    }

}
