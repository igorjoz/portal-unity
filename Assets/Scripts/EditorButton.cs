using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator generator = (LevelGenerator)target;

        if (GUILayout.Button("Generate labirynth"))
        {
            // debug log
            Debug.Log("Generating labirynth");
            generator.GenerateLibirynth();
        }
    }
}
