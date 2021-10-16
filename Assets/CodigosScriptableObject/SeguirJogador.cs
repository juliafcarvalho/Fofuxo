using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeguirJogador", menuName = "Inimigo/Seguir jogador", order = 1)]
public class SeguirJogador : Comportamento
{    
    Coroutine mov;
    private float tempo = 0;
    private Vector2 posJogadorSeguir;

    [Range(0.1f, 2f)]
    public float tempoInteligente = 0;
    [Range(5, 10)]
    public float tempoSeguir = 10;
    public override void Mover()
    {
        if(mov == null)
        mov = _objeto.StartCoroutine(trocarAlvo());

        float step = 7 * Time.deltaTime;

        // move sprite towards the target location
        _objeto.transform.position = Vector2.MoveTowards(_objeto.transform.position, posJogadorSeguir, step);
    }

    public IEnumerator trocarAlvo()
    {     
        while (true)
        {
            posJogadorSeguir = Jogador.jogador.rb2D.position;
            yield return new WaitForSeconds(tempoInteligente);
        }
    }

    public override void ConfiguracoesEstado()
    {
        ResetPosition();
    }

    public override void ResetPosition()
    {
        _objeto.transform.position = new Vector3(0, 3.5f, 0);
    }
    public override void AcabarEstado()
    {
        if(mov != null)
        {
            _objeto.StopCoroutine(mov);            
        }
        Limpar();
    }

    public override void Limpar()
    {
        mov = null;
        tempo = 0;
    }

    public override bool Atingiu()
    {
        tempo += Time.deltaTime;
        if(tempo > tempoSeguir)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}