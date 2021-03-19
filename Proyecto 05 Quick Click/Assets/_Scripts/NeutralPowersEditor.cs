using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(NeutralPowers))]
[CanEditMultipleObjects]
public class NeutralPowersEditor : Editor
{
    SerializedProperty NeutralPowers;
    public override void OnInspectorGUI()
    {
        NeutralPowers neutralPowers = target as NeutralPowers;
        neutralPowers.neutralType = EditorGUILayout.IntSlider("Neutral Type",neutralPowers.neutralType,1,3);
        
        if(neutralPowers.neutralType==1)
        {
            neutralPowers.neutralEffect = EditorGUILayout.IntField("Neutral Effect",neutralPowers.neutralEffect);
        }
    }
}
