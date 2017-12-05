using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TagObject))]
public class TagObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TagObject myScript = (TagObject)target;
        if (GUILayout.Button("FilterMe"))
        {
            myScript.ToggleTag();
        }
    }
}

