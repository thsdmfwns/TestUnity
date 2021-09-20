using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    public override void Clear()
    {
       
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;

        for (int i = 0; i < 2; i++)
        {
            Manager.Instance.resourceManager.Instantiate("prefabs/unitychan");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Manager.Instance.SceneManger.LoadSene(Define.Scene.Game);
        }
    }

}
