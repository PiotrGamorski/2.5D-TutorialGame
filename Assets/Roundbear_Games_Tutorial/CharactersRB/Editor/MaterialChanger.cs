using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CustomEditor(typeof(CharacterControl))]
    public class MaterialChanger : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CharacterControl control = (CharacterControl)target;

            if (GUILayout.Button("Change Material"))
            {
                control.ChangeMaterial();
            }
        }
    }
}
