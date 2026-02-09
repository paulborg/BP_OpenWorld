using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabHolder tabHolder;

    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabHolder.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabHolder.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabHolder.OnTabExit(this);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background = GetComponent<Image>();
        tabHolder.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
