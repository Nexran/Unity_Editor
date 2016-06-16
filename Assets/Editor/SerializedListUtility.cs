using UnityEditor;
using UnityEngine;

/// <summary>
/// Serialized list utility, used to help show a list with default add,remove, and move functionality. 
/// </summary>
public static class SerializedListUtility
{
	private static GUIContent _moveDownButtonContent = new GUIContent("\u2193", "Move Down");
	private static GUIContent _moveUpButtonContent = new GUIContent("\u2191", "Move Up");
	private static GUIContent _deleteButtonContent = new GUIContent("-", "Delete");
	private static GUIContent _addButtonContent = new GUIContent("Add Element", "Add Element to Array");	
	private static GUILayoutOption _miniButtonWidth = GUILayout.Width(20f);
	private static Color _backgroundColor;

	public static void Show(SerializedProperty list)
	{
		//	if we are not dealing with an array throw an error
		if(list.isArray == false)
		{
			EditorGUILayout.HelpBox(string.Format("Please make sure {0} is an array", list.name), MessageType.Error);
			return;
		}

		//	shows the default array name
		EditorGUILayout.PropertyField(list);

		//	indent everything
		//	make sure to subtract once finished
		EditorGUI.indentLevel += 1;

		//	if the list is folded out show everything
		if(list.isExpanded)
		{
			SerializedProperty size = list.FindPropertyRelative("Array.size");
			EditorGUILayout.PropertyField(size);
			ShowArray(list);
		}

		EditorGUI.indentLevel -= 1;
	}

	/// <summary>
	/// Shows the entire array along with all functionality.
	/// </summary>
	/// <param name="list">List to show.</param>
	private static void ShowArray(SerializedProperty list)
	{
		//	show every element in the array
		for(int i = 0; i < list.arraySize; ++i)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
			ShowButtons(list, i);
			EditorGUILayout.EndHorizontal();
		}

		//	SHOW an ADD BUTTON
		BeginColorButton(Color.green);
		if(GUILayout.Button(_addButtonContent, EditorStyles.miniButton))
		{
			int size = list.arraySize;
			list.InsertArrayElementAtIndex(size);
			ClearArrayElement(list, size);
		}
		EndColorButton();
	}

	/// <summary>
	/// Shows all buttons that are needed per array element.
	/// </summary>
	/// <param name="list">Serialized array to display</param>
	/// <param name="index">Index of element in array to show.</param>
	private static void ShowButtons(SerializedProperty list, int index)
	{
		//	SHOW a MOVE DOWN BUTTON
		if(GUILayout.Button(_moveDownButtonContent, EditorStyles.miniButtonLeft, _miniButtonWidth))
		{
			list.MoveArrayElement(index, index + 1);
		}

		//	SHOW a MOVE UP BUTTON
		if(GUILayout.Button(_moveUpButtonContent, EditorStyles.miniButtonMid, _miniButtonWidth))
		{
			list.MoveArrayElement(index, index - 1);
		}

		//	SHOW a DELETE BUTTON
		BeginColorButton(Color.red);
		if(GUILayout.Button(_deleteButtonContent, EditorStyles.miniButtonRight, _miniButtonWidth))
		{
			ClearArrayElement(list, index);
			list.DeleteArrayElementAtIndex(index);
		}
		EndColorButton();
	}

	private static void ClearArrayElement(SerializedProperty list, int index)
	{
		SerializedProperty arrayElement = list.GetArrayElementAtIndex(index);
		if(arrayElement != null)
		{
			switch(arrayElement.propertyType)
			{
				case SerializedPropertyType.ObjectReference:
				{
					if(arrayElement.objectReferenceValue != null) {  arrayElement.objectReferenceValue = null; }
				}
				break;

				case SerializedPropertyType.String:
				{
					if(arrayElement.stringValue != null) { arrayElement.stringValue = string.Empty; }
				}
				break;
			}
		}
	}

	/// <summary>
	/// Begins the color being applied to a button.
	/// </summary>
	/// <param name="color">Color of the button.</param>
	private static void BeginColorButton(Color color)
	{
		_backgroundColor = GUI.backgroundColor;
		GUI.backgroundColor = color;
	}

	/// <summary>
	/// Ends the color being applied to the button, replaces it with previous color. 
	/// </summary>
	private static void EndColorButton()
	{
		GUI.backgroundColor = _backgroundColor;
	}
}