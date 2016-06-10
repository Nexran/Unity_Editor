using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Refrigerator data editor, used to show custom editor commands for the refrigerator.
/// </summary>
[CustomEditor(typeof(RefrigeratorData))]
public class RefrigeratorDataEditor : Editor
{
	/// <summary>
	/// Serialized property for the food data 
	/// </summary>
	private SerializedProperty _foods;

	/// <summary>
	/// Unity function, raises the enable event.
	/// </summary>
	public void OnEnable()
	{
		//	set up all serialized objects with their respective properties
		_foods = serializedObject.FindProperty("_foods");
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

		//	set all serialized objects
		serializedObject.ApplyModifiedProperties();
	}
}