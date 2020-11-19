using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckHold : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool pressed;
    void Start()
    {
        pressed = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pressed = true;
    }

    


    public void OnPointerExit(PointerEventData eventData)
    {
        pressed = false;
    }
}
