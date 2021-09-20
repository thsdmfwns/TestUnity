using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMangerEx
{
    public BaseScene CurrentScene 
    {
        get
        {
            return GameObject.FindObjectOfType<BaseScene>();
        }
    }
    public void LoadSene(Define.Scene scene)
    {
        Manager.Instance.clear();
        SceneManager.LoadScene(scene.ToString());
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
