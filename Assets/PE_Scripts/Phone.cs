using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public Image phoneInside;
    public Button converButton;
    public Button appButton;
    public Button leaveButton;

    Sprite appSprite;
    Sprite converSprite;

    // Bool para mostrar la conversacion al cargar, si es false se muestra el app
    public void Init(Sprite converSprite, Sprite appSprite, bool showConver)
    {
        SetConverSprite(converSprite);
        SetAppSprite(appSprite);
        if (showConver) ShowConver();
        else if(appButton.gameObject.activeSelf) ShowApp();

        converButton.onClick.AddListener(()=>
        {
            ShowConver();
        });
        appButton.onClick.AddListener(() =>
        {
            ShowApp();
        });
        leaveButton.onClick.AddListener(() =>
        {
            if (GameManager.Instance.UAdvCheckFlag("MirarMovilDespertar_2", 0))
            {
                GameManager.Instance.UAdvSetFlag("MirarMovilDespertar_2", 1);
                GameManager.Instance.UAdvSetFlag("Despertar_2", 0);
            }
            else if(GameManager.Instance.UAdvCheckFlag("Despertar_3", 0))//si está activado
            {
                GameManager.Instance.UAdvSetFlag("MovilMirado_3", 0);//activar
            }
            GameManager.Instance.UAdvSetFlag("MirarMovil", 1);//desactivar
            GameManager.Instance.UAdvPreviousScene();
        });
    }

    public void SetAppActive(bool active)
    {
        appButton.gameObject.SetActive(active);
    }
    void SetConverSprite(Sprite im)
    {
        converSprite = im;
    }
    void SetAppSprite(Sprite im)
    {
        appSprite = im;
    }
    void ShowApp()
    {
        phoneInside.sprite = appSprite;
    }
    void ShowConver()
    {
        phoneInside.sprite = converSprite;
    }
}
