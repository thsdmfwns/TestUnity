using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public static Singleton Instance 
    {
        get
        {
            if (instance == null)
                init();
            return instance;
        }
    }

    private static void init()
    {
        //싱글톤 컴포넌트를 갖고있는 게임오브젝트를 찾는다.
        GameObject singleton = GameObject.Find("Singleton");
        if (singleton == null) 
        {
            //싱글톤을 갖고있는 게임오브젝트가 없을시 
            //싱글톤 컴포넌트를 갖고있는 게임프로젝트를 생성해준다.
            singleton = new GameObject("Singleton");
            singleton.AddComponent<Singleton>();
            //싱글톤을 갖고있는 오브젝트가 파괴되지 않도록 만든다.
            DontDestroyOnLoad(singleton);
        }
        //클래스의 인스턴스에 컴포넌트를 등록시켜준다.
        instance = singleton.GetComponent<Singleton>();
    }
}
