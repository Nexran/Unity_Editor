using UnityEngine;

/// <summary>
/// Food data that stores all base food variables. 
/// </summary>
public class FoodData : ScriptableObject
{
	[SerializeField]
	private string _name;

	[SerializeField]
	private int _calories;

	/// <summary>
	/// Gets the name of the food
	/// </summary>
	/// <value>The name.</value>
	public string Name { get { return _name; } }

	/// <summary>
	/// Gets the calories of the food
	/// </summary>
	/// <value>The calorie count.</value>
	public int Calories { get { return _calories; } }
}
