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

    public Phone phone;
    public Sprite[] phoneConversations;
    public Sprite[] appSprites;
    Dictionary<string, Sprite> sprites;
    /// <summary>
    /// El indice del array el numero de apuestas
    /// </summary>
    public BetData[] betDatas;

    bool showApp = false;

    void Awake()
    {
        Debug.Log("AWAKE DEL GAMEMANAGER");
        if (!Instance) {
            if (!resourceBar)
                Debug.LogError("Falta la barra de recurso");
            else
                resourceBar.Init(MaxRecurso, MinRecurso);
            Recurso = MaxRecurso;
            InitializeSpritesDict();
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else {
            //Instance.showApp = showApp;
            Instance.betManager = betManager;
            Instance.resourceBar = resourceBar;
            Instance.phone = phone;
            //Instance.NumApuestas = NumApuestas;
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
                Instance.betManager.Init(betDatas[2]);    
            else //if (UAdvCheckFlag("Apostar_3", FlagCondition.FLAG_ACTIVE))
                Instance.betManager.Init(betDatas[1]);    
        }
        if (Instance.phone)
        {
            if (UAdvCheckFlag("LastText", FlagCondition.FLAG_ACTIVE))
            {//
                if(Instance.NumApuestas == 0)
                    Instance.phone.Init(Instance.sprites["Antia4"], Instance.sprites["app1"], true);
                else
                    Instance.phone.Init(Instance.sprites["Antia2"], Instance.sprites["app1"], true);//Aqui deberiamos bloquear el movil
            }
            else if (UAdvCheckFlag("Intro3Hecha", FlagCondition.FLAG_ACTIVE))//
                Instance.phone.Init(Instance.sprites["Grupo"], Instance.sprites["app2"], true);
            else if (UAdvCheckFlag("Despertar_3", FlagCondition.FLAG_ACTIVE))//en casa, escena 3 al despertar.
                Instance.phone.Init(Instance.sprites["Grupo"], Instance.sprites["app2"], true);

            else if (UAdvCheckFlag("MirarMovilIntro_2", FlagCondition.FLAG_ACTIVE))//tercera vez que lo usas, en la plaza, escena 2
            {
                if (Instance.NumApuestas == 0)
                    Instance.phone.Init(Instance.sprites["Antia3"], Instance.sprites["app3"], true);
                else
                {
                    Instance.phone.Init(Instance.sprites["Javi"], Instance.sprites["app3"], true);
                }
            }

            else if (UAdvCheckFlag("MirarMovilDespertar_2", FlagCondition.FLAG_ACTIVE) || UAdvCheckFlag("Despertar_2", FlagCondition.FLAG_ACTIVE))//segunda vez que lo usas, intro de la escena 2
                Instance.phone.Init(Instance.sprites["Javi"], Instance.sprites["app3"], true);

            else if (!UAdvCheckFlag("Intro1_2Hecha", FlagCondition.FLAG_ACTIVE))//primera vez que usas el movil
            {
                if (Instance.NumApuestas == 0)
                    Instance.phone.Init(Instance.sprites["Jorge2"], Instance.sprites["app"], true);
                else
                    Instance.phone.Init(Instance.sprites["Jorge1"], Instance.sprites["app"], true);
            }
            if(Instance.NumApuestas > 0)
                Instance.showApp = true;

            phone.SetAppActive(Instance.showApp);
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

    public void BajaRecurso()
    {
        Recurso = Mathf.Clamp(Recurso - RecursoApostado, MinRecurso, MaxRecurso);
        resourceBar.SetValue(Recurso);
    }

    public void Apuesta()
    {
     
        NumApuestas++;
        UAdvSetFlag("Apostar_2", FlagCondition.FLAG_INACTIVE);
        UAdvSetFlag("Apostar", FlagCondition.FLAG_INACTIVE);
        UAdvSetVariable("numApuestas", NumApuestas);
        
        Debug.Log("Apuestas: " + NumApuestas);
        UAdvPreviousScene();
    }

    void InitializeSpritesDict()
    {
        sprites = new Dictionary<string, Sprite>();
        foreach(Sprite s in appSprites)
            sprites.Add(s.name, s);
        foreach (Sprite s in phoneConversations)
            sprites.Add(s.name, s);
    }
}
