using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ImageFillMonitor))]
public class FillAmountMonitor_Editor : Editor
{

    public override void OnInspectorGUI()
    {

        ImageFillMonitor myTarget = (ImageFillMonitor)target;


        EditorGUILayout.BeginHorizontal();
        myTarget.currentHealth.value = EditorGUILayout.FloatField("current health:", myTarget.currentHealth.value);
        myTarget.currentHealth = EditorGUILayout.ObjectField(myTarget.currentHealth, typeof(FloatVariable)) as FloatVariable;
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        myTarget.maxValue.value = EditorGUILayout.FloatField("max health:", myTarget.maxValue.value);
        myTarget.maxValue = EditorGUILayout.ObjectField(myTarget.maxValue, typeof(FloatVariable)) as FloatVariable;
        EditorGUILayout.EndHorizontal();
        

        myTarget.image = EditorGUILayout.ObjectField("updated image:", myTarget.image, typeof(UnityEngine.UI.Image)) as UnityEngine.UI.Image;
        

    }
}
