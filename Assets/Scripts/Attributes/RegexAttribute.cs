using UnityEngine;

public class RegexAttribute : PropertyAttribute 
{
	private string _pattern;
	private string _helpMessage;

	public string Pattern 
	{ 
		get { return _pattern; }
		set { _pattern = value; }
	}
		
	public string HelpMessage 
	{ 
		get { return _helpMessage; }
		set { _helpMessage = value; }
	}

	public RegexAttribute(string pattern, string helpMessage) 
	{
		Pattern = pattern;
		HelpMessage = helpMessage;
	}
}