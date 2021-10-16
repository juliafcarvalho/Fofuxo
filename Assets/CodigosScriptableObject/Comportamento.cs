using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Comportamento : ScriptableObject
{
	public InimigoBase _objeto;
	//public virtual void Mover(GameObject _object)
	public virtual void Mover() 
	{
		
	}
	public virtual void Atacar() { }
	public virtual void ConfiguracoesEstado() { }
	public virtual void AcabarEstado() { }
	public virtual void Limpar() { }
}
