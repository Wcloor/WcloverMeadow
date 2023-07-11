using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace wcloverMeadow
{
    public static class GameObjectSetting
    {
        public static void DeteteChGameObject(this Transform transParent)
        {
            ForeahChGameObject(transParent, transform => { UnityEngine.Object.Destroy(transform.gameObject); });
        }
        public static void DeteteChGameObject(this GameObject gameObjectParent)
        {
            ForeahChGameObject(gameObjectParent, transform => { UnityEngine.Object.Destroy(transform.gameObject); });
        }
        public static void ForeahChGameObject(GameObject go, Action<Transform> action)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                action.Invoke(transform);
            }
        }
        public static void ForeahChGameObject(Transform trans, Action<Transform> action)
        {
            for (int i = 0; i < trans.transform.childCount; i++)
            {
                Transform transform = trans.transform.GetChild(i);
                action.Invoke(transform);
            }
        }
    }

}
