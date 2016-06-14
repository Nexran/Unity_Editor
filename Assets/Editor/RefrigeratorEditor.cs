using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Refrigerator data editor, used to show custom editor commands for the refrigerator.
/// </summary>
[CustomEditor(typeof(RefrigeratorData))]
public class RefrigeratorDataEditor : Editor
{
	private SerializedProperty _foods;
	private SerializedProperty _iceCubes;
	private SerializedProperty _weight;
	private SerializedProperty _names;

	/// <summary>
	/// Unity function, raises the enable event.
	/// </summary>
	public void OnEnable()
	{
		//	set up all serialized objects with their respective properties
		_foods = serializedObject.FindProperty("_foods");
		_iceCubes = serializedObject.FindProperty("_iceCubes");
		_weight = serializedObject.FindProperty("_weight");
		_names = serializedObject.FindProperty("_names");
	}

	/// <summary>
	/// Unity function, Raises the inspector GUI event.
	/// </summary>
	public override void OnInspectorGUI()
	{		
		//	update all serialized objects
		serializedObject.Update();
	
		//	show the unique serialized list
		SerializedListUtility.Show(_foods);

		EditorGUILayout.Space();

		EditorGUILayout.LabelField("Ice Cube Nutrition", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(_iceCubes);

		EditorGUILayout.PrefixLabel("Weight in lbs");
		EditorGUILayout.PropertyField(_weight);
		//EditorGUILayout.PropertyField(_names);
		SerializedListUtility.Show(_names);

		//	set all serialized objects
		serializedObject.ApplyModifiedProperties();
	}
}