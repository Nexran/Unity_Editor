using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Food data that stores all base food variables. 
/// </summary>
[HelpURL("http://www.google.com")]
[CreateAssetMenu]
public class FoodData : ScriptableObject
{
	[Header("Default Settings")]

	[SerializeField]
	[ContextMenuItem("Randomize", "RandomizeName")]
	[Tooltip("This is my name.")]
	private string _name;

	[SerializeField] 
	[Multiline(4)]
	private string _description;

	[SerializeField]
	[Range(0f, 5f)]
	[Header("Random Settings")]
	[Space(50)]
	private float _range;

	[SerializeField]
	[ColorUsageAttribute(false)]
	private Color _noAlphaColor;

	[SerializeField]
	private Color _fullColor;

	[SerializeField]
	//[Popup("Safari", "Chrome", "Firefox")]
	private string [] _names; 

	[SerializeField]
	private Nutrition [] _nutritions;

	[SerializeField]
	private AnimationCurve _curve;

	[SerializeField]
	[Regex(@"^(?:\d{1,3}\.){3}\d{1,3}$", "Invalid IP address! Example: '192.168.1.1'")]
	//[IPAddressAttribute]
	private string _serverAddress;

	[SerializeField]
	[Email]
	private string _email;

	public string Name { get { return _name; } }
	public string [] Names { get { return _names ; } } 
	public string Description { get { return _description; } }
	public Nutrition [] Nutritions { get { return _nutritions; } }
	public float Range { get { return _range; } }
	public Color NoAlphaColor { get { return _noAlphaColor; } }
	public Color FullColor { get { return _fullColor; } }
	public string ServerAddress { get { return _serverAddress; } }

	/// <summary>
	/// Unity funciton, Resets this instance.
	/// </summary>
	public void Reset()
	{
		_name = string.Empty;
		_names = null;
		_nutritions = null;
		_range = 0f;
		_noAlphaColor = Color.blue;
		_fullColor = Color.red;
		_serverAddress = string.Empty;
	}

	private void RandomizeName() 
	{
		string [] names = { "Carbonara", "Lasagne", "Linguini", "Ravioli", "Tortellini", "Ziti" };
		int random = Random.Range(0, names.Length);
		_name = names[random];
	}
}
