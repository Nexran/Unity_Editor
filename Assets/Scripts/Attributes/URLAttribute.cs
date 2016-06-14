using UnityEngine;

public class URLAttribute : RegexAttribute 
{
	private static string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
	private static string message = "Invalid URL address! Example: 'http://www.google.com'";

	public URLAttribute() : base(pattern, message)	{	}
}