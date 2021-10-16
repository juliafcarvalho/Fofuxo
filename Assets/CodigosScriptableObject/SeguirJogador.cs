using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeguirJogador", menuName = "Inimigo/Seguir jogador", order = 1)]
public class SeguirJogador : Comportamento
{
    public Vector2 positionToMoveTo;
    Coroutine mov;
    public override void Mover()
    {
        if(mov == null)
        mov = _objeto.StartCoroutine(LerpPosition(Jogador.jogador.transform.position, 3));
    }

    public IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = _objeto.transform.position;

        while (time < duration)
        {
            _objeto.transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _objeto.transform.position = targetPosition;
        mov = null;
    }

    public override void ConfiguracoesEstado()
    {
        _objeto.transform.position = new Vector3(0, 3.5f, 0);
    }

    public override void AcabarEstado()
    {
        if(mov != null)
        {
            _objeto.StopCoroutine(mov);
            Limpar();
        }        
    }

    public override void Limpar()
    {
        mov = null;
    }
}