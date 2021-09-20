using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    protected enum Buttons
    {
        ScoreButton,
    }
    protected enum Texts
    {
        ScoreText,
        ButtonText,
    }
    protected enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init(); 
        doBind();
        var bt = GetButton((int)Buttons.ScoreButton).gameObject;
        AddUIEvent(bt, (data) => OnButtonClicked(data));
        var go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (data) => onDrag(data, go), Define.UIEvent.Drag);
    }
    protected void doBind()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
    }

    private void OnButtonClicked(PointerEventData data)
    {
        num++;
        GetText((int)Texts.ScoreText).text = num.ToString();
    }

    private int num = 0;

    private void onDrag(PointerEventData data, GameObject go)
    {
        go.transform.position = data.position;
    }

}
