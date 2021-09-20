using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{
    int orderSort = 10;

    Stack<UI_Popup> PopupStack = new Stack<UI_Popup>();
    UI_Scene Scene = null;
    public GameObject Root
    {
        get
        {
            var root = GameObject.Find("@UI_Root");
            if (root == null)
            {
                root = new GameObject("@UI_Root");
            }
            return root;
        }
    }



    public void SetCanvas(GameObject go, bool sort = true)
    {
        var canvas = Util.GetorAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        if (sort)
        {
            canvas.sortingOrder = orderSort;
            orderSort++;
            return;
        }
        canvas.sortingOrder = 0;
    }

    public T ShowScene<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        var go = Manager.Instance.resourceManager.Instantiate($"prefabs/UI/popup/{name}");
        var scene = Util.GetorAddComponent<T>(go);


        go.transform.SetParent(Root.transform);

        return scene;
    }

    public T ShowPopup<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        var go = Manager.Instance.resourceManager.Instantiate($"prefabs/UI/popup/{name}");
        var popup = Util.GetorAddComponent<T>(go);
        PopupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    public void ClosePopup()
    {
        if (PopupStack.Count == 0)
        {
            return;
        }

        var popup = PopupStack.Pop();
        Manager.Instance.resourceManager.Delete(popup.gameObject);
        popup = null;
        orderSort--;
    }

    public void ClosePopup(UI_Popup item)
    {
        if (PopupStack.Count == 0)
        {
            return;
        }
        if (PopupStack.Peek() != item)
        {
            Debug.LogError("팝업 종료 오류");
            return;
        }
        ClosePopup();
    }
    public void CloseAllPopup()
    {
        while (PopupStack.Count > 0)
        {
            ClosePopup();
        }
    }

    public void Clear()
    {
        CloseAllPopup();
        Scene = null;
    }
}
