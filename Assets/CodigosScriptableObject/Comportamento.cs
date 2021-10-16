using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum comportamentoJogador { MovBasica, MovBorda, MovVertical, MovHorizontal };

public abstract class Comportamento : ScriptableObject
{
	
	public InimigoBase _objeto;
	public comportamentoJogador escolha;
	//public virtual void Mover(GameObject _object)
	public virtual void Mover() 
	{
		
	}
	public virtual void Atacar() { }
	public virtual void ConfiguracoesEstado() { }
	public virtual void AcabarEstado() { }
	public virtual void Limpar() { }
	public virtual bool Atingiu()
    {
		return false;
    }
	public virtual void ResetPosition() { }
}
