using UnityEngine;

public class IPAddressAttribute : RegexAttribute 
{
	private static string pattern = @"^(?:\d{1,3}\.){3}\d{1,3}$";
	private static string message = "Invalid IP address! Example: '192.168.1.1'";

	public IPAddressAttribute() : base(pattern, message)	{	}
}