using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMehod
{
    private static UIMehod instance;
    public static UIMehod GetInstance()
    {
        if (instance == null)
        {
            instance = new UIMehod();
            return instance;

        }
        return instance;
    }
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if(gameObject == null)
        {
            Debug.Log("没有在场景里找到Canva");
            return gameObject;

        }
        return gameObject;

    }


    public GameObject FindObjectInChild(GameObject panel,string child_name)
    {
        Transform[] transforms= panel.GetComponentsInChildren<Transform>();
        foreach (Transform t in transforms)
        {
            if(t.gameObject.name == child_name)
            {
                return t.gameObject;

            }
        }
        Debug.Log($"在{panel.name}物体当中没有找到{child_name}物体");
        return null;

    }
    public T AddOrGetComponent<T>(GameObject Get_Obj) where T : Component
    {
        if (Get_Obj.GetComponent<T>() != null)
        {
            return Get_Obj.GetComponent<T>();
        }

        Debug.LogWarning($"无法在{Get_Obj}物体上获得目标组件！");
        return null;
    }

    public T GetOrAddSingleComponentInChild<T>(GameObject panel, string ComponentName) where T : Component
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (Transform tra in transforms)
        {
            if (tra.gameObject.name == ComponentName)
            {
                return tra.gameObject.GetComponent<T>();
               
            }
        }

        Debug.LogWarning($"没有在{panel.name}中找到{ComponentName}物体！");
        return null;
    }









}
