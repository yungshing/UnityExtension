using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class YUTools
{
    public static T Instantiate<T>(T t,Transform parent = null) where T : Component
    {
        return Instantiate(t,t.name,parent);
    }
    public static T Instantiate<T>(T t,string name, Transform parent = null) where T : Component
    {
        var g = GameObject.Instantiate<T>(t);
        if (parent != null)
        {
            g.transform.SetParent(parent);
        }
        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = Vector3.one;
        g.transform.localEulerAngles = Vector3.zero;
        g.name = name;
        return g;
    }

    public static bool Contain<T>(T[] t,T value)
    {
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i].Equals(value))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 不存在 返回-1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetIndex<T>(T[] t,T value)
    {
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i].Equals(value))
            {
                return i;
            }
        }
        return -1;
    }

    public static void Invoke(Action a,float f)
    {
        YungsToolsMono.Instance.StartCoroutine(IEInvoke(new Action[] { a }, f));
    }
    public static void Invoke(Action[] a,float f)
    {
        YungsToolsMono.Instance.StartCoroutine(IEInvoke(a,f));
    }
    static IEnumerator IEInvoke(Action[] a,float f)
    {
        yield return new WaitForSeconds(f);
        for (int i = 0; i < a.Length; i++)
        {
            a[i]();
        }
    }
}

