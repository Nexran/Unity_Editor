using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer (typeof (Nutrition))]
public class NutritionDrawer : PropertyDrawer 
{	
	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
	{
		//	find the properties 
		SerializedProperty calories = property.FindPropertyRelative("_calories");
		SerializedProperty servingSize = property.FindPropertyRelative("_servingSize");

		EditorGUI.BeginProperty(position, label, property);

		// Draw label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID (FocusType.Passive), label);

		EditorGUI.PropertyField(new Rect (position.x - 120, position.y + 20, position.width + 120, 20), calories);
		EditorGUI.PropertyField(new Rect (position.x - 120, position.y + 40, position.width + 120, 20), servingSize);

		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return 60f;
	}
}