using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }
    public Define.Scene SceneType { get; protected set; } = Define.Scene.None;
    protected virtual void Init()
    {
        var obj = FindObjectOfType(typeof(EventSystem));
        if (obj == null) Manager.Instance.resourceManager.Instantiate("prefabs/EventSystem");
    }

    public abstract void Clear();
}
