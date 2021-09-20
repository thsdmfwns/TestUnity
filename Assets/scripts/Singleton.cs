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
        //�̱��� ������Ʈ�� �����ִ� ���ӿ�����Ʈ�� ã�´�.
        GameObject singleton = GameObject.Find("Singleton");
        if (singleton == null) 
        {
            //�̱����� �����ִ� ���ӿ�����Ʈ�� ������ 
            //�̱��� ������Ʈ�� �����ִ� ����������Ʈ�� �������ش�.
            singleton = new GameObject("Singleton");
            singleton.AddComponent<Singleton>();
            //�̱����� �����ִ� ������Ʈ�� �ı����� �ʵ��� �����.
            DontDestroyOnLoad(singleton);
        }
        //Ŭ������ �ν��Ͻ��� ������Ʈ�� ��Ͻ����ش�.
        instance = singleton.GetComponent<Singleton>();
    }
}
