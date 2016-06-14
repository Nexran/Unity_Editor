using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

[CustomPropertyDrawer(typeof (PhoneAttribute))]
[CustomPropertyDrawer(typeof (URLAttribute))]
[CustomPropertyDrawer(typeof (IPAddressAttribute))]
[CustomPropertyDrawer(typeof (EmailAttribute))]
[CustomPropertyDrawer(typeof (RegexAttribute))]
/// <summary>
/// Regex drawer, taken from Unity 4 example code. 
/// http://blogs.unity3d.com/2012/09/07/property-drawers-in-unity-4/
/// </summary>
public class RegexDrawer : PropertyDrawer 
{
	// These constants describe the height of the help box and the text field.
	const int helpHeight = 30;
	const int textHeight = 16;

	// Provide easy access to the RegexAttribute for reading information from it.
	RegexAttribute regexAttribute{ get { return ((RegexAttribute)attribute); } }// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) 
	{
		if (IsValid (prop))
			return base.GetPropertyHeight (prop, label);
		else
			return base.GetPropertyHeight (prop, label) + helpHeight;
	}

	// Here you can define the GUI for your property drawer. Called by Unity.
	public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label) 
	{
		// Adjust height of the text field
		Rect textFieldPosition = position;
		textFieldPosition.height = textHeight;
		DrawTextField (textFieldPosition, prop, label);

		// Adjust the help box position to appear indented underneath the text field.
		Rect helpPosition = EditorGUI.IndentedRect (position);
		helpPosition.y += textHeight;
		helpPosition.height = helpHeight;
		DrawHelpBox (helpPosition, prop);
	}

	void DrawTextField(Rect position, SerializedProperty prop, GUIContent label) 
	{
		// Draw the text field control GUI.
		EditorGUI.BeginChangeCheck ();
		string value = EditorGUI.TextField (position, label, prop.stringValue);
		if (EditorGUI.EndChangeCheck ())
			prop.stringValue = value;
	}

	void DrawHelpBox(Rect position, SerializedProperty prop) 
	{
		// No need for a help box if the pattern is valid.
		if (IsValid (prop))
			return;

		EditorGUI.HelpBox (position, regexAttribute.HelpMessage, MessageType.Error);
	}

	// Test if the propertys string value matches the regex pattern.
	bool IsValid(SerializedProperty prop) 
	{
		return Regex.IsMatch (prop.stringValue, regexAttribute.Pattern);
	}
}