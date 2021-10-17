using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Movimentacao base", menuName = "Movimentacao/Movimentacao base", order = 1)]
public class Movimentacao : ScriptableObject
{
	public InimigoBase _objeto;
	public float velocidade;
	public virtual void Mover() {}

	public virtual void Zerar() { }
	public virtual void ResetPosition() 
	{
		_objeto.transform.position = new Vector3(0, 0, 0);
	}
}
