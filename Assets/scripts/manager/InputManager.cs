using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{

    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool pressed = false;
    public void OnKetAction()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (KeyAction != null && Input.anyKey)
        {
            KeyAction.Invoke();
        }
        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                pressed = true;
            }
            else
            {
                if (pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                pressed = false;
            }
        }
    }

    public void clear()
    {
        KeyAction = null;
        MouseAction = null;
        pressed = false;
    }
}
