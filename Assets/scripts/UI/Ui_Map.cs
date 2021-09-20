using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ui_Map : MonoBehaviour
{
    Dictionary<Type, List<UnityEngine.Object>> objectMap = new Dictionary<Type, List<UnityEngine.Object>>();
    protected Text GetText(int item) => Get<Text>((int)item);
    protected Button GetButton(int item) => Get<Button>((int)item);
    protected Image GetImage(int item) => Get<Image>((int)item);

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        var names = new List<string>(Enum.GetNames(type));
        var objs = new List<UnityEngine.Object>();
        foreach (var item in names)
        {
            var child = Util.FindChild<T>(gameObject, item, true);
            if (child == null) Debug.LogError($"Fail to bind => {item}");
            objs.Add(child);
        }
        objectMap.Add(typeof(T), objs);
    }

    protected void Bind_GmaeObject(Type type)
    {
        var names = new List<string>(Enum.GetNames(type));
        var objs = new List<UnityEngine.Object>();
        foreach (var item in names)
        {
            var child = Util.FindChild(gameObject, item, true);
            if (child == null) Debug.LogError($"Fail to bind => {item}");
            objs.Add(child);
        }
        objectMap.Add(typeof(GameObject), objs);
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        List<UnityEngine.Object> list = null;
        if (objectMap.TryGetValue(typeof(T), out list)) return (T)list[index];
        return null;
    }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        var evt = Util.GetorAddComponent<UI_Event>(go);
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.onClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.onDragHandler += action;
                break;
        }
    }
}
