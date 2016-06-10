using UnityEditor;

/// <summary>
/// CustomMenuEditor used to register all specific Custom Scriptable Assets we can create.
/// </summary>
public static class CustomMenuEditor
{
	[MenuItem("Assets/Create/Refrigerator Data")]
	public static void CreateRefrigeratorData()
	{
		ScriptableObjectUtility.CreateAsset<RefrigeratorData>();
	}

	[MenuItem("Assets/Create/Food Data")]
	public static void CreateFoodData()
	{
		ScriptableObjectUtility.CreateAsset<FoodData>();
	}
}
