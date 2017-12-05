using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QueryUserData))]
public class QueryUserDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        QueryUserData myScript = (QueryUserData)target;
        if (GUILayout.Button("Get User Data"))
        {
            myScript.GetData();
        }
    }
}
