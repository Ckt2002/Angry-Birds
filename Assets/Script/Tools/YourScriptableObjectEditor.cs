//#if UNITY_EDITOR
//using System.Linq;
//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(SOObstacles))]
//public class YourScriptableObjectEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();

//        SOObstacles scriptableObj = (SOObstacles)target;

//        if (GUILayout.Button("Add Selected Prefabs to Array"))
//        {
//            // Get all selected GameObjects in Project view
//            GameObject[] selectedPrefabs = Selection.GetFiltered<GameObject>(SelectionMode.Assets);

//            if (selectedPrefabs.Length > 0)
//            {
//                // Resize the array to fit new prefabs
//                scriptableObj.obstaclePrefabs = selectedPrefabs;
//                scriptableObj.obstaclePrefabs = scriptableObj.obstaclePrefabs.Concat(selectedPrefabs).ToArray();

//                EditorUtility.SetDirty(scriptableObj); // Mark SO as modified
//                AssetDatabase.SaveAssets(); // Save changes
//                Debug.Log($"Added {selectedPrefabs.Length} prefabs to array!");
//            }
//            else
//            {
//                Debug.LogWarning("No GameObjects selected in Project window!");
//            }
//        }
//    }
//}
//#endif