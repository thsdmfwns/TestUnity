using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool 
{
    public GameObject Origianl { get; private set; }
    public Transform Root { get; private set; }

    Stack<PoolAble> poolStack = new Stack<PoolAble>();

    public Pool(GameObject origianl, int count = 5)
    {
        Init(origianl, count);
    }

    public void Init(GameObject original, int count)
    {
        this.Origianl = original;
        Root = new GameObject().transform;
        Root.name = $"{original.name}_Root";
        for (int i = 0; i < count; i++)
        {
            Push(create());
        }
    }

    PoolAble create()
    {
        var go = Object.Instantiate<GameObject>(Origianl);
        go.name = Origianl.name;
        return Util.GetorAddComponent<PoolAble>(go);
    }

    public void Push(PoolAble poolAble)
    {
        if (poolAble == null)
        {
            return;
        }
        poolAble.transform.parent = Root;
        poolAble.gameObject.SetActive(false);
        poolAble.IsUsing = false;
        poolStack.Push(poolAble);
    }

    public PoolAble pop(Transform parent)
    {
        PoolAble obj;
        if (poolStack.Count > 0)
            obj = poolStack.Pop();
        else
            obj = create();
        obj.gameObject.SetActive(true);
        obj.IsUsing = true;
        if (parent ==null)
        {
            obj.transform.parent = Manager.Instance.SceneManger.CurrentScene.transform;
        }
        obj.transform.parent = parent;

        return obj;

    }
}

public class PoolManager
{
    Transform root;
    Dictionary<string, Pool> poolMap = new Dictionary<string, Pool>();
    public void Init()
    {
        if (root == null)
        {
            root = new GameObject("@PoolRoot").transform;
            Object.DontDestroyOnLoad(root);
        }
    }

    public void CreatePool(GameObject original, int count = 5)
    {
        var pool = new Pool(original, count);
        pool.Root.parent = root;

        poolMap.Add(original.name, pool);
    }

    public void Push(PoolAble poolAble)
    {
        var name = poolAble.gameObject.name;
        if (!poolMap.ContainsKey(name))
        {
            Manager.Instance.resourceManager.Delete(poolAble.gameObject);
            return;
        }
        poolMap[name].Push(poolAble);
    }

    public PoolAble pop(GameObject original, Transform parent =null)
    {
        if (!poolMap.ContainsKey(original.name))
        {
            CreatePool(original);
        }
        return poolMap[original.name].pop(parent);

    }

    public GameObject GetOriginal(string name)
    {
        if (!poolMap.ContainsKey(name))
        {
            return null;
        }
        return poolMap[name].Origianl;
    }

    public void Clear()
    {
        foreach (Transform item in root)
        {
            GameObject.Destroy(item.gameObject);
        }
        poolMap.Clear();
    }
}
