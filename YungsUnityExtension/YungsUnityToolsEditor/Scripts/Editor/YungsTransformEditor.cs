using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(Transform))]
public class YungsTransformEditor : Editor
{
    private Editor edi;
    private Transform tar;
    static Vector3 copyPos = Vector3.zero;
    static Vector3 copyScal = Vector3.zero;
    static Vector3 copyEur = Vector3.zero;
    private GUIContent posContent = EditorGUIUtility.TrTextContent("粘贴坐标", copyPos.ToString());
    private GUIContent eulContent = EditorGUIUtility.TrTextContent("粘贴角度", copyEur.ToString());
    private GUIContent scalContent = EditorGUIUtility.TrTextContent("粘贴缩放", copyScal.ToString());

    void OnEnable()
    {
        edi = CreateEditor(target, Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.TransformInspector", true));

        posContent = EditorGUIUtility.TrTextContent("粘贴坐标", copyPos.ToString());
        eulContent = EditorGUIUtility.TrTextContent("粘贴角度", copyEur.ToString());
        scalContent = EditorGUIUtility.TrTextContent("粘贴缩放", copyScal.ToString());
    }
    public override void OnInspectorGUI()
    {
        tar = target as Transform;
        if (edi == null)
        {
            return;
        }
        edi.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("拷贝坐标"))
        {
            copyPos = tar.localPosition;
            posContent = EditorGUIUtility.TrTextContent("粘贴坐标", copyPos.ToString());
        }
        if (GUILayout.Button("拷贝角度"))
        {
            copyEur = tar.localEulerAngles;
            eulContent = EditorGUIUtility.TrTextContent("粘贴角度", copyEur.ToString());
        }
        if (GUILayout.Button("拷贝缩放"))
        {
            copyScal = tar.localScale;
            scalContent = EditorGUIUtility.TrTextContent("粘贴缩放", copyScal.ToString());
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button(posContent))
        {
            tar.localPosition = copyPos;
        }
        if (GUILayout.Button(eulContent))
        {
            tar.localEulerAngles = copyEur;
        }
        if (GUILayout.Button(scalContent))
        {
            tar.localScale = copyScal;
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("ID :   " + tar.GetInstanceID().ToString());
        EditorGUILayout.LabelField("子物体数量 :   " + tar.childCount.ToString());
        var meshFilter = tar.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            EditorGUILayout.LabelField("自身顶点数(Verts) :   0    三角面数：  0");
        }
        else
        {
            EditorGUILayout.LabelField(string.Format("自身顶点数(Verts) :   {0}    三角面数：  {1}", meshFilter.sharedMesh.vertices.Length, meshFilter.sharedMesh.triangles.Length / 3));
        }
        var mFs = tar.GetComponentsInChildren<MeshFilter>();
        if (mFs == null || mFs.Length == 0)
        {
            EditorGUILayout.LabelField("子物体顶点数(Verts) :   0    三角面数：  0");
        }
        else
        {
            int ver = 0, tri = 0;
            for (int i = 0; i < mFs.Length; i++)
            {
                ver += mFs[i].sharedMesh.vertices.Length;
                tri += mFs[i].sharedMesh.triangles.Length / 3;
            }
            EditorGUILayout.LabelField(string.Format("子物体顶点数(Verts) :   {0}    三角面数：  {1}", ver, tri));
        }
    }
}