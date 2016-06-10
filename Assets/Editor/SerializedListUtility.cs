using UnityEditor;
using UnityEngine;

public static class SerializedListUtility
{
	private static GUIContent moveDownButtonContent = new GUIContent("\u2193", "Move Down");
	private static GUIContent moveUpButtonContent = new GUIContent("\u2191", "Move Up");
	private static GUIContent deleteButtonContent = new GUIContent("-", "Delete");
	private static GUIContent addButtonContent = new GUIContent("Add Element", "Add Element to Array");	
	private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);
	private static Color _backgroundColor;

	public static void Show(SerializedProperty list)
	{
		if(list.isArray == false)
		{
			EditorGUILayout.HelpBox(string.Format("Please make sure {0} is an array", list.name), MessageType.Error);
			return;
		}

		EditorGUILayout.PropertyField(list);
		EditorGUI.indentLevel += 1;

		if(list.isExpanded)
		{
			SerializedProperty size = list.FindPropertyRelative("Array.size");
			EditorGUILayout.PropertyField(size);
			ShowElements(list);
		}

		EditorGUI.indentLevel -= 1;
	}

	private static void ShowElements(SerializedProperty list)
	{
		for(int i = 0; i < list.arraySize; ++i)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
			ShowButtons(list, i);
			EditorGUILayout.EndHorizontal();
		}

		BeginColorButton(Color.green);
		if(GUILayout.Button(addButtonContent, EditorStyles.miniButton))
		{
			list.arraySize += 1;
		}
		EndColorButton();
	}

	private static void ShowButtons(SerializedProperty list, int index)
	{
		if(GUILayout.Button(moveDownButtonContent, EditorStyles.miniButtonLeft, miniButtonWidth))
		{
			list.MoveArrayElement(index, index + 1);
		}
		if(GUILayout.Button(moveUpButtonContent, EditorStyles.miniButtonMid, miniButtonWidth))
		{
			list.MoveArrayElement(index, index - 1);
		}

		BeginColorButton(Color.red);
		if(GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth))
		{
			int oldSize = list.arraySize;
			list.DeleteArrayElementAtIndex(index);
			if(list.arraySize == oldSize)
			{
				list.DeleteArrayElementAtIndex(index);
			}
		}
		EndColorButton();
	}

	private static void BeginColorButton(Color color)
	{
		_backgroundColor = GUI.backgroundColor;
		GUI.backgroundColor = color;
	}

	private static void EndColorButton()
	{
		GUI.backgroundColor = _backgroundColor;
	}
}