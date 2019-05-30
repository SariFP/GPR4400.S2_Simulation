using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LSystemTree))]
public class LSystemTreeEditor : Editor
{
    LSystemTree myTarget;

    private void OnEnable()
    {
        myTarget = (LSystemTree)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("Debug Functionality", EditorStyles.boldLabel);

            if(GUILayout.Button("Replace"))
            {
                myTarget.Replace();
            }

            if (GUILayout.Button("Clear"))
            {
                myTarget.Clear();
            }
        EditorGUILayout.EndVertical();
    }
}
