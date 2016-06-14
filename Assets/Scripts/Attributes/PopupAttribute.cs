using UnityEngine;
using System.Collections;

public class PopupAttribute : PropertyAttribute 
{
	public string [] Names { get; private set; }

	public PopupAttribute(params string [] names) 
	{
		this.Names = names;
	}
}