using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using uAdventure.Core;
using uAdventure.Runner;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public float DineroActual { get; set; }
    public float DineroApostado { get; set; }

    public int NumApuestas { get; set; }    // == APUESTAS en el guion
    public int ApuestaMinima { get; set; }


    BetManager betManager;

    void Awake()
    {
        if (!Instance) {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else {
            Instance.betManager = betManager;
            Destroy(this);
        }
        /*if (Instance.betManager)
        {
            Instance.betManager.Init(NumApuestas);
        }*/
    }


    public void ChangeUnityScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Metodos de uAdventure
    /**
     * cosas para cambiar variables dentro de uadventure desde una escena nuestra
     * // Setting the flag to Active
        Game.Instance.GameState.SetFlag("Foo", FlagCondition.FLAG_ACTIVE);
        // Checking the flag value
        if(Game.Instance.GameState.CheckFlag("Foo") == FlagCondition.FLAG_ACTIVE){
          Debug.Log("The flag is active!");
        }
     */
    public void UAdvChangeScene(string sceneName)
    {
        //Esto es para cambiar de escenas dentro de uadventure
        Game.Instance.Execute(new EffectHolder(new Effects{
        new TriggerSceneEffect(sceneName, 0, 0)//el nombre de la escena es la que hemos puesto en uadventure
        }));
    }

    public void UAdvPreviousScene()
    {
        //Esto es para cambiar de escenas dentro de uadventure
        Game.Instance.Execute(new EffectHolder(new Effects{
        new TriggerLastSceneEffect()//el nombre de la escena es la que hemos puesto en uadventure
        }));
    }

    public void UAdvSetFlag(string name, int state)
    {
        Game.Instance.GameState.SetFlag(name, state);
    }

    public bool UAdvCheckFlag(string name, int state)
    {
        return Game.Instance.GameState.CheckFlag(name) == state;
    }

    public void UAdvSetVariable(string name, int state)
    {
        Game.Instance.GameState.SetVariable(name, state);
    }

    public int UAdvGetVariable(string name)
    {
        return Game.Instance.GameState.GetVariable(name);
    }

    public void UAdvAddInventoryItem(string elementID)
    {
        Game.Instance.GameState.AddInventoryItem(elementID);
    }
    public List<string> UAdvGetInventoryItems()
    {
        return Game.Instance.GameState.GetInventoryItems();
    }

    public void UAdvRemoveInventoryItem(string elementID)
    {
        Game.Instance.GameState.RemoveInventoryItem(elementID);
    }

    // Funciones del juego

    public void Apuesta()
    {
        Debug.Log("Apostado");
       //DineroActual -= apuesta;
       //DineroApostado += apuesta;
    }

    /*
        Tener aqui todos los equipos (diccionario con nombre, 3 ints [e1, x , e2]), 
        la barra de recurso (el dinero de ahora)
        lo que se ha apostado, el multiplicador y ya.

        Como apostar o hacer una barra que cambie con slider o algo asi para la barra de 
        recurso
     */
}
