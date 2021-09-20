using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager instance;
    public static Manager Instance
    {
        get
        {
            if (instance == null) init();
            return instance;
        }
    }

    public InputManager inputManager = new InputManager();
    public ResourceManager resourceManager = new ResourceManager();
    public UIManager uiManager = new UIManager();
    public SceneMangerEx SceneManger = new SceneMangerEx();
    public SoundManager SoundManager = new SoundManager();
    public PoolManager PoolManager = new PoolManager();

    void Start()
    {
        if (instance == null) init();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.OnKetAction();
    }

    static void init()
    {
        var obj = GameObject.Find("Manager");
        if(obj == null)
        {
            obj = new GameObject("Manager");
            obj.AddComponent<Manager>();
        }
        DontDestroyOnLoad(obj);
        instance = obj.GetComponent<Manager>();
        instance.SoundManager.Init();
        instance.PoolManager.Init();
    }

    public void clear()
    {
        inputManager.clear();
        uiManager.Clear();
        SoundManager.Clear();
        SceneManger.Clear();


        PoolManager.Clear();
    }
}
