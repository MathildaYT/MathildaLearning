using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Map))]
public class MapModelCreator : Editor
{
    public GameState _state;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawDefaultInspector();
        
        if (GUILayout.Button("CreateMap"))
        {
            Map map = target as Map;
            if (_state==GameState.Start)
            {
             map.InitData();
            }
            
        }
    }
   
}
