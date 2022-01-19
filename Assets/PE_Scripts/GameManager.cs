using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using uAdventure.Core;
using uAdventure.Runner;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Recurso { get; set; }
    public int NumApuestas { get; set; }    // == APUESTAS en el guion
    public int ApuestaMinima { get; set; }

    public ResourceBar resourceBar;
    public int MaxRecurso;
    public int MinRecurso;
    public int RecursoApostado;

    public BetManager betManager;

    /// <summary>
    /// El indice del array el numero de apuestas
    /// </summary>
    public BetData[] betDatas;
    
    void Awake()
    {
        if (!Instance) {
            if (!resourceBar)
                Debug.LogError("Falta la barra de recurso");
            else
                resourceBar.Init(MaxRecurso, MinRecurso);
            Recurso = MaxRecurso;
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else {
            Instance.betManager = betManager;
            Instance.resourceBar = resourceBar;
            Destroy(this);
        }
        if (!Instance.resourceBar)
            Debug.LogError("Falta la barra de recurso");
        else
            Instance.resourceBar.SetValue(Instance.Recurso);
        if (Instance.betManager)
        {
            if(UAdvCheckFlag("Apostar", FlagCondition.FLAG_ACTIVE))
                Instance.betManager.Init(betDatas[0]);    
            else if(UAdvCheckFlag("Apostar_2", FlagCondition.FLAG_ACTIVE))
                Instance.betManager.Init(betDatas[1]);    
            else //if (UAdvCheckFlag("Apostar_3", FlagCondition.FLAG_ACTIVE))
                Instance.betManager.Init(betDatas[2]);    
        }
        
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
        Recurso = Mathf.Clamp(Recurso - RecursoApostado, MinRecurso, MaxRecurso);
        resourceBar.SetValue(Recurso);
        NumApuestas++;
        UAdvSetVariable("Apostar_2", FlagCondition.FLAG_INACTIVE);
        UAdvSetVariable("Apostar", FlagCondition.FLAG_INACTIVE);
        UAdvSetVariable("numApuestas", NumApuestas);
        
        Debug.Log("Apuestas: " + NumApuestas);
        UAdvPreviousScene();
    }
}
