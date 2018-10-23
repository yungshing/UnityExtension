using UnityEngine;
using System.Collections;

public class YungsToolsMono : MonoBehaviour
{
    private static YungsToolsMono instance = null;
    public static YungsToolsMono Instance
    {
        get
        {
            if (instance == null)
            {
                var v = GameObject.FindObjectOfType<YungsToolsMono>();
                if (v == null)
                {
                    var g = new GameObject("Yungs");
                    instance = g.AddComponent<YungsToolsMono>();
                    g.transform.localPosition = Vector3.zero;
                    g.transform.localEulerAngles = Vector3.zero;
                    g.transform.localScale = Vector3.one;
                    DontDestroyOnLoad(g);
                }

            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }


}
