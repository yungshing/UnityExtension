using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public static class YungsUnityTransformExtension
{
    public static void DestroyAllChilds(this Transform t)
    {
        t.DestroyChilds(0, t.childCount);
    }
    public static void DestroyChild(this Transform t, int index)
    {
        t.DestroyChilds(index, index + 1);
    }
    /// <summary>
    /// 删除子物体 
    /// 范围 [fromeIndex,toIndex)
    /// </summary>
    /// <param name="t"></param>
    /// <param name="fromIndex"></param>
    /// <param name="toIndex"></param>
    public static void DestroyChilds(this Transform t, int fromIndex, int toIndex)
    {
        if (fromIndex < 0)
        {
            fromIndex += t.childCount;
        }
        if (toIndex < 0)
        {
            toIndex += t.childCount;
        }
        for (int i = fromIndex; i < toIndex; i++)
        {
            GameObject.Destroy(t.GetChild(i).gameObject);
        }
    }

    public static T GetChild<T>(this Transform t, int index) where T : Component
    {
        return t.GetChild(index).GetComponent<T>();
    }
    public static T GetChild<T>(this Transform t, string name) where T : Component
    {
        return t.Find(name).GetComponent<T>();
    }

    public static void SetActive(this Transform t, bool active)
    {
        if (t.gameObject.activeSelf != active)
        {
            t.gameObject.SetActive(active);
        }
    }

    public static void SetChildsActive(this Transform t,int fromIndex,int toIndex,bool active)
    {
        if (fromIndex < 0)
        {
            fromIndex += t.childCount;
        }
        if (toIndex < 0)
        {
            toIndex += t.childCount;
        }

    }
}
