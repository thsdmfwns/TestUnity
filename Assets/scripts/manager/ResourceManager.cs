using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        string name =string.Empty;
        if (typeof(T) == typeof(GameObject))
        {
            var index = path.LastIndexOf('/');
            if (index >=0)
            {
                name = path.Substring(++index);
            }
            var go = Manager.Instance.PoolManager.GetOriginal(name);
            if (go != null)
            {
                return go as T;
            }
        }

        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path, Transform parent = null)
    {
        var original = Load<GameObject>(path);
        if (original == null)
        {
            Debug.LogError($"오브젝트 갖고오기 실패 : {path}");
            return null;
        }
        if (original.GetComponent<PoolAble>() != null)
        {
            return Manager.Instance.PoolManager.pop(original, parent).gameObject;
        }
        var go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }

    public void Delete(GameObject gameObject)
    {
        if (gameObject == null) return;
        var poolAble = gameObject.GetComponent<PoolAble>();
        if (poolAble != null)
        {
            Manager.Instance.PoolManager.Push(poolAble);
            return;
        }
        Object.Destroy(gameObject);
    }
}
