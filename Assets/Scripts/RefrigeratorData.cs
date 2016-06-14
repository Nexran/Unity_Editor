using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Refrigerator data that stores all refrigerator variables.
/// </summary>
[CreateAssetMenu(menuName = "Fridge Data")] 
public class RefrigeratorData : ScriptableObject
{
	[SerializeField]
	private List<FoodData> _foods;

	[SerializeField]
	private Nutrition _iceCubes;

	[SerializeField]
	private float _weight;

	[SerializeField]
	private string[] _names;

	/// <summary>
	/// Gets a list of all the foods
	/// </summary>
	/// <value>The foods.</value>
	public List<FoodData> Foods { get { return _foods; } }
}