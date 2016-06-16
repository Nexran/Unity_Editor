using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// Hierarchy GUI adds custom logic to the Hierarchy view in Unity.
/// http://www.yudiz.com/adding-gui-elements-to-the-hierarchy-window/
/// </summary>
[InitializeOnLoad]
public class HierarchyGUI : MonoBehaviour 
{
	private static string _iconUIName = "UITexture.png";
	private static string _icon2DName = "2DTexture.png";

	private static Texture2D _iconUITexture;
	private static Texture2D _icon2DTexture;

	private static GUIStyle _style; 

	static HierarchyGUI()
	{
		EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;

		_iconUITexture = EditorGUIUtility.Load(_iconUIName) as Texture2D;
		_icon2DTexture = EditorGUIUtility.Load(_icon2DName) as Texture2D;

		// new guistyle for the markers
		_style = new GUIStyle(); 
	}

	private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
	{
		// get the gameObject reference using its instance ID
		GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
		Rect rect = new Rect(selectionRect);
		rect.x = rect.width;

		// toggle
		bool toggleStatus = GUI.Toggle(rect, go.activeInHierarchy, string.Empty);
		go.SetActive(toggleStatus);

		RenderIcon<Image>(go, rect, _iconUITexture);
		RenderIcon<SpriteRenderer>(go, rect, _icon2DTexture);
	}

	/// <summary>
	/// Renders an icon next to all objects in the hierarchy with the passed in Type.
	/// </summary>
	/// <param name="go">Gameobject to check</param>
	/// <param name="rect">Rect position</param>
	/// <param name="texture">Texture to display</param>
	/// <typeparam name="T">The type to check for.</typeparam>
	private static void RenderIcon<T>(GameObject go, Rect rect, Texture2D texture)
	{
		T component = go.GetComponent<T>();
		if(component != null && !component.Equals(default(T)))
		{
			rect.x = rect.width - 15;
			rect.width = 15;
			rect.height = rect.height - 2;
			//use the texture as the background for the style
			_style.normal.background = texture;
			//use the style in the GUI label.
			GUI.Label(rect, string.Empty, _style);
		}
	}
}