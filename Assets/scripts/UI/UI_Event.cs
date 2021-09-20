using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Event : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> onDragHandler = null;
    public Action<PointerEventData> onClickHandler = null;

    public void OnDrag(PointerEventData eventData)
    {
        if (onDragHandler != null)
        {
            onDragHandler.Invoke(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onClickHandler != null)
        {
            onClickHandler.Invoke(eventData);
        }
    }
}
