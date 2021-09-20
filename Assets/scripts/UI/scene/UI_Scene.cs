using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : Ui_Map
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void init()
    {
        Manager.Instance.uiManager.SetCanvas(gameObject, false);
    }
}
