using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : Ui_Map
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Init() => Manager.Instance.uiManager.SetCanvas(gameObject, true);

    public virtual void ClosePopup() => Manager.Instance.uiManager.ClosePopup();
}
