using UnityEngine;

public class PhoneAttribute : RegexAttribute 
{
	private static string _pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
	private static string _message = "Invalid Phone number! Example: '555-555-5555'";

	public PhoneAttribute() : base(_pattern, _message)	{	}
}