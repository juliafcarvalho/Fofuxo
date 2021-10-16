using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Comportamento : ScriptableObject
{
	public GameObject _objeto;
	public virtual void Mover(GameObject _object) 
	{
		
	}
	//public abstract void Think(GameObject _object);
}
