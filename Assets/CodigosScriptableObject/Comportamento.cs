using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum comportamentoJogador { MovBasica, MovBorda, MovVertical, MovHorizontal };

[CreateAssetMenu(fileName = "SeguirJogador", menuName = "Inimigo/Configuracao basica", order = 1)]
public class Comportamento : ScriptableObject
{
	
	public InimigoBase _objeto;
	public comportamentoJogador _comportamentoJogador;
	public Movimentacao _movimentacao;
	public CondicaoVitoria _condicaoVitoria;
	
	public virtual void Atacar() { }
	public virtual void ConfiguracoesEstado() 
	{
		_condicaoVitoria.Configurar();
		_movimentacao.ResetPosition();
		_condicaoVitoria.Zerar();
	}
	public virtual void AcabarEstado() { }
	public virtual void Limpar() 
	{
		_condicaoVitoria.Zerar();
		_movimentacao.Zerar();
	}
	
	
}
