using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovimentacaoSeguir", menuName = "Movimentacao/Movimentacao seguir", order = 2)]
public class MovimentacaoSeguir : Movimentacao
{
    Coroutine mov;
    private Vector2 posJogadorSeguir;

    [Range(0.1f, 2f)]
    public float tempoInteligente = 0;

    public override void Mover()
    {
        if (mov == null)
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

    public override void ResetPosition()
    {
        _objeto.transform.position = new Vector3(0, 3.5f, 0);
    }

    public override void Zerar()
    {
        if (mov != null)
        {
            _objeto.StopCoroutine(mov);
            mov = null;
        }
    }
}
