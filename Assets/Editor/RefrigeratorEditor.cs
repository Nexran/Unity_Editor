using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(RefrigeratorData))]
public class RefrigeratorDataEditor : Editor
{
	private RefrigeratorData _refrigeratorData;
	private Color m_backgroundColor;

	private SerializedProperty _foods;

	public void OnEnable()
	{
		_refrigeratorData = target as RefrigeratorData;

		_foods = serializedObject.FindProperty("_foods");
	}

	public override void OnInspectorGUI ()
	{
		serializedObject.Update();
	
		SerializedListUtility.Show(_foods);

		if(GUI.changed)
		{
			EditorUtility.SetDirty(_refrigeratorData);
		}

		serializedObject.ApplyModifiedProperties();
	}

}