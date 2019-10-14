using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Props), true), CanEditMultipleObjects]
public class PropsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Align with the ground"))
        {
            Vector3 planetPosition = FindObjectOfType<Planet>().transform.position;
            foreach (Props t in targets)
            {
                t.transform.up = (t.transform.position - planetPosition).normalized;
            }
        }
    }
}
