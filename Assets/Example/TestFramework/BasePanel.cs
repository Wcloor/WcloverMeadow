using UnityEngine;

public class BasePanel 
{
    public UIType uiType;
  
    public GameObject ActiveObj;
    public BasePanel(UIType uitype) { 
        uiType = uitype;
    }
    public virtual void OnStart()
    {
        Debug.Log($"{uiType}开始使用");
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;

    }
    public virtual void OnEnable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
    public virtual void OnDisable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }
    public virtual void OnDestroy()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }
}
