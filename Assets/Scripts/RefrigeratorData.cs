using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefrigeratorData : ScriptableObject
{
	[SerializeField]
	private List<FoodData> _foods;

	public List<FoodData> Foods { get { return _foods; } }
}