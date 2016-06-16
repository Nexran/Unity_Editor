using UnityEngine;

public class EmailAttribute : RegexAttribute 
{
	//	Regex Pattern for Email validation taken from https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx
	private static string _pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
	private static string _message = "Invalid Email address! Example: 'bob@gmail.com'";

	public EmailAttribute() : base(_pattern, _message)	{	}
}