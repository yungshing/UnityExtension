using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Reflection;

[CustomEditor(typeof(SpriteRenderer))]
public class YungsSpriteRendererEditor : Editor
{
    private Editor editor;
    private SpriteRenderer tar;
    private void OnEnable()
    {
        tar = target as SpriteRenderer;
        editor = CreateEditor(target, Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.SpriteRendererEditor", true));
    }

    public override void OnInspectorGUI()
    {
        if (editor == null)
        {
            return;
        }
        editor.OnInspectorGUI();
        if (tar.sprite != null)
        {
            EditorGUILayout.LabelField("W : " + tar.sprite.rect.width + "  H : " + tar.sprite.rect.height);
            GUILayout.Box(tar.sprite.texture, GUILayout.Width(64), GUILayout.Height(64));
        }
    }
}