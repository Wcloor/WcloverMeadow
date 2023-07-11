using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;

public class UIManager
{
    public Stack<BasePanel> stack_ui;
    public Dictionary<string, GameObject> dict_uiobject;
    public GameObject CanvasObj;

    public static UIManager instance;
    public static UIManager GetInstance() {
        if(instance == null)
        { Debug.Log("UIManager实例不存在");
        return instance;

        }
        else
        {

            return instance;
        }
       

    }
    public UIManager() { 
        instance = this;
        stack_ui = new Stack<BasePanel>();
        dict_uiobject = new Dictionary<string, GameObject>();
    }

    public GameObject GetSingleObject(UIType uiType)
    {
        if(dict_uiobject.ContainsKey(uiType.name))
        {   
            return dict_uiobject[uiType.name];
        }
        if(CanvasObj == null)
        {
            CanvasObj = UIMehod.GetInstance().FindCanvas();
            //Debug.Log("UIManager未能成功获得");
            //return null;
        }
        GameObject obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uiType.path),CanvasObj.transform);
        return obj;

    }



    public void Push(BasePanel basePanel)
    {
        Debug.Log($"{basePanel.uiType.name}被Push进stack");
        if(stack_ui.Count > 0 )
        {
            stack_ui.Peek().OnDisable();
        }
        GameObject ui_object = GetSingleObject(basePanel.uiType);
        dict_uiobject.Add(basePanel.uiType.name, ui_object);
        basePanel.ActiveObj = ui_object;
        if(stack_ui.Count ==0)
        {
            stack_ui.Push(basePanel);
        }
        else
        {
            if (stack_ui.Peek().uiType.name != basePanel.uiType.name)
            {
                stack_ui.Push(basePanel);
            }
        }
        basePanel.OnStart();
    }


    public void Pop(bool isload)
    {
        if(isload)
        {
            if(stack_ui.Count > 0 )
            {
                stack_ui.Peek().OnDisable(); 
                stack_ui.Peek().OnDestroy();
                GameObject.Destroy(dict_uiobject[stack_ui.Peek().uiType.name]);
                dict_uiobject.Remove(stack_ui.Peek().uiType.name);
                stack_ui.Pop();
                Pop(true);
            }
        }
        else
        {
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestroy();
                GameObject.Destroy(dict_uiobject[stack_ui.Peek().uiType.name]);
                dict_uiobject.Remove(stack_ui.Peek().uiType.name);
                stack_ui.Pop();
                if(stack_ui.Count > 0)
                {
                    stack_ui.Peek().OnEnable();
                }
            }


        }


    }


}




    