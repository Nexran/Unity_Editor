using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(PopupAttribute))]
public class PopupDrawer : PropertyDrawer 
{
	PopupAttribute _popupAttribute { get { return ((PopupAttribute)attribute); } }

	public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label) 
	{
		int index = EditorGUI.Popup(position, FindPopupPosition(prop.stringValue), _popupAttribute.Names);
		prop.stringValue = _popupAttribute.Names[index];
	}

	/// <summary>
	/// Finds the position of the popup.
	/// </summary>
	/// <returns>The popup position.</returns>
	/// <param name="name">Name.</param>
	public int FindPopupPosition(string name)
	{
		int position = 0;
		for(int i = 0; i < _popupAttribute.Names.Length; ++i)
		{
			if(_popupAttribute.Names[i] == name)
			{
				position = i;
				break;
			}
		}
		return position;
	}
}