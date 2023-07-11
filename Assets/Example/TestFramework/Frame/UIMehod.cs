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
            Debug.Log("û���ڳ������ҵ�Canva");
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
        Debug.Log($"��{panel.name}���嵱��û���ҵ�{child_name}����");
        return null;

    }
    public T AddOrGetComponent<T>(GameObject Get_Obj) where T : Component
    {
        if (Get_Obj.GetComponent<T>() != null)
        {
            return Get_Obj.GetComponent<T>();
        }

        Debug.LogWarning($"�޷���{Get_Obj}�����ϻ��Ŀ�������");
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

        Debug.LogWarning($"û����{panel.name}���ҵ�{ComponentName}���壡");
        return null;
    }









}
