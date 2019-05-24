using UnityEditor;

[CustomEditor(typeof(FloatTextMonitor))]
public class FloatTextMonitor_Editor : Editor
{
    public override void OnInspectorGUI()
    {

        FloatTextMonitor myTarget = (FloatTextMonitor)target;


        EditorGUILayout.BeginHorizontal();
        myTarget.floatVariable.value = EditorGUILayout.FloatField("lives lest:", myTarget.floatVariable.value);
        myTarget.floatVariable = EditorGUILayout.ObjectField(myTarget.floatVariable, typeof(FloatVariable)) as FloatVariable;
        EditorGUILayout.EndHorizontal();


        myTarget.text = EditorGUILayout.ObjectField("updated image:", myTarget.text, typeof(UnityEngine.UI.Text)) as UnityEngine.UI.Text;


    }
}
