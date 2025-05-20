using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LoadMapTool))]
public class LoadMapToolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LoadMapTool script = (LoadMapTool)target;

        if (GUILayout.Button("Load Map"))
        {
            script.LoadMapInEditor();
        }

        if (GUILayout.Button("Delete Map"))
        {
            script.DeleteMapInEditor();
        }
    }
}