using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public static class Util
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : Object
    {
        if (go == null) return null;

        if (recursive)
        {
            foreach (var item in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || item.name == name)
                {
                    return item;
                }
            }
        }
        else
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                var trans = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || trans.name == name)
                {
                    var comp = trans.GetComponent<T>();
                    if (comp != null)
                    {
                        return comp;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// 게임오브젝트
    /// </summary>
    /// <returns></returns>
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        return FindChild<Transform>(go, name, recursive).gameObject;
    }

    public static T GetorAddComponent<T>(this GameObject go) where T : Component
    {
        T com = go.GetComponent<T>();
        if (com == null)
        {
            com = go.AddComponent<T>();
        }
        return com;
    }
}

public static class Extention
{
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        Ui_Map.AddUIEvent(go, action, type);
    }

}
