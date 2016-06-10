using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Refrigerator data that stores all refrigerator variables.
/// </summary>
public class RefrigeratorData : ScriptableObject
{
	[SerializeField]
	private List<FoodData> _foods;

	/// <summary>
	/// Gets a list of all the foods
	/// </summary>
	/// <value>The foods.</value>
	public List<FoodData> Foods { get { return _foods; } }
}