using UnityEngine;
using UnityEditor;
using System.IO;
 
/// <summary>
///	Template class used to create unique and new ScriptableObject asset files.
/// </summary>
public static class ScriptableObjectUtility
{
	/// <summary>
	/// Creates a scriptable asset.
	/// </summary>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static void CreateAsset<T>() where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T>();
 
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if(path == string.Empty) 
		{
			path = "Assets";
		} 
		else if(Path.GetExtension(path) != string.Empty) 
		{
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), string.Empty);
		}
 
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/" + typeof(T).ToString() + ".asset");
 
		AssetDatabase.CreateAsset(asset, assetPathAndName);
		AssetDatabase.SaveAssets();
		
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
}