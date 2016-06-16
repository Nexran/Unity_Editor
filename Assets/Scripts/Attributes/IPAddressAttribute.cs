using UnityEngine;

public class IPAddressAttribute : RegexAttribute 
{
	private static string _pattern = @"^(?:\d{1,3}\.){3}\d{1,3}$";
	private static string _message = "Invalid IP address! Example: '192.168.1.1'";

	public IPAddressAttribute() : base(_pattern, _message)	{	}
}