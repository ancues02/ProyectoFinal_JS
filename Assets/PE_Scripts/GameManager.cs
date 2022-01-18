using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using uAdventure.Core;
using uAdventure.Runner;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
        if (Instance.betManager)
        {
            // iniciar betManager
        }
    }


    public void ChangeUnityScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
    public void ChangeUadventureScene(string sceneName)
    {
        //Esto es para cambiar de escenas dentro de uadventure
        Game.Instance.Execute(new EffectHolder(new Effects{
        new TriggerSceneEffect(sceneName, 0, 0)//el nombre de la escena es la que hemos puesto en uadventure
        }));
    }

    public void SetUadventurFlag(string name, int state)
    {
        Game.Instance.GameState.SetFlag(name, state);
    }

    public bool CheckUadventureFlag(string name, int state)
    {
        return Game.Instance.GameState.CheckFlag(name) == state;
    }

    public void SetUadventureVariable(string name, int state)
    {
        Game.Instance.GameState.SetVariable(name, state);
    }

    public int GetUadventureVariable(string name)
    {
        return Game.Instance.GameState.GetVariable(name);
    }
}
