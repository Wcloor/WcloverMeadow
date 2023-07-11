using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "StartPanel";
    public static readonly UIType uIType = new UIType(path, name);

    public StarPanel() : base(uIType)
    {
    }

    
    public override void OnStart()
    {
        base.OnStart();
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Button").onClick.AddListener(Back);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "TZ").onClick.AddListener(Load);
    }

    private void Back()
    {
        GameRoot.GetInstance().UIManager_Root.Pop(false);

    }
    private void Load()
    {
        Scene2 scene2=new Scene2();
        GameRoot.GetInstance().SceneControl_Root.LoadScene(scene2.SceneName, scene2);

    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        Debug.Log("StartPanel back");
        base.OnDisable();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
