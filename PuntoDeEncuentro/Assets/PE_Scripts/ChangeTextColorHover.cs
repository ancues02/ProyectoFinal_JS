using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextColorHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;
    public Color color;
    Color ogColor;

    private void Start()
    {
        ogColor = theText.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = color; //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = ogColor; //Or however you do your color
    }
}