using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GetLocalUser))]
public class GetLocalUserEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GetLocalUser myScript = (GetLocalUser)target;
        if (GUILayout.Button("Show Matched Only"))
        {
            myScript.ShowMatchedTag();
        }

        if (GUILayout.Button("Clear All Filter"))
        {
            myScript.ClearFilter();
        }
    }
}
