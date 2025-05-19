using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AllComponentsLister : EditorWindow
{
    Vector2 scroll;

    private string[] componentNames;
    private bool[] selectedFlags;
    private List<Type> selectedTypes = new List<Type>();

    [MenuItem("Tools/Component Selector")]
    public static void ShowWindow()
    {
        GetWindow<AllComponentsLister>("Component Selector");
    }

    private void OnEnable()
    {
        // Lấy tất cả các type kế thừa từ Component
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly =>
            {
                try
                { return assembly.GetTypes(); }
                catch { return new Type[0]; }
            })
            .Where(t => t != null && typeof(Component).IsAssignableFrom(t) && !t.IsAbstract)
            .OrderBy(t => t.FullName)
            .ToArray();

        componentNames = types.Select(t => t.FullName).ToArray();
        selectedFlags = new bool[componentNames.Length];
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Chọn các Component:", EditorStyles.boldLabel);

        scroll = EditorGUILayout.BeginScrollView(scroll);
        for (int i = 0; i < componentNames.Length; i++)
        {
            selectedFlags[i] = EditorGUILayout.ToggleLeft(componentNames[i], selectedFlags[i]);
        }
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("In danh sách đã chọn ra Console"))
        {
            selectedTypes = new List<Type>();

            for (int i = 0; i < selectedFlags.Length; i++)
            {
                if (selectedFlags[i])
                {
                    Type type = Type.GetType(componentNames[i]);
                    if (type != null)
                        selectedTypes.Add(type);
                }
            }

            Debug.Log("==== Danh sách đã chọn ====");
            foreach (var t in selectedTypes)
            {
                Debug.Log(t.FullName);
            }
        }
    }
}
